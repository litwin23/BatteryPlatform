using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 moveVector;
    public float speed;
    public float jumpForce;
    public Transform Player;
    private float playerY; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerY = Player.position.y;
        
        Walk();
        Jump();
        if (playerY <= -6)
        {
            Dead();
        }
    }

    void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveVector.x * speed, rb.linearVelocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x , jumpForce);
        }
    }

    void Dead()
    {
        Destroy(gameObject);
    }
}