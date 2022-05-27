using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script should be assigned to ResetPlane
/// </summary>
public class RenderPlaneCrossingReseter : MonoBehaviour
{
    PortalTeleport portalTeleport;

    private void Start()
    {
        portalTeleport = gameObject.transform.parent.GetComponentInChildren<PortalTeleport>();
    }

    private void OnTriggerEnter(Collider other)
    {
        portalTeleport.setRenderPlaneCrossed(false);
    }
}
