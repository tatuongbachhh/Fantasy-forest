using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomRandom : MonoBehaviour
{
    public Transform vitri1;
    public Transform vitri2;
    public Transform vitri3;

    public GameObject boom;

    float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 9f)
        {
            int rd = Random.Range(1, 4);
            switch (rd)
            {
                case 1: Instantiate(boom, vitri1.position, Quaternion.identity); break;
                case 2: Instantiate(boom, vitri2.position, Quaternion.identity); break;
                case 3: Instantiate(boom, vitri3.position, Quaternion.identity); break;
            }
            timer = 0f;
        }
       
    }
}
