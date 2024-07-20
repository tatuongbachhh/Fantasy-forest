using UnityEngine;
using static Cinemachine.AxisState;

public class BoarController : MonoBehaviour
{
    //Di chuyển đến điểm A
    //sau đó nghỉ 2s
    //quay về phải - > di chuyển đến B
    //nghỉ 2s
    //tốc độ di chuyển = 3f

    //quay về phía player
    //tiến về phía player với vận tốc cao hơn: 6f
    //trượt -> chạy tiếp 1 đoạn, quay lại -> nếu thấy người chơi...

    public Transform player;
    public SpriteRenderer sr;
    public Animator anim;

    public Transform boar;
    public Transform posA;
    public Transform posB;

    private bool isFaceRight;
    public float speedMove = 3f;
    private float timer;
    public static bool change = false;

    private Vector3 direction; //hướng di chuyển của Boar
    private Vector3 getPlayerPos;
    public LayerMask playerLayer;
    public bool atk;

    private bool detectedPlayer;

    private void Update()
    {
        if (!atk)
        {
            if (isFaceRight) //nó đang đi sang phải -> posB
            {
                direction = Vector3.right;

                if (Vector2.Distance(boar.position, posB.position) > 0.1f)
                {
                    boar.position = Vector3.MoveTowards(boar.position, posB.position, speedMove * Time.deltaTime);
                    anim.Play("BoarWalk");
                }
                else
                {
                    timer += Time.deltaTime;
                    anim.Play("BoarIdle");

                    if (timer > 2f)
                    {
                        isFaceRight = false;
                        sr.flipX = false;
                        timer = 0;
                    }
                }
            }
            else //nó đang đi trang trái -> posA
            {
                direction = Vector3.left;

                if (Vector2.Distance(boar.position, posA.position) > 0.1f)
                {
                    boar.position = Vector3.MoveTowards(boar.position, posA.position, speedMove * Time.deltaTime);
                    anim.Play("BoarWalk");
                }
                else
                {
                    timer += Time.deltaTime;
                    anim.Play("BoarIdle");

                    if (timer > 2f)
                    {
                        isFaceRight = true;
                        sr.flipX = true;
                        timer = 0;
                    }
                }
            }
        }
        else
        {
            if (Vector3.Distance(boar.position, getPlayerPos) > 0.1f)
            {
                boar.position = Vector3.MoveTowards(boar.position, getPlayerPos, 12f * Time.deltaTime);
            }
            else
            {
                timer += Time.deltaTime;
                anim.Play("BoarIdle");

                if (timer > 1.5f)
                {
                    atk = false;
                    isFaceRight = !isFaceRight;
                    sr.flipX = !sr.flipX;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        RayDetect();
    }

    public void RayDetect()
    {
        RaycastHit2D hitPlayer = Physics2D.Raycast(boar.position + Vector3.up + direction, direction, 10f, playerLayer);

        if (hitPlayer)
        {
            Debug.DrawRay(boar.position + Vector3.up + direction, direction * hitPlayer.distance, Color.red);
            
            speedMove = 12f;
            detectedPlayer = true;
        }
        else
        {
            if (detectedPlayer)
            {
                timer += Time.deltaTime;

                if (timer > 2f)
                {
                    speedMove = 3f;
                    timer = 0f;
                    detectedPlayer = false;
                }
            }
            Debug.DrawRay(boar.position + Vector3.up + direction, direction * 10f, Color.green);
        }

        if (!atk)
        {
            //hitPlayer = Physics2D.Raycast(boar.position + Vector3.up, direction, 10f, playerLayer);

            //if (hitPlayer)
            //{
            //    atk = true;

            //    Debug.DrawRay(boar.position + Vector3.up + direction, direction * hitPlayer.distance, Color.red);
            //    getPlayerPos = new Vector3(hitPlayer.point.x + direction.x * 2f, boar.position.y, 0f);
            //}
            //else
            //{
            //    Debug.DrawRay(boar.position + Vector3.up + direction, direction * 10f, Color.green);
            //}
        }
    }
}