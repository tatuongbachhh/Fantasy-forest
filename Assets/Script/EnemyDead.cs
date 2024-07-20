using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    public int health;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("CoinBullet"))
       {
            health--;
            if (health < 1)
            {
                Destroy(gameObject);
            }
       }
    }   
}
