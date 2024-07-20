using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlant : MonoBehaviour
{
    //Viên đạn sẽ bay từ phải qua trái
    //Bay qua camera thì xóa đi

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,3f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-5f, rb.velocity.y);
    }    
}
