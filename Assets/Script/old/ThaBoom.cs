using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThaBoom : MonoBehaviour
{
    public GameObject boom;
    public bool start;

    // Start is called before the first frame update
    void Start()
    {
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            StartCoroutine(DelayForSpawn(2f));
        }
    }

    IEnumerator DelayForSpawn(float delay)
    {
        start = false;
        yield return new WaitForSeconds(delay);
        Instantiate(boom,transform.position,Quaternion.identity);
        start = true;
    }
}
