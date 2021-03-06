﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PrenableObject : MonoBehaviour
{

    public static Transform cursor
    {
        get
        {
            if (m_Cursor == null) m_Cursor = GameObject.FindGameObjectWithTag("Cursor").transform;
            return m_Cursor;
        }
    }

    private static Transform m_Cursor = null;

    public bool isHeld { get; private set; }

    public AnimationCurve curve;
    public float maxForce = 8.0f;
    public Vector3 m_Gravity;

    private Collider m_Collider;
    private bool m_IsCursorInObject = false;
    private GlowOnSelected m_GlowScript;

    // Mass of the cubes in the third riddle
    public float massCube;

    void Awake()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        //rigidbody.useGravity = false;
        m_Collider = GetComponent<Collider>();
        //  m_Collider.isTrigger = true;
        Transform playerCursor = cursor;

        m_Gravity = new Vector3(0, -0.75f * rigidbody.mass, 0);
        m_GlowScript = GetComponentInChildren<GlowOnSelected>();
    }

    void FixedUpdate()
    {
        if (!m_IsCursorInObject)
        {
            m_GlowScript.Glow = false;
            return;
        }

        m_GlowScript.Glow = m_Collider.bounds.Contains(m_Cursor.position);

        //get buttons states
        bool[] buttons;
        FalconUnity.getFalconButtonStates(0, out buttons);

        //boutton du milieu => id 0
        if (buttons[0])
        {
            this.transform.position = m_Cursor.position;
            FalconUnity.applyForce(0, m_Gravity, Time.fixedDeltaTime * 2);
            GetComponent<Rigidbody>().useGravity = false;
            isHeld = true;

            return;
        }
        else
            isHeld = false;

        GetComponent<Rigidbody>().useGravity = true;

        //Apply force

        Vector3 center = m_Collider.bounds.center;
        Vector3 direction = cursor.position - center;
        RaycastHit hit;
        m_Collider.Raycast(new Ray(center + direction.normalized * 100.0f, -direction), out hit, 100.0f);

        float t = 1.0f - (direction.magnitude / (hit.point - center).magnitude);
        float force = maxForce * curve.Evaluate(t);
        //Debug.Log("f(" + t + ")= " + force);

        Vector3 forceVector = direction.normalized * -force;
        //Debug.DrawLine(cursor.position, cursor.position + forceVector);
        FalconUnity.applyForce(0, forceVector, Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Cursor"))
        {
            m_IsCursorInObject = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Cursor"))
        {
            m_IsCursorInObject = false;

        }
    }


}
