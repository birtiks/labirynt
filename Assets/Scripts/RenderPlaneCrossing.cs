using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script should be assigned to RenderPlane
/// </summary>
public class RenderPlaneCrossing : MonoBehaviour
{
    PortalTeleport portalTeleport;

    private void Start()
    {
        portalTeleport = gameObject.transform.parent.GetComponentInChildren<PortalTeleport>();
    }

    private void OnTriggerEnter(Collider other)
    {
        portalTeleport.setRenderPlaneCrossed(true);
    }

    private void OnTriggerExit(Collider other)
    {
        resetRenderPlaneCrossed();
    }

    private void resetRenderPlaneCrossed()
    {
        if (!portalTeleport.getPlayerIsOverlapping())
            portalTeleport.setRenderPlaneCrossed(false);
    }
}
