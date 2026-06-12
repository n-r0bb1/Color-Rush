using UnityEngine;
using TMPro;
using System.Linq;

public class RoundManager : MonoBehaviour
{
    public static RoundManager Instance;
    public GameObject[] gateSets;

    private string[] photoNames_rg = { "7", "11", "13", "14", "17", "26", "33", "49", "58", "64", "78", "88", "97", "98", "99" };
    private string[] photoNames_bg = { "3", "9", "11", "13", "14", "22", "31", "44", "51", "52", "60", "68", "72", "89", "93" };

    private string[] CurrentPhotoNames => PlayerPrefs.GetString("PhotoMode", "RG") == "RG" ? photoNames_rg : photoNames_bg;
    private string PhotoFolder => "Photos/" + PlayerPrefs.GetString("PhotoMode", "RG") + "/";

    private int currentSet = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < gateSets.Length; i++)
            gateSets[i].SetActive(i == 0);

        NewRound();
    }

    public void NewRound()
    {
        if (currentSet >= gateSets.Length)
        {
            Debug.Log("Game Over!");
            return;
        }

        gateSets[currentSet].SetActive(true);

        string[] photoNames = CurrentPhotoNames;
        string randomName = photoNames[Random.Range(0, photoNames.Length)];
        GameManager.Instance.correctAnswer = randomName;
        Debug.Log("Correct answer this round: " + randomName);

        foreach (Transform child in gateSets[currentSet].GetComponentsInChildren<Transform>())
        {
            if (child.CompareTag("PhotoDisplay"))
            {
                Texture2D photo = Resources.Load<Texture2D>(PhotoFolder + randomName);
                if (photo != null)
                    child.GetComponent<Renderer>().material.mainTexture = photo;
                break;
            }
        }

        GateTrigger[] triggers = gateSets[currentSet].GetComponentsInChildren<GateTrigger>()
            .OrderBy(t => t.transform.parent.GetSiblingIndex()).ToArray();
        TextMeshPro[] labels = gateSets[currentSet].GetComponentsInChildren<TextMeshPro>()
            .OrderBy(l => l.transform.parent.GetSiblingIndex()).ToArray();

        Debug.Log("Triggers found: " + triggers.Length);
        Debug.Log("Labels found: " + labels.Length);

        int correctGate = Random.Range(0, 3);
        for (int i = 0; i < 3; i++)
        {
            string answer = (i == correctGate) ? randomName : GetWrongAnswer(randomName, photoNames);
            labels[i].text = answer;
            triggers[i].gateAnswer = answer;
        }
    }

    public void NextSet()
    {
        gateSets[currentSet].SetActive(false);
        currentSet++;
        NewRound();
    }

    string GetWrongAnswer(string exclude, string[] photoNames)
    {
        string wrong;
        do {
            wrong = photoNames[Random.Range(0, photoNames.Length)];
        } while (wrong == exclude);
        return wrong;
    }
}
