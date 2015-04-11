using UnityEngine;
using System;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using SharpKit.JavaScript;

public class JSSerializer : MonoBehaviour
{
    /*
     * AutoDelete: if true  will be automatically deleted when needed (when press Alt + Shift + Q)
     * DON'T change this manually
     */
    [HideInInspector]
    public bool AutoDelete = false;

    public string jsScriptName = string.Empty;
    public string[] arrString = null;
    public UnityEngine.Object[] arrObject = null;

    private struct GameObject_JSComponentName
    {
        public string valName;
        public GameObject go;
        public string scriptName;
        public GameObject_JSComponentName(string _valName, GameObject _go, string _scriptName) { valName = _valName; go = _go; scriptName = _scriptName; }
    }
    private List<GameObject_JSComponentName> cachedRefJSComponent = new List<GameObject_JSComponentName>();
    public enum UnitType
    {
        ST_Unknown = 0,

        ST_Boolean = 1,

        ST_Byte = 2,
        ST_SByte = 3,
        ST_Char = 4,
        ST_Int16 = 5,
        ST_UInt16 = 6,
        ST_Int32 = 7,
        ST_UInt32 = 8,
        ST_Int64 = 9,
        ST_UInt64 = 10,

        ST_Single = 11,
        ST_Double = 12,

        ST_String = 13,

        ST_Enum = 14,
        ST_UnityEngineObject = 15,
        ST_MonoBehaviour = 16,

        ST_MAX = 100,
    }
    public enum AnalyzeType
    {
        Unit,

        ArrayBegin,
        ArrayObj,
        ArrayEnd,

        StructBegin,
        StructObj,
        StructEnd,

        ListBegin,
        ListObj,
        ListEnd,
    }
    /// <summary>
    /// 根据 eType 将 strValue 转换为 jsval
    /// </summary>
    /// <param name="eType"></param>
    /// <param name="strValue"></param>
    /// <returns></returns>
    bool ToJsval(UnitType eType, string strValue)
    {
        bool ret = true;
        switch ((UnitType)eType)
        {
            case UnitType.ST_Boolean:
                {
                    bool v = strValue == "True";
                    JSMgr.vCall.datax.setBoolean(JSDataExchangeMgr.eSetType.Jsval, v);
                }
                break;

            case UnitType.ST_SByte:
            case UnitType.ST_Char:
            case UnitType.ST_Int16:
            case UnitType.ST_Int32:
                {
                    int v;
                    if (int.TryParse(strValue, out v))
                    {
                        JSMgr.vCall.datax.setInt32(JSDataExchangeMgr.eSetType.Jsval, v);
                    }
                    else ret = false;
                }
                break;

            case UnitType.ST_Byte:
            case UnitType.ST_UInt16:
            case UnitType.ST_UInt32:
            case UnitType.ST_Enum:
                {
                    uint v;
                    if (uint.TryParse(strValue, out v))
                    {
                        JSMgr.vCall.datax.setUInt32(JSDataExchangeMgr.eSetType.Jsval, v);
                    }
                    else ret = false;
                }
                break;
            case UnitType.ST_Int64:
            case UnitType.ST_UInt64:
            case UnitType.ST_Single:
            case UnitType.ST_Double:
                {
                    double v;
                    if (double.TryParse(strValue, out v))
                    {
                        JSMgr.vCall.datax.setDouble(JSDataExchangeMgr.eSetType.Jsval, v);
                    }
                    else ret = false;
                }
                break;
            case UnitType.ST_String:
                {
                    JSMgr.vCall.datax.setString(JSDataExchangeMgr.eSetType.Jsval, strValue);
                }
                break;
            default:
                ret = false;
                break;
        }
        return ret;
    }
    // this function is called in Start
    public void initSerializedRefMonoBehaviour(IntPtr cx, IntPtr jsObj)
    {
        foreach (var rel in cachedRefJSComponent)
        {
            GameObject go = rel.go;
            JSComponent_SharpKit[] jsComs = go.GetComponents<JSComponent_SharpKit>();
            foreach (var com in jsComs)
            {
                if (com.jsScriptName == rel.scriptName)
                {
                    // 注意：最多只能绑同 一个名字的脚本一次  
                    // 现在只能支持这样
                    // 数组也不行  要注意
                    JSApi.JSh_SetJsvalObject(ref JSMgr.vCall.valTemp, com.jsObj);
                    JSApi.JSh_SetUCProperty(cx, jsObj, rel.valName, -1, ref JSMgr.vCall.valTemp);
                    break;
                }
            }
        }
        cachedRefJSComponent.Clear();
    }
    public class SerializeStruct
    {
        public enum SType { Root, Array, Struct, List, Unit };
        public SType type;
        public string name;
        public JSApi.jsval val;
        public SerializeStruct father;
        List<SerializeStruct> lstChildren;
        public void AddChild(SerializeStruct ss)
        {
            if (lstChildren == null) 
                lstChildren = new List<SerializeStruct>();
            lstChildren.Add(ss);
        }
        public SerializeStruct(SType t, string name, SerializeStruct father)
        {
            type = t;
            this.name = name;
            this.father = father;
            val.asBits = 0;
        }
        public JSApi.jsval CalcJSVal()
        {
            switch (this.type) 
            {
                case SType.Unit:
                    return this.val;
                    break;
                case SType.Array:
                    {
                        var arrVal = new JSApi.jsval[lstChildren.Count];
                        for (var i = 0; i < arrVal.Length; i++)
                        {
                            arrVal[i] = lstChildren[i].CalcJSVal();
                        }
                        JSMgr.vCall.datax.setArray(JSDataExchangeMgr.eSetType.Jsval, arrVal);
                        return JSMgr.vCall.valTemp;
                    }
                    break;
                case SType.Struct:
                    break;
                case SType.List:
                    break;
            }
        }
    }
    /// <summary>
    /// 遍历 arrString 逐级处理序列化数据
    /// index: arrString 索引
    /// st: 当前父结点
    /// </summary>
    /// <param name="cx"></param>
    /// <param name="jsObj"></param>
    /// <param name="index"></param>
    /// <param name="st"></param>
    /// <returns></returns>
    public int TraverseSerialize(IntPtr cx, IntPtr jsObj, int index, SerializeStruct st)
    {
        var i = index;
        for (/* */; i < arrString.Length; /* i++ */)
        {
            string s = arrString[i];
            int x = s.IndexOf('/');
            int y = s.IndexOf('/', x + 1);
            string s0 = s.Substring(0, x);
            string s1 = s.Substring(x + 1, y - x - 1);
            switch (s0)
            {
                case "ArrayBegin":
                case "StructBegin":
                case "ListBegin":
                    {
                        SerializeStruct.SType sType = SerializeStruct.SType.Array;
                        if (s0 == "StructBegin") sType = SerializeStruct.SType.Struct;
                        else if (s0 == "ListBegin") sType = SerializeStruct.SType.List;

                        var ss = new SerializeStruct(sType, s1, st);
                        st.AddChild(ss);
                        i += TraverseSerialize(cx, jsObj, i + 1, ss);
                    }
                    break;
                case "ArrayEnd":
                case "StructEnd":
                case "ListEnd":
                    {
                        i += TraverseSerialize(cx, jsObj, i + 1, st.father);
                    }
                    break;
                default:
                    {
                        UnitType eUnitType = (UnitType)int.Parse(s0);
                        if (eUnitType == UnitType.ST_UnityEngineObject)
                        {
                            var arr = s1.Split('/');
                            var valName = arr[0];
                            var objIndex = int.Parse(arr[1]);
                            JSMgr.vCall.datax.setObject(JSDataExchangeMgr.eSetType.Jsval, this.arrObject[objIndex]);

                            var child = new SerializeStruct(SerializeStruct.SType.Unit, valName, st);
                            child.val = JSMgr.vCall.valTemp;
                            st.AddChild(child);
                        }
                        else if (eUnitType == UnitType.ST_MonoBehaviour)
                        {
// TODO 最后再做
//                             var arr = s1.Split('/');
//                             var valName = arr[0];
//                             var objIndex = int.Parse(arr[1]);
//                             var scriptName = arr[2];
// 
//                             UnityEngine.Object obj = this.arrObjectArray[objIndex];
//                             cachedRefJSComponent.Add(new GameObject_JSComponentName(valName, (GameObject)obj, scriptName));
// 
//                             var child = new SerializeStruct(SerializeStruct.SType.Unit, valName, st);
//                             child.val = JSMgr.vCall.valTemp;
//                             st.AddChild(child);
                        }
                        else
                        {
                            var arr = s1.Split('/');
                            var valName = arr[0];
                            ToJsval(eUnitType, arr[1]);
                            var child = new SerializeStruct(SerializeStruct.SType.Unit, valName, st);
                            child.val = JSMgr.vCall.valTemp;
                            st.AddChild(child);
                        }
                        // !
                        i++;
                    }
                    break;
            }
        }
        return i - index;
    }
    /// <summary>
    /// 在脚本的 Awake 时会调用这个函数来初始化序列化数据给JS。
    /// </summary>
    /// <param name="cx"></param>
    /// <param name="jsObj"></param>
    public void initSerializedData(IntPtr cx, IntPtr jsObj)
    {
        if (arrString == null || arrString.Length == 0)
        {
            return;
        }

        var root = new SerializeStruct(SerializeStruct.SType.Root, "this-name-doesn't-matter", null);
        TraverseSerialize(cx, jsObj, 0, root);
    }
}