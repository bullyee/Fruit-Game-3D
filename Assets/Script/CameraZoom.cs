using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook freelookcam;
    [SerializeField] CinemachineFreeLook.Orbit[] OriginalOrbits;

    [Range(0.01f, 0.5f)]
    public float minzoom = 0.3f;
    [Range(1f,5f)]
    public float maxzoom = 1.0f;

    [AxisStateProperty]
    public AxisState zAxis = new AxisState(0, 1, false, true, 50f, 0.1f, 0.1f,"Mouse ScrollWheel",true);

    // Start is called before the first frame update
    void Start()
    {
        freelookcam = GetComponentInChildren<CinemachineFreeLook>();
        if (freelookcam != null)
        {
            OriginalOrbits = new CinemachineFreeLook.Orbit[freelookcam.m_Orbits.Length];
            for (int i = 0; i < OriginalOrbits.Length; i++)
            {
                OriginalOrbits[i].m_Height = freelookcam.m_Orbits[i].m_Height;
                OriginalOrbits[i].m_Radius = freelookcam.m_Orbits[i].m_Radius;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OriginalOrbits != null)
        {
            zAxis.Update(Time.deltaTime);
            float zoomscale = Mathf.Lerp(minzoom, maxzoom, zAxis.Value);
            
            for (int i = 0; i < OriginalOrbits.Length; i++)
            {
                freelookcam.m_Orbits[i].m_Height = OriginalOrbits[i].m_Height * zoomscale;
                freelookcam.m_Orbits[i].m_Radius = OriginalOrbits[i].m_Radius * zoomscale;
            }
        }
    }
}
