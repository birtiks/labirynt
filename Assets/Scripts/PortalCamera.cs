using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    private void Update()
    {
        PortalCameraController();
    }

    private void PortalCameraController()
    {
        Quaternion portalsRotations = Quaternion.FromToRotation(otherPortal.forward, portal.forward * (-1));

        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        Vector3 colliderPlanePosition = portal.GetChild(4).position;
        transform.position =
            portalsRotations * playerOffsetFromPortal +
            (new Vector3(colliderPlanePosition.x, 0f, colliderPlanePosition.z));

        Vector3 newCameraDirection = portalsRotations * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
