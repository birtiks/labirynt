using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// asignet to colidar plane 

public class PortalTeleport : MonoBehaviour
{
    public Transform player;
    public Transform reciver; // portal
    bool playerIsOverlapping = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
    private void FixedUpdate()
    {
        Teleportation();
    }
    private void Teleportation()
    {
        Debug.DrawLine(transform.position, player.position, Color.red);
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(portalToPlayer, transform.up);
            Debug.Log($"dotProduct:{dotProduct}");
            if(dotProduct > 0f)
            {
                float playerCapsuleColliderHalfFOfHeight =
           player.GetComponent<CharacterController>().height;
                player.position = reciver.position + Vector3.up * playerCapsuleColliderHalfFOfHeight;
            }
        }
    }
}
