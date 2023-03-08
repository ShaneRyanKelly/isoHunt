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
    float xMoveVector, yMoveVector;
    float xAimVector, yAimVector;
    float shoot, swing;
    private bool isRotating = false;
    public GameObject pivot;
    public GameObject projectile;
    private bool canFire = true;
    public int shootCooldown = 1000;
    public float projectileVelocity = 200f;

    // Start is called before the first frame update
    void Start()
    {
        diagonalMove = .8f * moveDistance;
    }

    // Update is called once per frame
    void Update()
    {
        HandleCamera();
        if (!isRotating){
            HandleMovement();
            HandleAiming();
            HandleInput();
            HandleCooldowns();
        }
        Debug.Log("x: " + xAimVector + " y: " + yAimVector);
    }

    void HandleAiming(){
        if (Mathf.Round(Input.GetAxisRaw("Roll")) != 0 || Mathf.Round(Input.GetAxisRaw("Pitch")) != 0){
            xAimVector = Mathf.Round(Input.GetAxisRaw("Roll"));
            yAimVector = Mathf.Round(Input.GetAxisRaw("Pitch"));
        }
        else{
            Debug.Log("x: " + xAimVector + " y: " + yAimVector);
            if (Input.GetKey("[4]")){
                xAimVector = -1f;
                yAimVector = 0f;
            }
            else if (Input.GetKey("[6]")){
                xAimVector = 1f;
                yAimVector = 0f;
            }
            else if (Input.GetKey("[8]")){
                xAimVector = 0f;
                yAimVector = 1f;
            }
            else if (Input.GetKey("[2]")){
                xAimVector = 0f;
                yAimVector = -1f;
            }
            else if (Input.GetKey("[7]")){
                xAimVector = -1f;
                yAimVector = 1f;
            }
            else if (Input.GetKey("[9]")){
                xAimVector = 1f;
                yAimVector = 1f;
            }
            else if (Input.GetKey("[1]")){
                xAimVector = -1f;
                yAimVector = -1f;
            }
            else if (Input.GetKey("[3]")){
                xAimVector = 1f;
                yAimVector = -1f;
            }
            else {
                //xAimVector = pivot.transform.rotation.x;
                //yAimVector = pivot.transform.rotation.y;
            }
        }
        float yAngle = Mathf.Round(mainCamera.transform.eulerAngles.y);
        if (yAngle == 180){
            pivot.transform.rotation = Quaternion.LookRotation(new Vector3(-xAimVector, 0, -yAimVector));
            xAimVector = -xAimVector;
            yAimVector = -yAimVector;
        }
        else if (yAngle == 45)
        {
            if (xAimVector == 0 && yAimVector == 1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, 1));
                xAimVector = 1;
                yAimVector = 1;
            }
            else if (xAimVector == 0 && yAimVector == -1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(-1, 0, -1));
                xAimVector = -1;
                yAimVector = -1;
            } 
            else if (xAimVector == 1 && yAimVector == 1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, 0));
                xAimVector = 1;
                yAimVector = 0;
            }   
            else if (xAimVector == -1 && yAimVector == 1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1));
                xAimVector = 0;
                yAimVector = 1;
            }
            else if (xAimVector == -1 && yAimVector == 0){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(-1, 0, 1));
                xAimVector = -1;
                yAimVector = 1;
            }
            else if (xAimVector == 1 && yAimVector == 0){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, -1));
                xAimVector = 1;
                yAimVector = -1;
            }
            else if (xAimVector == 1 && yAimVector == -1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, -1));
                xAimVector = 0;
                yAimVector = -1;
            }
            else if (xAimVector == -1 && yAimVector == -1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(-1, 0, 0));
                xAimVector = -1;
                yAimVector = 0;
            }
        }
        else if (yAngle == 135){
            if (xAimVector == 0 && yAimVector == 1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, -1));
                xAimVector = 1;
                yAimVector = -1;
            }
            else if (xAimVector == 0 && yAimVector == -1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(-1, 0, 1));
                xAimVector = -1;
                yAimVector = 1;
            }
            else if (xAimVector == 1 && yAimVector == 1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, -1));
                xAimVector = 0;
                yAimVector = -1;
            }
            else if (xAimVector == -1 && yAimVector == 1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, 0));
                xAimVector = 1;
                yAimVector = 0;
            }
            else if (xAimVector == -1 && yAimVector == 0){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, 1));
                xAimVector = 1;
                yAimVector = 1;
            }
            else if (xAimVector == 1 && yAimVector == 0){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(-1, 0, -1));
                xAimVector = -1;
                yAimVector = -1;
            }
            else if (xAimVector == 1 && yAimVector == -1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(-1, 0, 0));
                xAimVector = -1;
                yAimVector = 0;
            }
            else if (xAimVector == -1 && yAimVector == -1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1));
                xAimVector = 0;
                yAimVector = 1;
            }
        }
        else if (yAngle == 225){
            if (xAimVector == 0 && yAimVector == 1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(-1, 0, -1));
                xAimVector = -1;
                yAimVector = -1;
            }
            else if (xAimVector == 0 && yAimVector == -1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, 1));
                xAimVector = 1;
                yAimVector = 1;
            }
            else if (xAimVector == 1 && yAimVector == 1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(-1, 0, 0));
                xAimVector = -1;
                yAimVector = 0;
            }
            else if (xAimVector == -1 && yAimVector == 1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, -1));
                xAimVector = 0;
                yAimVector = -1;
            }
            else if (xAimVector == -1 && yAimVector == 0){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, -1));
                xAimVector = 1;
                yAimVector = -1;
            }
            else if (xAimVector == 1 && yAimVector == 0){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(-1, 0, 1));
                xAimVector = -1;
                yAimVector = 1;
            }
            else if (xAimVector == 1 && yAimVector == -1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1));
                xAimVector = 0;
                yAimVector = 1;
            }
            else if (xAimVector == -1 && yAimVector == -1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, 0));
                xAimVector = 1;
                yAimVector = 0;
            }
        }
        else if (yAngle == 315){
            if (xAimVector == 0 && yAimVector == 1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(-1, 0, 1));
                xAimVector = -1;
                yAimVector = 1;
            }
            else if (xAimVector == 0 && yAimVector == -1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, -1));
                xAimVector = 1;
                yAimVector = -1;
            }
            else if (xAimVector == 1 && yAimVector == 1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1));
                xAimVector = 0;
                yAimVector = 1;
            }
            else if (xAimVector == -1 && yAimVector == 1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(-1, 0, 0));
                xAimVector = -1;
                yAimVector = 0;
            }
            else if (xAimVector == -1 && yAimVector == 0){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(-1, 0, -1));
                xAimVector = -1;
                yAimVector = -1;
            }
            else if (xAimVector == 1 && yAimVector == 0){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, 1));
                xAimVector = 1;
                yAimVector = 1;
            }
            else if (xAimVector == 1 && yAimVector == -1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, 0));
                xAimVector = 1;
                yAimVector = 0;
            }
            else if (xAimVector == -1 && yAimVector == -1){
                pivot.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, -1));
                xAimVector = 0;
                yAimVector = -1;
            }
        }
        else if (yAngle == 90){
            pivot.transform.rotation = Quaternion.LookRotation(new Vector3(yAimVector, 0, -xAimVector));
            var temp = xAimVector;
            xAimVector = yAimVector;
            yAimVector = -temp;
            
        }  
        else if (yAngle == 270){
            pivot.transform.rotation = Quaternion.LookRotation(new Vector3(-yAimVector, 0, xAimVector));
            var temp = yAimVector;
            yAimVector = xAimVector;
            xAimVector = -temp;
        }
        else{
            pivot.transform.rotation = Quaternion.LookRotation(new Vector3(xAimVector, 0, yAimVector));
        }
        //Quaternion angle = new Quaternion();
        //angle.eulerAngles = new Vector3(yAimVector, xAimVector, 0f);
        //cube.transform.Rotate(new Vector3(0f, xAimVector, 0f));
    }

    void HandleCamera(){
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.JoystickButton4))
            StartCoroutine(UpdateAngle(45f));
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.JoystickButton5))
            StartCoroutine(UpdateAngle(-45f));
    }

    void HandleCooldowns(){
        if (!canFire){
            shootCooldown--;
            Debug.Log(shootCooldown);
            if (shootCooldown <= 0)
            {
                canFire = true;
                shootCooldown = 1000;
            }
        }
    }

    void HandleInput(){
        swing = Mathf.Round(Input.GetAxisRaw("Swing"));
        shoot = Mathf.Round(Input.GetAxisRaw("Shoot"));
        if (swing > 0)
            fireProjectile();    
    }

    void fireProjectile(){
        if (canFire){
            Debug.Log("Instantiate projectile!");
            Quaternion projectileAim = new Quaternion();
            projectileAim.eulerAngles = new Vector3(xAimVector, 0f, yAimVector);
            var newProjectile = Instantiate(projectile, pivot.transform.position, projectileAim);
            var body = newProjectile.GetComponent<Rigidbody>();
            body.velocity += projectileVelocity * new Vector3(xAimVector, 0f, yAimVector);
            canFire = false;
        }
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

    IEnumerator UpdateAngle(float angle){
        canFire = true;
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
        xMoveVector = Mathf.Round(Input.GetAxisRaw("Horizontal"));
        yMoveVector = Mathf.Round(Input.GetAxisRaw("Vertical"));
        //Debug.Log("x: " + xMoveVector + " y: " + yMoveVector);
        if (Mathf.Round(mainCamera.transform.eulerAngles.y) == 180){
            if (yMoveVector == 1)
                body.velocity += moveDistance * new Vector3(0f,0f,-1);
            else if (yMoveVector == -1)
                body.velocity += moveDistance * new Vector3(0f,0f,1);
            else if (xMoveVector == 1)
                body.velocity += moveDistance * new Vector3(-1,0f,0f);
            else if(xMoveVector == -1)
                body.velocity += moveDistance * new Vector3(1,0f,0f);
        }
        else if (Mathf.Round(mainCamera.transform.eulerAngles.y) == 90){
            if (yMoveVector == 1)
                body.velocity += moveDistance * new Vector3(1,0f,0f);
            if (yMoveVector == -1)
                body.velocity += moveDistance * new Vector3(-1,0f,0f);
            if (xMoveVector == 1)
                body.velocity += moveDistance * new Vector3(0f,0f,-1);
                if (xMoveVector == -1)
                body.velocity += moveDistance * new Vector3(0f,0f,1);
        }
        else if (Mathf.Round(mainCamera.transform.eulerAngles.y) == 270){
            if (yMoveVector == 1)
                body.velocity += moveDistance * new Vector3(-1,0f,0f);
            if (yMoveVector == -1)
                body.velocity += moveDistance * new Vector3(1,0f,0f);
            if (xMoveVector == 1)
                body.velocity += moveDistance * new Vector3(0f,0f,1);
            if (xMoveVector == -1)
                body.velocity += moveDistance * new Vector3(0f,0f,-1);
        }
        else if (Mathf.Round(mainCamera.transform.eulerAngles.y) == 45){
            if (yMoveVector == 1)
                body.velocity += diagonalMove * new Vector3(1,0f,1);
            if (yMoveVector == -1)
                body.velocity += diagonalMove * new Vector3(-1,0f,-1);
            if (xMoveVector == 1)
                body.velocity += diagonalMove * new Vector3(1,0f,-1);
            if (xMoveVector == -1)
                body.velocity += diagonalMove * new Vector3(-1,0f,1);
        }
        else if (Mathf.Round(mainCamera.transform.eulerAngles.y) == 135){
            if (yMoveVector == 1)
                body.velocity += diagonalMove * new Vector3(1,0f,-1);
            if (yMoveVector == -1)
                body.velocity += diagonalMove * new Vector3(-1,0f,1);
            if (xMoveVector == 1)
                body.velocity += diagonalMove * new Vector3(-1,0f,-1);
            if (xMoveVector == -1)
                body.velocity += diagonalMove * new Vector3(1,0f,1);
        }
        else if (Mathf.Round(mainCamera.transform.eulerAngles.y) == 225){
            if (yMoveVector == 1)
                body.velocity += diagonalMove * new Vector3(-1,0f,-1);
            if (yMoveVector == -1)
                body.velocity += diagonalMove * new Vector3(1,0f,1);
            if (xMoveVector == 1)
                body.velocity += diagonalMove * new Vector3(-1,0f,1);
            if (xMoveVector == -1)
                body.velocity += diagonalMove * new Vector3(1,0f,-1);
        }
        else if (Mathf.Round(mainCamera.transform.eulerAngles.y) == 315){
            if (yMoveVector == 1)
                body.velocity += diagonalMove * new Vector3(-1,0f,1);
            if (yMoveVector == -1)
                body.velocity += diagonalMove * new Vector3(1,0f,-1);
            if (xMoveVector == 1)
                body.velocity += diagonalMove * new Vector3(1,0f,1);
            if (xMoveVector == -1)
                body.velocity += diagonalMove * new Vector3(-1,0f,-1);
        }
        else{
            if (yMoveVector == 1)
                body.velocity += moveDistance * new Vector3(0f,0f,1);
            if (yMoveVector == -1)
                body.velocity += moveDistance * new Vector3(0f,0f,-1);
            if (xMoveVector == 1)
                body.velocity += moveDistance * new Vector3(1,0f,0f);
            if (xMoveVector == -1)
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
