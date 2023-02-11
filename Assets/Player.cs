using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed = .15f;
    public float moveDistance = 0f;
    public float diagonalMove;
    public Camera mainCamera;
    public Rigidbody body;
    float xVector, yVector;
    private bool isRotating = false;

    // Start is called before the first frame update
    void Start()
    {
        diagonalMove = .8f * moveDistance;
    }

    // Update is called once per frame
    void Update()
    {
        HandleCamera();
        if (!isRotating)
            HandleMovement();
    }

    void HandleCamera(){
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.JoystickButton4))
            StartCoroutine(UpdateAngle(45f));
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.JoystickButton5))
            StartCoroutine(UpdateAngle(-45f));
    }

    void fixAngle(){
        float angle = Mathf.Round(mainCamera.transform.rotation.eulerAngles.y);
        if (((angle + 1) % 45) == 0)
            angle += 1;
        if (((angle - 1) % 45) == 0)
            angle -= 1;
        Quaternion angles = new Quaternion();
        angles.eulerAngles = new Vector3(Mathf.Round(mainCamera.transform.rotation.eulerAngles.x), angle, 0f);
        mainCamera.transform.rotation = angles;
    }

    IEnumerator UpdateAngle(float angle)
    {
        float timeSinceStarted = 0f;
        isRotating = true;
        while (true)
        {
            float lAngle = Mathf.LerpAngle(0, angle, Time.deltaTime);
            timeSinceStarted += Time.deltaTime * 0.45f;
            mainCamera.transform.RotateAround(transform.position,Vector3.up, lAngle);
            //mainCamera.transform.LookAt(transform.position);
            // If the object has arrived, stop the coroutine
            if (timeSinceStarted > 0.45f)
            {
                fixAngle();
                isRotating = false;
                yield break;
            }
 
            // Otherwise, continue next frame
            yield return null;
        }
    }

    void HandleMovement(){
        xVector = Mathf.Round(Input.GetAxisRaw("Horizontal"));
        yVector = Mathf.Round(Input.GetAxisRaw("Vertical"));
        //Debug.Log("x: " + xVector + " y: " + yVector);
        if (Mathf.Abs(xVector) == Mathf.Abs(yVector)){
            
        }
        if (Mathf.Round(mainCamera.transform.eulerAngles.y) == 180){
            if (yVector == 1)
                body.velocity += moveDistance * new Vector3(0f,0f,-1);
            else if (yVector == -1)
                body.velocity += moveDistance * new Vector3(0f,0f,1);
            else if (xVector == 1)
                body.velocity += moveDistance * new Vector3(-1,0f,0f);
            else if(xVector == -1)
                body.velocity += moveDistance * new Vector3(1,0f,0f);
        }
        else if (Mathf.Round(mainCamera.transform.eulerAngles.y) == 90){
            if (yVector == 1)
                body.velocity += moveDistance * new Vector3(1,0f,0f);
            if (yVector == -1)
                body.velocity += moveDistance * new Vector3(-1,0f,0f);
            if (xVector == 1)
                body.velocity += moveDistance * new Vector3(0f,0f,-1);
                if (xVector == -1)
                body.velocity += moveDistance * new Vector3(0f,0f,1);
        }
        else if (Mathf.Round(mainCamera.transform.eulerAngles.y) == 270){
            if (yVector == 1)
                body.velocity += moveDistance * new Vector3(-1,0f,0f);
            if (yVector == -1)
                body.velocity += moveDistance * new Vector3(1,0f,0f);
            if (xVector == 1)
                body.velocity += moveDistance * new Vector3(0f,0f,1);
            if (xVector == -1)
                body.velocity += moveDistance * new Vector3(0f,0f,-1);
        }
        else if (Mathf.Round(mainCamera.transform.eulerAngles.y) == 45){
            if (yVector == 1)
                body.velocity += diagonalMove * new Vector3(1,0f,1);
            if (yVector == -1)
                body.velocity += diagonalMove * new Vector3(-1,0f,-1);
            if (xVector == 1)
                body.velocity += diagonalMove * new Vector3(1,0f,-1);
            if (xVector == -1)
                body.velocity += diagonalMove * new Vector3(-1,0f,1);
        }
        else if (Mathf.Round(mainCamera.transform.eulerAngles.y) == 135){
            if (yVector == 1)
                body.velocity += diagonalMove * new Vector3(1,0f,-1);
            if (yVector == -1)
                body.velocity += diagonalMove * new Vector3(-1,0f,1);
            if (xVector == 1)
                body.velocity += diagonalMove * new Vector3(-1,0f,-1);
            if (xVector == -1)
                body.velocity += diagonalMove * new Vector3(1,0f,1);
        }
        else if (Mathf.Round(mainCamera.transform.eulerAngles.y) == 225){
            if (yVector == 1)
                body.velocity += diagonalMove * new Vector3(-1,0f,-1);
            if (yVector == -1)
                body.velocity += diagonalMove * new Vector3(1,0f,1);
            if (xVector == 1)
                body.velocity += diagonalMove * new Vector3(-1,0f,1);
            if (xVector == -1)
                body.velocity += diagonalMove * new Vector3(1,0f,-1);
        }
        else if (Mathf.Round(mainCamera.transform.eulerAngles.y) == 315){
            if (yVector == 1)
                body.velocity += diagonalMove * new Vector3(-1,0f,1);
            if (yVector == -1)
                body.velocity += diagonalMove * new Vector3(1,0f,-1);
            if (xVector == 1)
                body.velocity += diagonalMove * new Vector3(1,0f,1);
            if (xVector == -1)
                body.velocity += diagonalMove * new Vector3(-1,0f,-1);
        }
        else{
            if (yVector == 1)
                body.velocity += moveDistance * new Vector3(0f,0f,1);
            if (yVector == -1)
                body.velocity += moveDistance * new Vector3(0f,0f,-1);
            if (xVector == 1)
                body.velocity += moveDistance * new Vector3(1,0f,0f);
            if (xVector == -1)
                body.velocity += moveDistance * new Vector3(-1,0f,0f);
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
        void OnCollisionEnter(Collision other) {
            Debug.Log("collision detected");
        }
    }
}
