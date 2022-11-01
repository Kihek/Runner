using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    float highscore;

    public GameObject Menu;
    public GameObject Record;
    public Text HighScore;

    public void YesB()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NoB()
    {
        SceneManager.UnloadScene("SampleScene");
        SceneManager.LoadScene("Menu");
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Rec()
    {
        Menu.SetActive(false);
        Record.SetActive(true);
        highscore = PlayerPrefs.GetFloat("score");
        HighScore.text = "Лучший счет: " + highscore + " очков.";
    }
    
    public void OkB()
    {
        Menu.SetActive(true);
        Record.SetActive(false);
    }
}
