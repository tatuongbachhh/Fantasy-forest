using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public AdsManager ads;
    public GameManager gameManager;
    public Slider playerHealth;
    public Image fillImage;
    public Animator anim;
    public GameObject coinBullet;
    public Transform gunPos;

    private Rigidbody2D rb;
    public float speed;
    public float jump;

    public float timer;

    public List<AudioClip> audioClips;
    private AudioSource audioSource;

    public Transform checkGroundPos;
    public bool isGround;

    public LayerMask groundLayer;

    public int jumpCount;


    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    

        speed = 5f;
        jump = 12f;
        timer = 5f;

        playerHealth.maxValue = 100;
        playerHealth.value = 100;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        //OverlapCheckGround();
        RaycastCheckGround();
    }

    // Update is called once per frame
    private void Update() //gọi theo frame
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            speed = 0;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            speed = 5;
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            speed++;
            timer = 10f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            audioSource.PlayOneShot(audioClips[2]);
            jumpCount++;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            ads.ShowRewardedAd();
        }

        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("grounded", isGround);

        if (Input.GetKeyDown(KeyCode.Y))
        {
            playerHealth.value -= 10;

            if (playerHealth.value <= 70)
            {
                fillImage.color = Color.yellow;
            }

            if (playerHealth.value <= 30)
            {
                fillImage.color = Color.red;
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameManager.GetScore() > 0)
            {
                Instantiate(coinBullet, gunPos.position, Quaternion.identity);
                gameManager.TruScore();
            }
            
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
           GameObject[] getEnemy = GameObject.FindGameObjectsWithTag("Enemy");
            if (getEnemy != null)
            {
                foreach(GameObject enemy in getEnemy)
                {
                    
                    Destroy(enemy);
                }
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            gameManager.AddScore(); //Cộng điểm
            gameManager.SetScoreText(); //Set text
            gameManager.SaveGame(); //Lưu điểm

            audioSource.PlayOneShot(audioClips[0]);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("DeadZone"))
        {
           /* ads.ShowInterstitialAd();*/
            gameManager.PlayerDead();
            Time.timeScale = 0;
        }

        if (collision.CompareTag("Enemy"))
        {
            playerHealth.value-=20;
        }
       
    }

    public void OverlapCheckGround()
    {
        Collider2D[] getCollider = Physics2D.OverlapCircleAll(checkGroundPos.position, 0.2f, groundLayer);

        if (getCollider.Length > 0)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    public void RaycastCheckGround()
    {
        RaycastHit2D hitGround = Physics2D.Raycast(checkGroundPos.position, Vector2.down, 0.2f, groundLayer);

        if (hitGround)
        {
            isGround = true;
            jumpCount = 0;
        }
        else
        {
            isGround = false;
        }
    }
    public void PlayerDead()
    {
        playerHealth.value -= 20;
        if (playerHealth.value <= 0)
        {
            gameManager.PlayerDead();
            Time.timeScale = 0;
        }
    }

}