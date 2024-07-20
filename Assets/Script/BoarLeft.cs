using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarLeft : MonoBehaviour
{
    public float speedMove;
    private Rigidbody2D rb;
    private bool active;
    Animator anim;

    private void Start()
    {
        speedMove = -3f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //Được gọi khi mà đối tượng chứa script này xuất hiện trên camera (được nhìn thấy)
    private void OnBecameVisible()
    {
        active = true;
    }

    //Được gọi khi mà đối tượng chứa script này chuyển từ đang xuất hiện -> không xuất hiện nữa (không xuất hiện trên camera)
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (active)
        {
            rb.velocity = new Vector2(speedMove, rb.velocity.y);
            anim.Play("BoarWalk");
        }
    }
}