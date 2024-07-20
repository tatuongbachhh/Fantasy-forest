using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DelayForDestroy());
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-7f, rb.velocity.y);
    }

    IEnumerator DelayForDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
