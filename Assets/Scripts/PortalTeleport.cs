using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform player;
    public Transform receiver;

    bool playerIsOverlapping = false;
    bool renderPlaneCrossed = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }

    public void setRenderPlaneCrossed(bool crossed)
    {
        renderPlaneCrossed = crossed;
    }

    public bool getPlayerIsOverlapping()
    {
        return playerIsOverlapping;
    }

    private void FixedUpdate()
    {
        Teleportation();
    }

    //WARNING - PRECONDITIONS:
    //1) pivot of portal must be set "on the floor" of portal on the exit
    //2) ColliderPlane should be moved close to RenderPlane and so far from pivot
    //so it won't close us in teleportation loop.
    //3) ResetPlane should be positioned on exit of the teleport (on the opposite side of RenderPlane)
    private void Teleportation()
    {
        Debug.DrawLine(transform.position, player.position, Color.red);

        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if (dotProduct > 0f && !renderPlaneCrossed)
            {
                //half of height of player's capsule collider
                float playerCapsuleColliderHalfOfHeight = player.GetComponent<CharacterController>().height;
                player.position = receiver.position + Vector3.up * playerCapsuleColliderHalfOfHeight;

                //Calc rotation between player and his previous portal
                //Convert angle to quaternions
                Quaternion portalDiff = Quaternion.FromToRotation(transform.parent.forward, player.forward);
                //now we can rotate vector
                Vector3 newDirection = portalDiff * receiver.GetChild(4).up;
                player.rotation = Quaternion.LookRotation(newDirection);

                playerIsOverlapping = false;
            }
        }
    }
}
