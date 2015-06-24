using UnityEngine;
using System.Collections;

public class GlowOnSelected : MonoBehaviour {

    public Material glowMaterial;

    private Transform m_Transform;
    private Mesh m_Mesh;
    private bool m_Glow = false;

    public bool Glow
    {
        get { return m_Glow; }
        set { m_Glow = value; }
    }

    void Awake()
    {
        //m_Transform = transform;
        //m_Mesh = GetComponent<MeshFilter>().sharedMesh;
        //Camera.onPostRender += MyPostRender;
    }

    void OnDestroy()
    {
        //Camera.onPostRender -= MyPostRender;
    }

    void MyPostRender(Camera camera)
    {
        if (!m_Glow) return;

        glowMaterial.SetPass(0);

        Graphics.DrawMeshNow(m_Mesh, m_Transform.localToWorldMatrix);
    }

    public void ToggleGlow()
    {
        m_Glow = !m_Glow;
    }

}
