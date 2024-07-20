using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUICreate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnGUI()
    {
        GUI.Box(new Rect(25, 0, 500, 200), "Load");
        GUI.Label(new Rect(35, 20, 100, 100), "Text đây nhé");

        if (GUI.Button(new Rect(55, 20, 100, 50), "Test 1"))
        {
            print("hehe");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
