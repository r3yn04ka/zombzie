using UnityEngine;

public class Brain : MonoBehaviour
{
    public GameManager gameManager;
    public AudioClip hit;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        if (gameManager == null) gameManager = FindFirstObjectByType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddScore();
            if (hit != null && source != null) source.PlayOneShot(hit);
            Destroy(gameObject);
        }
    }
}