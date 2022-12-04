using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CapsuleCollider))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float turnSpeed = 180f;

    private CharacterController charController;

    private float currentSpeed;
    private float rotationSpeed;
    private float increment = 10f;
    private float endYRotation = 0;
    private float turn180DegreesSpeed = 3.2f;

    private bool running;
    
    private bool moving;
    private bool turning;

    private Vector3 moveDir;

    public Vector3 MoveDir { get => moveDir; }
    public bool Moving { get => moving; }
    public float RotationSpeed { get => rotationSpeed; }

    void Start()
    {
        charController = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                running = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            running = false;
        }

        if (running)
        {
            if (currentSpeed < runSpeed)
            {
                currentSpeed += increment * Time.deltaTime;
            }
            else
            {
                currentSpeed = runSpeed;
            }
        }
        else
        {
            if (currentSpeed > walkSpeed)
            {
                currentSpeed -= increment * 2 * Time.deltaTime;
            }
            else
            {
                if (Input.GetAxis("Vertical") < 0)
                {
                    currentSpeed = walkSpeed / 2;
                }
                else
                {
                    currentSpeed = walkSpeed;
                }
            }

        }

        if (Input.GetAxis("Vertical") < 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(TurnAwait());
            }
        }

        if (turning)
        {
            TurnPlayer180Degrees();
        }
        else
        {
            RotatePlayer();
            MovePlayer();
        }

        if (moveDir.magnitude != 0 || rotationSpeed!=0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
    }

    void RotatePlayer()
    {
        rotationSpeed = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Rotate(0, rotationSpeed, 0);
    }

    void MovePlayer()
    {
        moveDir = transform.forward * Input.GetAxis("Vertical") * currentSpeed;
        charController.Move(moveDir * Time.deltaTime - Vector3.up * 0.1f);
    }

    IEnumerator TurnAwait()
    {
        if (turning)
            yield break;

        turning = true;
        
        yield return new WaitForSeconds(0.3f);
        turning = false;
    }

    void TurnPlayer180Degrees()
    {
        Vector3 currentAngle = this.transform.rotation.eulerAngles;

        float yAngle = currentAngle.y;

        yAngle += 180;

        endYRotation = yAngle;

        currentAngle = new Vector3(currentAngle.x, yAngle, currentAngle.z);

        this.transform.rotation = Quaternion.Euler(Vector3.LerpUnclamped(transform.rotation.eulerAngles, currentAngle, turn180DegreesSpeed * Time.deltaTime));

        if (this.transform.rotation.eulerAngles.y >= endYRotation)
        {
            turning = false;
            this.transform.rotation = Quaternion.Euler(currentAngle);
        }
    }
}
