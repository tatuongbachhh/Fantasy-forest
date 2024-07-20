using Cinemachine;

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    BoxCollider2D box;
    public CinemachineVirtualCamera cam;

    [SerializeField] private float directionMove;
    [SerializeField] private float speedMove;
    [SerializeField] private float jump;
    [SerializeField] private bool grounded;
    public Transform checkgroundObject;
    public LayerMask groundLayer;
    public LayerMask enemyLayer;

    public TextMeshProUGUI textScore;
    public int score;
    public int highscore;

    public GameObject scoreUI;
    public GameObject scoreBoardUI;

    public TextMeshProUGUI textHighScoreBoard;
    public TextMeshProUGUI textScoreBoard;

    public List<GameObject> gameObjectsEnemy;

    public GameObject bomTrai;
    public GameObject bomPhai;
    public Transform gunPos;

    private void Start()
    {
        score = 0;
        textScore.text = score.ToString();

        highscore = PlayerPrefs.GetInt("highscore");

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();

        speedMove = 5f;
        jump = 10f;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(directionMove * speedMove, rb.velocity.y);
        CheckPlayerGround();
        //checkraycast();
        CreateRayCast();
    }

    private void Update()
    {
        directionMove = Input.GetAxisRaw("Horizontal");

        if(Input.GetKey(KeyCode.Return))
        {
            foreach(GameObject t in gameObjectsEnemy)
            {
                t.GetComponent<Rigidbody2D>().gravityScale = 0;
                t.GetComponent<Rigidbody2D>().velocity = Vector2.up;
            }
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            foreach (GameObject t in gameObjectsEnemy)
            {
                t.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }

        if (directionMove < 0)
        {
            sr.flipX = true;
        }

        if (directionMove > 0)
        {
            sr.flipX = false;
        }

        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetBool("grounded", grounded);
        
        if(Input.GetKeyDown (KeyCode.F))
        {
            Instantiate(bomTrai, gunPos.position, Quaternion.identity);
            Instantiate(bomPhai, gunPos.position, Quaternion.identity);
        }
    }

    public void CreateRayCast()
    {
        RaycastHit2D hitEnemy = Physics2D.Raycast(gunPos.position, Vector2.right, 5f);

        if(hitEnemy.collider != null)
        {
            Debug.DrawRay(gunPos.position, Vector2.right * hitEnemy.distance, Color.red);

            if (hitEnemy.collider.CompareTag("Enemy"))
            {
                Destroy(hitEnemy.collider.gameObject);
            }
        }
        else
        {
            Debug.DrawRay(gunPos.position, Vector2.right * 5f, Color.green);
        }
    }










    public void checkraycast()
    {
        //RaycastHit2D hitEnemy = Physics2D.Raycast(raycastPos.position, Vector2.right, 5f, enemyLayer);

        //if(hitEnemy.collider != null)
        //{
        //    Debug.DrawRay(raycastPos.position, Vector2.right * hitEnemy.distance, Color.green);
        //}
        //else
        //{
        //    Debug.DrawRay(raycastPos.position, Vector2.right * 5f, Color.red);
        //}        
    }

    public void CheckPlayerGround()
    {
        //RaycastHit2D hit = Physics2D.Raycast(checkgroundObject.position,
        //    checkgroundObject.TransformDirection(Vector3.down),
        //    .5f, groundLayer);

        //if (hit)
        //{
        //    grounded = true;
        //}
        //else
        //{
        //    grounded = false;
        //}

        Collider2D[] hit = Physics2D.OverlapCircleAll(checkgroundObject.position, 0.2f, groundLayer);
        if(hit.Length > 0)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            score += 10;
            textScore.text = score.ToString("n0");

            if(highscore < score)
            {
                PlayerPrefs.SetInt("highscore", score);
                highscore = score;
            }

            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("DeadZone"))
        {
            scoreUI.SetActive(false);
            scoreBoardUI.SetActive(true);
            textHighScoreBoard.text = "HIGHSCORE: " + highscore.ToString("n0");
            textScoreBoard.text = "SCORE: " + score.ToString("n0");
            gameObject.SetActive(false);
        }

        if (collision.CompareTag("Enemy"))
        {   

                scoreUI.SetActive(false);
                scoreBoardUI.SetActive(true);
                textHighScoreBoard.text = "HIGHSCORE: " + highscore.ToString("n0");
                textScoreBoard.text = "SCORE: " + score.ToString("n0");
                gameObject.SetActive(false);

            //this.enabled = false;
            //rb.velocity = new Vector2(0f, 10f) ;
            //grounded = false;
            //animator.Play("PlayerFall");
            //box.enabled = false;
            //cam.Follow = null;
        }
    }
}