using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        if (gameManager == null) gameManager = FindFirstObjectByType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.GameOver();
        }
    }
}