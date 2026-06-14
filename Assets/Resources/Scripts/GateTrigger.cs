using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    public string gateAnswer;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CheckAnswer(gateAnswer);
        }
    }
}