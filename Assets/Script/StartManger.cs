using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class StartManger : MonoBehaviour
{
    public TextMeshProUGUI title;
        
    public void PlayGameButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            title.text = "Assignment";
        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            title.text = "Fantasy Forest";
        }
    }
}
