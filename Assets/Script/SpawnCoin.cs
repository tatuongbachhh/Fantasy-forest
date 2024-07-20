using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    //sau khoảng từ 5-10s -> sinh ra coin
    //số lượng coin sinh ra khoảng 5 - 15 coin
    //coin được xếp theo hình sin
    //vị trí phía trước Player (ngoài khung hình) + cách người chơi 1 khoảng random (15f - 30f)
    //nhân vật chạy qua (không ăn dc) thì xóa coin đó đi

    public Transform player;
    public GameObject coin;

    bool enableSpawn;

    private void Start()
    {
        enableSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Nếu mà enableSpawn = true -> thì cho phép sinh coin
        if (enableSpawn)
        {
            enableSpawn = false;

            float viTriX = player.position.x + Random.Range(15f, 30f);
            float viTriY = Mathf.Sin(viTriX) + 1.5f;

            int soLuong = Random.Range(25, 56);

            for (int i = 0; i < soLuong; i++)
            {
                //Sinh ra coin, ở vị trí nào, hướng xoay (không đổi), làm con của đối tượng nào
                Instantiate(coin, new Vector3(viTriX, viTriY, 0), Quaternion.identity, transform);
                viTriX ++;
                viTriY = Mathf.Sin(viTriX) + 1.5f;
            }

            StartCoroutine(DelayForSpawn());
        }
    }

    IEnumerator DelayForSpawn()
    {
        float timer = Random.Range(5f, 10f);
        yield return new WaitForSeconds(timer);
        enableSpawn = true;
    }
}
