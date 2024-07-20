using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager1 : MonoBehaviour
{
    public GameObject coin;

    public Transform player;
    public Transform deadZone;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            float x = i * 1.5f;
            float y = 2f * Mathf.Sin(x);

            Instantiate(coin, new Vector3 (x,y,0f),Quaternion.identity);
        }
    }

    private void Update()
    {
        Vector3 pos = player.position;
        pos.y = 0;
        deadZone.position = pos;
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene(1);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(0);
    }
}
