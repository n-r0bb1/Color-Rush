using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishZone : MonoBehaviour
{
    private bool ready = false;

    void Start()
    {
        Invoke(nameof(Activate), 2f);
    }

    void Activate() => ready = true;

    void OnTriggerEnter(Collider other)
    {
        if (!ready || !other.CompareTag("Player")) return;

        PlayerPrefs.SetInt("FinalScore", GameManager.Instance.Score);
        SceneManager.LoadScene("ResultScene");
    }
}
