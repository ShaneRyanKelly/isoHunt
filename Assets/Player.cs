using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed = .15f;
    public float moveDistance = 0f;
    public Camera mainCamera;
    float xVector, yVector;

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
        xVector = Mathf.Round(Input.GetAxisRaw("Horizontal"));
        yVector = Mathf.Round(Input.GetAxisRaw("Vertical"));
        Debug.Log("x: " + xVector + " y: " + yVector);
        if (Mathf.Abs(xVector) == Mathf.Abs(yVector)){
            
        }
        if (Mathf.Round(mainCamera.transform.eulerAngles.y) > 90f && Mathf.Round(mainCamera.transform.eulerAngles.y) < 270f){
            if (yVector == 1)
                transform.position += new Vector3(0f,0f,-moveDistance);
            else if (yVector == -1)
                transform.position += new Vector3(0f,0f,moveDistance);
            else if (xVector == 1)
                transform.position += new Vector3(-moveDistance,0f,0f);
            else if(xVector == -1)
                transform.position += new Vector3(moveDistance,0f,0f);
        }
        else if (Mathf.Round(mainCamera.transform.eulerAngles.y) == 90){
            if (yVector == 1)
                transform.position += new Vector3(moveDistance,0f,0f);
            if (yVector == -1)
                transform.position += new Vector3(-moveDistance,0f,0f);
            if (xVector == 1)
                transform.position += new Vector3(0f,0f,-moveDistance);
                if (xVector == -1)
                transform.position += new Vector3(0f,0f,moveDistance);
        }
        else if (Mathf.Round(mainCamera.transform.eulerAngles.y) == 270){
            if (yVector == 1)
                transform.position += new Vector3(-moveDistance,0f,0f);
            if (yVector == -1)
                transform.position += new Vector3(moveDistance,0f,0f);
            if (xVector == 1)
                transform.position += new Vector3(0f,0f,moveDistance);
            if (xVector == -1)
                transform.position += new Vector3(0f,0f,-moveDistance);
        }
        else{
            if (yVector == 1)
                transform.position += new Vector3(0f,0f,moveDistance);
            if (yVector == -1)
                transform.position += new Vector3(0f,0f,-moveDistance);
            if (xVector == 1)
                transform.position += new Vector3(moveDistance,0f,0f);
            if (xVector == -1)
                transform.position += new Vector3(-moveDistance,0f,0f);
        }
        /*if (Mathf.Round(mainCamera.transform.eulerAngles.y) > 90f && Mathf.Round(mainCamera.transform.eulerAngles.y) < 270f){
            if (Input.GetKeyDown("w"))
                transform.position += new Vector3(0f,0f,-moveDistance);
            if (Input.GetKeyDown("a"))
                transform.position += new Vector3(moveDistance,0f,0f);
            if (Input.GetKeyDown("s"))
                transform.position += new Vector3(0f,0f,moveDistance);
            if (Input.GetKeyDown("d"))
                transform.position += new Vector3(-moveDistance,0f,0f);
        }
        else if (Mathf.Round(mainCamera.transform.eulerAngles.y) == 90){
            if (Input.GetKeyDown("w"))
                transform.position += new Vector3(moveDistance,0f,0f);
            if (Input.GetKeyDown("a"))
                transform.position += new Vector3(0f,0f,moveDistance);
            if (Input.GetKeyDown("s"))
                transform.position += new Vector3(-moveDistance,0f,0f);
            if (Input.GetKeyDown("d"))
                transform.position += new Vector3(0f,0f,-moveDistance);
        }
        else if (Mathf.Round(mainCamera.transform.eulerAngles.y) == 270){
            if (Input.GetKeyDown("w"))
                transform.position += new Vector3(-moveDistance,0f,0f);
            if (Input.GetKeyDown("a"))
                transform.position += new Vector3(0f,0f,-moveDistance);
            if (Input.GetKeyDown("s"))
                transform.position += new Vector3(moveDistance,0f,0f);
            if (Input.GetKeyDown("d"))
                transform.position += new Vector3(0f,0f,moveDistance);
        }
        else{
            if (Input.GetKeyDown("w"))
                transform.position += new Vector3(0f,0f,moveDistance);
            if (Input.GetKeyDown("a"))
                transform.position += new Vector3(-moveDistance,0f,0f);
            if (Input.GetKeyDown("s"))
                transform.position += new Vector3(0f,0f,-moveDistance);
            if (Input.GetKeyDown("d"))
                transform.position += new Vector3(moveDistance,0f,0f);
        }*/
    }
}
