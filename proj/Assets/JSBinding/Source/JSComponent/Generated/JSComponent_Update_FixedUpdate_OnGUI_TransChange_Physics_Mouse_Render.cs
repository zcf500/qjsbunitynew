﻿//
// Automatically generated by JSComponentGenerator.
//
using UnityEngine;

public class JSComponent_Update_FixedUpdate_OnGUI_TransChange_Physics_Mouse_Render : JSComponent
{
    int idUpdate;
    int idLateUpdate;
    int idFixedUpdate;
    int idOnGUI;
    int idOnTransformChildrenChanged;
    int idOnTransformParentChanged;
    int idOnParticleCollision;
    int idOnCollisionEnter;
    int idOnCollisionEnter2D;
    int idOnCollisionExit;
    int idOnCollisionExit2D;
    int idOnCollisionStay;
    int idOnCollisionStay2D;
    int idOnTriggerEnter;
    int idOnTriggerEnter2D;
    int idOnTriggerExit;
    int idOnTriggerExit2D;
    int idOnTriggerStay;
    int idOnTriggerStay2D;
    int idOnControllerColliderHit;
    int idOnMouseDown;
    int idOnMouseDrag;
    int idOnMouseEnter;
    int idOnMouseExit;
    int idOnMouseOver;
    int idOnMouseUp;
    int idOnMouseUpAsButton;
    int idOnPostRender;
    int idOnPreCull;
    int idOnPreRender;
    int idOnRenderImage;
    int idOnRenderObject;
    int idOnWillRenderObject;

    protected override void initMemberFunction()
    {
        base.initMemberFunction();
        idUpdate = JSApi.getObjFunction(jsObjID, "Update");
        idLateUpdate = JSApi.getObjFunction(jsObjID, "LateUpdate");
        idFixedUpdate = JSApi.getObjFunction(jsObjID, "FixedUpdate");
        idOnGUI = JSApi.getObjFunction(jsObjID, "OnGUI");
        idOnTransformChildrenChanged = JSApi.getObjFunction(jsObjID, "OnTransformChildrenChanged");
        idOnTransformParentChanged = JSApi.getObjFunction(jsObjID, "OnTransformParentChanged");
        idOnParticleCollision = JSApi.getObjFunction(jsObjID, "OnParticleCollision");
        idOnCollisionEnter = JSApi.getObjFunction(jsObjID, "OnCollisionEnter");
        idOnCollisionEnter2D = JSApi.getObjFunction(jsObjID, "OnCollisionEnter2D");
        idOnCollisionExit = JSApi.getObjFunction(jsObjID, "OnCollisionExit");
        idOnCollisionExit2D = JSApi.getObjFunction(jsObjID, "OnCollisionExit2D");
        idOnCollisionStay = JSApi.getObjFunction(jsObjID, "OnCollisionStay");
        idOnCollisionStay2D = JSApi.getObjFunction(jsObjID, "OnCollisionStay2D");
        idOnTriggerEnter = JSApi.getObjFunction(jsObjID, "OnTriggerEnter");
        idOnTriggerEnter2D = JSApi.getObjFunction(jsObjID, "OnTriggerEnter2D");
        idOnTriggerExit = JSApi.getObjFunction(jsObjID, "OnTriggerExit");
        idOnTriggerExit2D = JSApi.getObjFunction(jsObjID, "OnTriggerExit2D");
        idOnTriggerStay = JSApi.getObjFunction(jsObjID, "OnTriggerStay");
        idOnTriggerStay2D = JSApi.getObjFunction(jsObjID, "OnTriggerStay2D");
        idOnControllerColliderHit = JSApi.getObjFunction(jsObjID, "OnControllerColliderHit");
        idOnMouseDown = JSApi.getObjFunction(jsObjID, "OnMouseDown");
        idOnMouseDrag = JSApi.getObjFunction(jsObjID, "OnMouseDrag");
        idOnMouseEnter = JSApi.getObjFunction(jsObjID, "OnMouseEnter");
        idOnMouseExit = JSApi.getObjFunction(jsObjID, "OnMouseExit");
        idOnMouseOver = JSApi.getObjFunction(jsObjID, "OnMouseOver");
        idOnMouseUp = JSApi.getObjFunction(jsObjID, "OnMouseUp");
        idOnMouseUpAsButton = JSApi.getObjFunction(jsObjID, "OnMouseUpAsButton");
        idOnPostRender = JSApi.getObjFunction(jsObjID, "OnPostRender");
        idOnPreCull = JSApi.getObjFunction(jsObjID, "OnPreCull");
        idOnPreRender = JSApi.getObjFunction(jsObjID, "OnPreRender");
        idOnRenderImage = JSApi.getObjFunction(jsObjID, "OnRenderImage");
        idOnRenderObject = JSApi.getObjFunction(jsObjID, "OnRenderObject");
        idOnWillRenderObject = JSApi.getObjFunction(jsObjID, "OnWillRenderObject");
    }

    void Update()
    {
        callIfExist(idUpdate);
    }
    void LateUpdate()
    {
        callIfExist(idLateUpdate);
    }
    void FixedUpdate()
    {
        callIfExist(idFixedUpdate);
    }
    void OnGUI()
    {
        callIfExist(idOnGUI);
    }
    void OnTransformChildrenChanged()
    {
        callIfExist(idOnTransformChildrenChanged);
    }
    void OnTransformParentChanged()
    {
        callIfExist(idOnTransformParentChanged);
    }
    void OnParticleCollision(GameObject other)
    {
        callIfExist(idOnParticleCollision, other);
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        callIfExist(idOnCollisionEnter, collisionInfo);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        callIfExist(idOnCollisionEnter2D, coll);
    }
    void OnCollisionExit(Collision collisionInfo)
    {
        callIfExist(idOnCollisionExit, collisionInfo);
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        callIfExist(idOnCollisionExit2D, coll);
    }
    void OnCollisionStay(Collision collisionInfo)
    {
        callIfExist(idOnCollisionStay, collisionInfo);
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        callIfExist(idOnCollisionStay2D, coll);
    }
    void OnTriggerEnter(Collider other)
    {
        callIfExist(idOnTriggerEnter, other);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        callIfExist(idOnTriggerEnter2D, other);
    }
    void OnTriggerExit(Collider other)
    {
        callIfExist(idOnTriggerExit, other);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        callIfExist(idOnTriggerExit2D, other);
    }
    void OnTriggerStay(Collider other)
    {
        callIfExist(idOnTriggerStay, other);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        callIfExist(idOnTriggerStay2D, other);
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        callIfExist(idOnControllerColliderHit, hit);
    }
    void OnMouseDown()
    {
        callIfExist(idOnMouseDown);
    }
    void OnMouseDrag()
    {
        callIfExist(idOnMouseDrag);
    }
    void OnMouseEnter()
    {
        callIfExist(idOnMouseEnter);
    }
    void OnMouseExit()
    {
        callIfExist(idOnMouseExit);
    }
    void OnMouseOver()
    {
        callIfExist(idOnMouseOver);
    }
    void OnMouseUp()
    {
        callIfExist(idOnMouseUp);
    }
    void OnMouseUpAsButton()
    {
        callIfExist(idOnMouseUpAsButton);
    }
    void OnPostRender()
    {
        callIfExist(idOnPostRender);
    }
    void OnPreCull()
    {
        callIfExist(idOnPreCull);
    }
    void OnPreRender()
    {
        callIfExist(idOnPreRender);
    }
    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        callIfExist(idOnRenderImage, src, dest);
    }
    void OnRenderObject()
    {
        callIfExist(idOnRenderObject);
    }
    void OnWillRenderObject()
    {
        callIfExist(idOnWillRenderObject);
    }

}