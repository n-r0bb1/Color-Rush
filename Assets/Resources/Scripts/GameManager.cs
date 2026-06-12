using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI ScoreText;

    private int score = 0;
    public int Score => score;
    public string correctAnswer;

    void Awake()
{
    Instance = this;
    Debug.Log("GameManager Awake on: " + gameObject.name, gameObject);
}

    public void CheckAnswer(string gateAnswer)
    {
        Debug.Log("CheckAnswer called with: " + gateAnswer);
        Debug.Log("Correct answer is: " + correctAnswer);

        if (gateAnswer == correctAnswer)
        {
            score++;
            Debug.Log("CORRECT! Score: " + score);
        }
        else
        {
            Debug.Log("WRONG!");
        }

        if (ScoreText != null)
            ScoreText.text = "Score = " + score;
        else
            Debug.LogError("ScoreText is not assigned in GameManager Inspector!");

        Debug.Log("Calling NextSet...");
        RoundManager.Instance.NextSet();
    }
}
