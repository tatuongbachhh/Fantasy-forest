using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMove : MonoBehaviour
{
    public Vector3 pos;
    public List<Transform> listCoin;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        listCoin = new List<Transform>();

        foreach (Transform item in transform)
        {
            listCoin.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        pos = new Vector3(Mathf.Sin(timer), 0, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, pos, Time.deltaTime);
    }
}
