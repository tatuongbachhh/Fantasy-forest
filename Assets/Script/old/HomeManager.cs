using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    public void ChuyenCanh()
    {
        SceneManager.LoadScene(1);
    }

    public void ThoatGame()
    {
        Application.Quit();
    }
}
