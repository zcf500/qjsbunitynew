using SharpKit.JavaScript;
using System;
using UnityEngine;
using System.Collections;

[JsType(JsMode.Clr,"../../../StreamingAssets/JavaScript/SharpKitGenerated/JSBinding/Samples/Serialization/SerializeSimple.javascript")]
public class SerializeSimple : MonoBehaviour 
{
    public int age;
    public Int16 shortAge;
    public GameObject go;
    public string firstName = "QIU";
    public bool doYouLoveMe;
	
	void Start () 
    {
        Debug.Log("age: " + age);
        Debug.Log("shortAge: " + shortAge);
        if (go != null)
            Debug.Log("go: " + go.name);
        else
            Debug.Log("go: null");
        Debug.Log("firstName: " + firstName);
        Debug.Log("doYouLoveMe: " + (doYouLoveMe ? "true" : "false"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
