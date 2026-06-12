using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultSceneManager : MonoBehaviour
{
    public TextMeshProUGUI ResultText;

    void Start()
    {
        int score = PlayerPrefs.GetInt("FinalScore", 0);
        string message;

        if (score <= 3)
    message = "Alex is still lost, and your help wasn't enough to guide him.\nHe had a dream, but it slipped away. Maybe try again with fresh eyes.\nScore: " + score + "/10";
else if (score <= 6)
    message = "You got Alex part of the way there, but the road ahead is still rough.\nHe appreciates the effort — it just wasn't quite enough to see his dream through.\nScore: " + score + "/10";
else if (score <= 9)
    message = "Alex is smiling! You helped him get close to where he always wanted to be.\nA couple of mistakes held him back from the top, but he's proud of how far he came.\nScore: " + score + "/10";
else
    message = "Alex did it! Every decision you made pushed him closer to his dream, and it paid off.\nHe couldn't have reached the top without you. A perfect run — well done.\nScore: " + score + "/10";

        ResultText.text = message;
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
