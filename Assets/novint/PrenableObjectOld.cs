﻿





using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PrenableObjectOld : MonoBehaviour
{

    public static Transform cursor
    {
        get
        {
            if (m_Cursor == null) m_Cursor = GameObject.FindGameObjectWithTag("Cursor").transform;
            return m_Cursor;
        }
    }

    public static Transform m_Cursor = null;

    public AnimationCurve curve;
    public float maxForce = 8.0f;
    public bool taken;

    private Collider m_Collider;
    private bool m_IsCursorInObject = false;
    public Vector3 m_Gravity;
    private Rigidbody rigidbody;

   

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        //rigidbody.useGravity = false;
        m_Collider = GetComponent<Collider>();
        //  m_Collider.isTrigger = true;
        Transform playerCursor = cursor;

        m_Gravity = new Vector3(0, -1.0F * rigidbody.mass, 0);          
    }

    void FixedUpdate()
    {
        rigidbody.useGravity = true;
        taken = false;

        if (!m_IsCursorInObject) return;
               
        //get buttons states
        bool[] buttons;
        FalconUnity.getFalconButtonStates(0, out buttons);

        //boutton du milieu => id 0
        if (buttons[0])
        {
            this.transform.position = m_Cursor.position;
            FalconUnity.applyForce(0, m_Gravity, Time.fixedDeltaTime * 2);
            rigidbody.useGravity = false;
            taken = true;
            return;
        }
        else
        {
             rigidbody.useGravity = true;
        }

        //Apply force

        Vector3 center = m_Collider.bounds.center;
        Vector3 direction = cursor.position - center;
        RaycastHit hit;
        m_Collider.Raycast(new Ray(center + direction.normalized * 100.0f, -(direction.normalized)), out hit, 100.0f);

        float t = 1.0f - (direction.magnitude / (hit.point - center).magnitude);
        float force = maxForce * curve.Evaluate(t);
        //Debug.Log("f(" + t + ")= " + force);

        Vector3 forceVector = direction.normalized * -force;
        //Debug.DrawLine(cursor.position, cursor.position + forceVector);
        FalconUnity.applyForce(0, forceVector, Time.fixedDeltaTime / 2);

    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag("Cursor"))
        {
            m_IsCursorInObject = true;
            GetComponent<Rigidbody>().isKinematic = true;
            
        }

    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Cursor"))
        {
            m_IsCursorInObject = false;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }


}
