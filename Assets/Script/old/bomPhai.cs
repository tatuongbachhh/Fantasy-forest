using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomPhai : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(.1f, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
