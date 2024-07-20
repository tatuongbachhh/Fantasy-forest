using UnityEngine;

public class PlayerInputMove : MonoBehaviour
{
    public float directionMove;
    public float test;
    private Rigidbody2D rb;
    private Animator animator;

    public Transform rayPos;
    public Transform checkGround;

    public LayerMask layer;
    public bool isGrounded;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        directionMove = Input.GetAxis("Horizontal");
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));

        if (directionMove > 0)
        {
            test = Mathf.Lerp(directionMove, 1, Time.deltaTime);
        }

        if (directionMove < 0)
        {
            test = Mathf.Lerp(directionMove, -1f, Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 12f);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(directionMove * 5f, rb.velocity.y);

        //StartRay();
        //RayCheckGround();
        //CircleAllCheckGround();
    }

    public void StartRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayPos.position, Vector3.right, 10f);

        if (hit)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.DrawRay(rayPos.position, Vector3.right * hit.distance, Color.cyan);
                print("chạm quái");
            }
            else
            {
                Debug.DrawRay(rayPos.position, Vector3.right * hit.distance, Color.blue);
                print("chạm đất");
            }
        }
        else
        {
            Debug.DrawRay(rayPos.position, Vector3.right * 10f, Color.green);
        }
    }

    public void RayCheckGround()
    {
        RaycastHit2D hitGround = Physics2D.Raycast(checkGround.position, Vector3.down, .2f);

        if (hitGround)
        {
            isGrounded = true;
            Debug.DrawRay(checkGround.position, Vector3.down * hitGround.distance, Color.red);
        }
        else
        {
            isGrounded = false;
            Debug.DrawRay(checkGround.position, Vector3.down * .2f, Color.green);
        }
    }

    public void CircleAllCheckGround()
    {
        Collider2D[] hitCollider = Physics2D.OverlapCircleAll(checkGround.position, 0.2f, layer);

        if (hitCollider.Length > 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}