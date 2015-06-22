





using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PrenableObjectTaiki : MonoBehaviour
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

    public AnimationCurve curve;
    public float maxForce = 8.0f;
    public bool isBucket = false;

    //public Collider triggerCollider;
    private Collider m_Collider;
    private bool m_IsCursorInObject = false;
    private Vector3 m_Gravity;
    private Vector3 m_GravityFull;
    private Rigidbody parentRigidbody;
    private Transform parentTransform;
   

    void Awake()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        //rigidbody.useGravity = false;
        m_Collider = GetComponent<Collider>();
        //  m_Collider.isTrigger = true;
        Transform playerCursor = cursor;

        m_Gravity = new Vector3(0, -1.0F * rigidbody.mass, 0);

        /*if (isBucket)
        {
            m_GravityFull.y = m_Gravity.y - 4.0F;
        }*/

        //Debug.Log(name +":" + transform.parent);
        parentRigidbody = transform.parent.GetComponent<Rigidbody>();
        parentTransform = transform.parent;
    }

    void FixedUpdate()
    {

        // m_IsCursorInObject = GetComponent<Collider>().bounds.Contains(m_Cursor.position);

        //GetComponent<Rigidbody>().useGravity = false;
        if (!m_IsCursorInObject) return;


       
        //get buttons states
        bool[] buttons;
        FalconUnity.getFalconButtonStates(0, out buttons);

        //boutton du milieu => id 0
        if (buttons[0])
        {

            Vector3 pos = m_Cursor.position;
            //Debug.Log("avant " + m_Gravity.y);
            if (isBucket)
            {
                pos.y -= 0.4F;//todo scale 
                // if (GetComponent<Bucket>().isFull)
                //  m_Gravity = m_GravityFull;
            }
            //Debug.Log("qpres " + m_Gravity.y);
            this.transform.position = pos;

            FalconUnity.applyForce(0, m_Gravity, Time.fixedDeltaTime * 2);
            //GetComponent<Rigidbody>().useGravity = false;
            parentRigidbody.useGravity = false;
            transform.SetParent(null);
            parentTransform.SetParent(transform);
            return;

        }
        else
        {
            parentTransform.SetParent(null);
            transform.SetParent(parentTransform);
            parentRigidbody.useGravity = true;
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
            //GetComponent<Rigidbody>().useGravity = false;
            //GetComponent<Rigidbody>().isKinematic = true;
            
        }

    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Cursor"))
        {
            m_IsCursorInObject = false;
            //GetComponent<Rigidbody>().isKinematic = false;
        }
    }


}
