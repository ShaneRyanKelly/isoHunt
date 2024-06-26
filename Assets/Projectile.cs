using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This method is called when the projectile collides with another object
    void OnTriggerEnter(Collision collision)
    {
        // Destroy this game object upon collision
        Destroy(gameObject);
    }
}