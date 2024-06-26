using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{        
    public Camera mainCamera;
    public GameObject player;
    public float xAngle;
    float yAngle = 0;
    public bool isRotating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.JoystickButton4))
            StartCoroutine(UpdateAngle(45f));
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.JoystickButton5))
            StartCoroutine(UpdateAngle(-45f));
        //UpdateAngle();
        //UpdatePostion();
    }
    public IEnumerator UpdateAngle(float angle)
    {
        float timeSinceStarted = 0f;
        isRotating = true;
        while (true)
        {
            float lAngle = Mathf.LerpAngle(0, angle, Time.deltaTime);
            timeSinceStarted += Time.deltaTime * 0.45f;
            transform.RotateAround(player.transform.position,Vector3.up, lAngle);
            transform.LookAt(player.transform.position);
            // If the object has arrived, stop the coroutine
            if (timeSinceStarted > 0.45f)
            {
                Quaternion angles = new Quaternion();
                angles.eulerAngles = new Vector3(Mathf.Round(transform.rotation.eulerAngles.x), Mathf.Round(transform.rotation.eulerAngles.y), 0f);
                transform.rotation = angles;
                isRotating = false;
                yield break;
            }
 
            // Otherwise, continue next frame
            yield return null;
        }
    }

    /*void UpdateAngle(){
        float angle = Mathf.LerpAngle(0, 45, 2);
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.JoystickButton4))
            transform.RotateAround(player.transform.position, Vector3.up, angle);
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.JoystickButton5))
            transform.RotateAround(player.transform.position, Vector3.up, -angle);

        transform.LookAt(player.transform.position);
    }*/
    
    void UpdatePostion(){
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
            //mainCamera.transform.position += new Vector3(5f,0f,-5f);
        //if (Input.GetKeyDown(KeyCode.RightArrow))
            //mainCamera.transform.position += new Vector3(-2f,0f,2f);
    }
}
