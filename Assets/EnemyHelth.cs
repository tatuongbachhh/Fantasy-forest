using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHelth : MonoBehaviour
{

    EnemyDead enemyDead;
    public Slider health;
    // Start is called before the first frame update
    void Start()
    {
        enemyDead = GetComponent<EnemyDead>();

        health.maxValue = enemyDead.health;// set gia tri max = mau
        health.value = enemyDead.health;// set gia tri hien tai = mau
    }

    // Update is called once per frame
    void Update()
    {
        health.maxValue = enemyDead.health;// set gia tri max = mau
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CoinBullet"))
        {
            health.value --;

        }
    }
}
