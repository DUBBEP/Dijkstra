using UnityEngine;

public class Duck : MonoBehaviour
{
    public ArriveSeparator Ai;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Ai.enabled = true;
        }
    }
}
