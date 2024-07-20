using UnityEngine;

public class AngryPlant : MonoBehaviour
{
    //Mỗi 3s - bắn ra 1 viên đạn về phía trái
    //Viên đạn phải bay ra từ mồm nó
    //Viên đạn sau khi bay qua camera thì bị xóa đi
    //Người chơi chạy qua Plant, con đó bị xóa đi
    //Người chơi chạm vào đạn thì trừ máu/chết
    //Đặt nó xuất hiện ngẫu nhiên (phía trước nhân vật)

    public GameObject bullet;
    public Transform bulletPos;

    public LayerMask layerMask;

    private Animator animator;

    public float timer;

    public bool atk;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update() //gọi mỗi frame
    {
        timer += Time.deltaTime;
        //float loop = Random.Range(3f, 7f);

        if (timer >= 3f)
        {
            animator.SetTrigger("atk");
            timer = 0f;
        }
    }

    private void FixedUpdate() //0,02s gọi 1 lần
    {
        //RaycastDetectPlayer();
    }

    public void PlantShoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    public void RaycastDetectPlayer()
    {
        //Chiếu Raycast dài 10f về bên trái (điểm bắt đầu từ con plant)
        //nếu Raycast trúng player -> thì variable atk = true
        //Vẽ được tia raycast = Debug.DrawRay(..
        //Khi không chạm player thì tia này màu xanh
        //Khi chạm thì màu đỏ ... (màu nào cũng dc)

        RaycastHit2D hitPlayer = Physics2D.Raycast(bulletPos.position, Vector2.left, 10f, layerMask);

        if (hitPlayer)
        {
            Debug.DrawRay(bulletPos.position, Vector2.left * hitPlayer.distance, Color.red);
            atk = true;
        }
        else
        {
            Debug.DrawRay(bulletPos.position, Vector2.left * 10f, Color.green);
            atk = false;
        }
    }
}