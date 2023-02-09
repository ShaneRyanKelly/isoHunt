using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{        
    public Camera mainCamera;
    public GameObject player;
    public float xAngle;
    float yAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAngle();
        UpdatePostion();
    }

    void UpdateAngle(){
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.JoystickButton4))
            transform.RotateAround(player.transform.position, Vector3.up, 45);
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.JoystickButton5))
            transform.RotateAround(player.transform.position, Vector3.up, -45);

        transform.LookAt(player.transform.position);
    }
    
    void UpdatePostion(){
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
            //mainCamera.transform.position += new Vector3(5f,0f,-5f);
        //if (Input.GetKeyDown(KeyCode.RightArrow))
            //mainCamera.transform.position += new Vector3(-2f,0f,2f);
    }
}
