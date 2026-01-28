using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;

    private Rigidbody2D _rb2D;
    private float move;

    public float jumpForce = 4;
    private bool _isGrounded;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        _rb2D.linearVelocity = new Vector2(move * speed, _rb2D.linearVelocity.y);

        if (move != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);
        }

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rb2D.linearVelocity = new Vector2(_rb2D.linearVelocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }
}
