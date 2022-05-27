using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Camera myCamera;
    public GameObject player;
    public Transform myRenderPlane;
    public Transform myColliderPlane;
    public Portal otherPortal;

    PortalCamera portalCamera;
    PortalTeleport portalTeleport;

    public Material material;

    private void Awake()
    {
        portalCamera = myCamera.GetComponent<PortalCamera>();
        portalTeleport = myColliderPlane.gameObject.GetComponent<PortalTeleport>();
        player = GameObject.FindGameObjectWithTag("Player");

        portalCamera.playerCamera = player.gameObject.transform.GetChild(0);
        portalCamera.otherPortal = otherPortal.transform;
        portalCamera.portal = this.transform;

        portalTeleport.player = player.transform;
        portalTeleport.receiver = otherPortal.transform;

        myRenderPlane.gameObject.GetComponent<Renderer>().material = Instantiate(material);

        if (myCamera.targetTexture != null)
            myCamera.targetTexture.Release();
        myCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
    }

    private void Start()
    {
        myRenderPlane.gameObject.GetComponent<Renderer>().material.mainTexture = otherPortal.myCamera.targetTexture;
    }
}
