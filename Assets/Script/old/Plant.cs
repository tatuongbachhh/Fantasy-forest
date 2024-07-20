using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    bool atk;
    Animator animator;
    public GameObject bullet;
    public Transform bulletPos;

    // Start is called before the first frame update
    void Start()
    {
        atk = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(atk)
        {
            atk = false;
            animator.SetTrigger("atk");
        }
    }

    public void PlantShoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity );
        StartCoroutine(DelayForAtk());
    }

    IEnumerator DelayForAtk()
    {
        yield return new WaitForSeconds(5f);
        atk = true;
    }
}
