using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroy : MonoBehaviour
{
    public bool showed;

    private void OnBecameVisible()
    {
        showed = true;
    }

    private void OnBecameInvisible()
    {
        if (showed)
        {
            Destroy(gameObject);
        }
    }
}
