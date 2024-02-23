using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0;
    private float moveSpeed = 7f;
    private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }


    // Start is called before the first frame update
    private void Start()
    {
        // Getting the RigidBody component
        rigidBody = GetComponent<Rigidbody2D>();
        // Getting the Animator component
        animator = GetComponent<Animator>();
        // Getting the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Getting the BoxCollider component
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Horizontal Movement
        dirX = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(dirX * moveSpeed, rigidBody.velocity.y);

        // Jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    //Toggle running animation
    private void UpdateAnimationState()
    {
        MovementState state = 0;

        // Going right
        if (dirX > 0)
        {
            state = MovementState.running;
            spriteRenderer.flipX = false;
        }
        // Going left
        else if (dirX < 0)
        {
            state = MovementState.running;
            spriteRenderer.flipX = true;
        }
        else if (dirX == 0)
        {
            state = MovementState.idle;
        }

        if (rigidBody.velocity.y > 0.1f)
            state = MovementState.jumping;

        else if (rigidBody.velocity.y < -0.1f)
            state = MovementState.falling;

        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
