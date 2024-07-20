using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : MonoBehaviour
{
    SpriteRenderer sr;
    Animator animator;
    BoxCollider2D box;

    [SerializeField] Transform posA;
    [SerializeField] Transform posB;
    [SerializeField] float speedMove;
    [SerializeField] bool moveToRight;
    [SerializeField] bool stop;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        speedMove = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            if (!moveToRight)
            {
                if (Vector2.Distance(transform.position, posA.position) >= .1f)
                {
                    animator.SetBool("walk", true);
                    transform.position = Vector2.MoveTowards(
                        transform.position, posA.position, speedMove * Time.deltaTime);
                }
                else
                {
                    stop = true;
                    animator.SetBool("walk", false);
                    StartCoroutine(DelayForWalk(true));
                }
            }
            else
            {
                if (Vector2.Distance(transform.position, posB.position) >= .1f)
                {
                    animator.SetBool("walk", true);
                    transform.position = Vector2.MoveTowards(
                        transform.position, posB.position, speedMove * Time.deltaTime);
                }
                else
                {
                    stop = true;
                    animator.SetBool("walk", false);
                    StartCoroutine(DelayForWalk(false));
                }
            }
        }        
    }

    IEnumerator DelayForWalk(bool batDauSangPhai)
    {
        yield return new WaitForSeconds(3f);
        if (batDauSangPhai)
        {
            sr.flipX = true;
            moveToRight = true;
        }
        else
        {
            sr.flipX = false;
            moveToRight = false;
        }

        stop = false;
    }

    public void Dead()
    {
        box.enabled = false;
        transform.position = Vector2.MoveTowards(transform.position, transform.position * 2f, 2f);
        sr.flipY = true;
    }
}
