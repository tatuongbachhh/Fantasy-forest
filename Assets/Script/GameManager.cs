using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject scoreBoard; //bảng góc trái
    public GameObject scoreBoardDead; //bảng giữa màn hình

    public TextMeshProUGUI scoreText;// ở góc bên trái
    public TextMeshProUGUI scoreTextDead; //score ở bảng giữa màn hình
    public TextMeshProUGUI highscoreTextDead; //highscore ở bảng giữa màn hình



    private int score = 0;
    public int highScore = 0; //điểm cao nhất chơi được
    
    private void Start()
    {
        LoadGame();
        SetScoreText();
    }

    public void SaveGame()
    {
        string maHoa = Extension.Encrypt(highScore.ToString(), "LapTrinhGame2");
        PlayerPrefs.SetString("diem", maHoa);
    }

    public void LoadGame()
    {
        string loadData = PlayerPrefs.GetString("diem");
        if (!string.IsNullOrEmpty(loadData))
        {
            string giaiMa = Extension.Decrypt(loadData, "LapTrinhGame2");
            highScore = int.Parse(giaiMa);
        }
    }

    public void AddScore()
    {
        score++;
    }
    public void AddScoreads()
    {
        score+= 100;
        scoreText.text = "Score: " + score.ToString("n0");
    }


    public void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString("n0");
    } 

    public void PlayerDead()
    {
        if(score > highScore)
        {
            highScore = score;
            SaveGame();
        }

        scoreBoard.SetActive(false); //ẩn bảng góc trái
        scoreBoardDead.SetActive(true); //hiện bảng ở giữa màn hình

        scoreTextDead.text = "Score: " + score.ToString("n0");
        highscoreTextDead.text = "Highscore: " + highScore.ToString("n0");
    }

    public void ButtonPlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonHome()
    {
        SceneManager.LoadScene(0);
    }
    public int GetScore()
    {
        return score;
    }

    public void TruScore()
    {
        score--;
        scoreText.text = "Score: " + score.ToString("n0");
    }
  
}
