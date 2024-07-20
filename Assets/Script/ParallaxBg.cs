using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBg : MonoBehaviour
{
    public PlayerController player;
    public Material bg2;
    public Material bg3;
    public Material bg4;
    public Material bg5;

    float offset2;
    float offset3;
    float offset4;
    float offset5;

    // Update is called once per frame
    void Update()
    {
        offset2 += 0.01f * Time.deltaTime * player.speed;
        offset3 += 0.03f * Time.deltaTime * player.speed;
        offset4 += 0.05f * Time.deltaTime * player.speed;
        offset5 += 0.07f * Time.deltaTime * player.speed;

        bg2.mainTextureOffset = new Vector2(offset2,0);
        bg3.mainTextureOffset = new Vector2(offset3,0);
        bg4.mainTextureOffset = new Vector2(offset4,0);
        bg5.mainTextureOffset = new Vector2(offset5,0);
    }
}
