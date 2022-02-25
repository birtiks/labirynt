using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 12f;
    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {

    }
    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = Vector3.right * x + Vector3.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
        characterController.Move(move * speed * Time.deltaTime);
    }
}
