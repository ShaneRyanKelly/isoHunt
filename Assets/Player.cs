using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement(){
        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(playerInput.x, 0f, playerInput.y);
        Vector3 displacement = velocity * Time.deltaTime;        
        float maxSpeed = .25f;
        transform.position += maxSpeed * new Vector3(playerInput.x, 0f, playerInput.y);
    }
}
