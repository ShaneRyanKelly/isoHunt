using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float maxSpeed = .15f;
    public float moveSpeed = 5f; // A more intuitive way to control movement
    public Camera mainCamera;
    public Rigidbody body;
    public GameObject pivot;
    public GameObject projectile;
    public int shootCooldown = 100;
    public float projectileVelocity = 200f;
    private bool isRotating = false;
    private bool canFire = true;
    private int shootMax = 100;
    public float rotationSpeed;

    public bool fixedRotation = false; // Flag to control rotation mode
    private Color originalColor;      // To store the original ball color

    void Start()
    {
        originalColor = GetComponent<Renderer>().material.color; // Get initial color
        StartCoroutine(PulseColor()); // Start pulsing right away
    }

    void Update()
    {
        Debug.Log("fixedRotation is: " + fixedRotation); // Debug log to check the flag value

        if (fixedRotation) 
        {
            Debug.Log("Entering HandleCamera");
            HandleCamera();
        } 
        else
        {
            Debug.Log("Entering HandleFreeRotation");
            HandleFreeRotation(); // New method for free rotation
        }
        if (!isRotating)
        {
            HandleMovement();
            HandleAiming();
            HandleInput();
            HandleCooldowns();
        }
    }

    void HandleCamera()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.JoystickButton4))
            StartCoroutine(mainCamera.GetComponent<Camera>().UpdateAngle(45f));
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.JoystickButton5))
            StartCoroutine(mainCamera.GetComponent<Camera>().UpdateAngle(-45f));
    }

    void HandleMovement()
    {
        // Simplified movement based on camera's forward and right directions
        Vector3 moveDirection = Vector3.zero;
        moveDirection += Input.GetAxisRaw("Horizontal") * mainCamera.transform.right;
        moveDirection += Input.GetAxisRaw("Vertical") * mainCamera.transform.forward;

        // Ensure we only move on the horizontal plane (isometric)
        moveDirection.y = 0f;

        body.velocity = moveDirection.normalized * moveSpeed;
    }

    void HandleAiming()
    {
        // Aiming direction based on camera's forward
        Vector3 aimDirection = mainCamera.transform.forward;
        aimDirection.y = 0f;  // Keep it on the horizontal plane

        pivot.transform.rotation = Quaternion.LookRotation(aimDirection);
    }

    void HandleCooldowns()
    {
        if (!canFire)
        {
            shootCooldown--;
            if (shootCooldown <= 0)
            {
                canFire = true;
                shootCooldown = shootMax;
            }
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown("space"))
            FireProjectile();
    }

void HandleFreeRotation()
{
    Debug.Log("Free rotation active"); // Debug log to indicate entering the method
    
    // Get input from arrow keys
    float horizontalInput = 0f;

    if (Input.GetKey(KeyCode.LeftArrow))
    {
        horizontalInput = -1f;
    }
    else if (Input.GetKey(KeyCode.RightArrow))
    {
        horizontalInput = 1f;
    }

    // Apply rotation based on the input
    transform.Rotate(0f, horizontalInput * rotationSpeed, 0f); // Adjust the 5f for rotation speed
}

    IEnumerator PulseColor()
    {
        while (true) // Pulse forever
        {
            Color targetColor = Color.cyan;
            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime;
                GetComponent<Renderer>().material.color = Color.Lerp(originalColor, targetColor, t);
                yield return null;
            }

            t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime;
                GetComponent<Renderer>().material.color = Color.Lerp(targetColor, originalColor, t);
                yield return null;
            }
        }
    }

    void FireProjectile()
    {
        if (canFire)
        {
            var newProjectile = Instantiate(projectile, pivot.transform.position, pivot.transform.rotation);
            var body = newProjectile.GetComponent<Rigidbody>();
            body.velocity += projectileVelocity * pivot.transform.forward; // Use pivot's direction for shooting
            canFire = false;
        }
    }
}
