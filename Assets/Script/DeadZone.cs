using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.position.x, 0, 0);
    }
}