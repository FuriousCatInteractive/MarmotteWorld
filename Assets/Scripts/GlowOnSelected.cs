using UnityEngine;
using System.Collections;

public class GlowOnSelected : MonoBehaviour {

    public Material glowMaterial;

    private Transform m_Transform;
    private Mesh m_Mesh;
    private bool m_Glow = false;

    void Awake()
    {
        m_Transform = transform;
        m_Mesh = GetComponent<MeshFilter>().sharedMesh;
    }

    void MyPostRender(Camera camera)
    {
        glowMaterial.SetPass(0);

        Graphics.DrawMeshNow(m_Mesh, m_Transform.localToWorldMatrix);
    }

    public void ToggleGlow()
    {
        m_Glow = !m_Glow;
        if (m_Glow)
            Camera.onPostRender += MyPostRender;
        else
            Camera.onPostRender -= MyPostRender;
    }

}
