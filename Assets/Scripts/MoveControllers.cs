using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveControllers : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private bool groundedPlayer;
    public Transform cam;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    private float playerSpeed = 6.0f;
    private Vector3 playerVelocity;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private bool isJumping;
    public Animator animator;

    public ManagerData gameData;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (gameData.PlayerSpeed != 0)
        {
            playerSpeed = gameData.PlayerSpeed;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKeyDown("1"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        groundedPlayer = controller.isGrounded;

        if (groundedPlayer)
        {
            animator.SetBool("isGrounded", true);
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("isJumping", true);
                isJumping = true;
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
        } else
        {
            animator.SetBool("isGrounded", false);

            if(isJumping && playerVelocity.y < 0 || playerVelocity.y < -2)
            {
                animator.SetBool("isFalling", true);
            }

        }

        if (groundedPlayer && playerVelocity.y < 0)
        {
            
            playerVelocity.y = 0f;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(horizontal, 0f, vertical).normalized;
        if (move.magnitude >= 0.1f)
        {
            animator.SetBool("isRunning", true);
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(moveDirection.normalized * Time.deltaTime * playerSpeed);
        } else
        {
            animator.SetBool("isRunning", false);
        }
        // Changes the height position of the player..
        
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void UpdatePlayerSpeed(float SetPlayerSpeed)
    {
        playerSpeed = SetPlayerSpeed;
    }
}