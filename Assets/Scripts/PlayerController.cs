using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float jumpForce = 5f;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private bool isGrounded;
    private bool isStarted;
    private bool isJumping;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); // catching Rigidbody2D
        _animator = GetComponent<Animator>(); // catching Animator
        isGrounded = true;
    }
    private void FixedUpdate()
    {
        if (isStarted)
        {
            _rigidbody2D.linearVelocity = new Vector2(speed, _rigidbody2D.linearVelocity.y);
        }
        if (isJumping)
        {
            _rigidbody2D.linearVelocity = new Vector2(0f, jumpForce);
            isJumping = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isStarted && isGrounded)
            {
                //Jump
                _animator.SetTrigger("Jump");
                isGrounded = false;
                isJumping = true;

            }
            else if (!isStarted)
            {
                _animator.SetBool("isGameStarted", true);
                isStarted = true;
            }
        }


        _animator.SetBool("isGrounded", isGrounded);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
