using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Toggle RGCheckBox;
    public Toggle BGCheckBox;

    void Start()
    {
        string saved = PlayerPrefs.GetString("PhotoMode", "RG");
        RGCheckBox.isOn = saved == "RG";
        BGCheckBox.isOn = saved == "BG";
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Exited");
    }

    public void GoToInfo()
    {
        SceneManager.LoadScene("InfoScene");
    }

    public void OnRGToggle(bool value)
    {
        if (value)
            PlayerPrefs.SetString("PhotoMode", "RG");
    }

    public void OnBGToggle(bool value)
    {
        if (value)
            PlayerPrefs.SetString("PhotoMode", "BG");
    }
}
