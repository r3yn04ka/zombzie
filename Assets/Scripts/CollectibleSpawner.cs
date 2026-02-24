using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject brainPrefab;
    public float interval = 3.0f;
    public Vector3 spawnOffset = new Vector3(0, 0.5f, 0);

    void Start()
    {
        InvokeRepeating("SpawnBrain", 1.0f, interval);
    }

    void SpawnBrain()
    {

        Vector3 localRandomPos = new Vector3(Random.Range(-4f, 4f), 0, Random.Range(-4f, 4f));

        Vector3 worldPos = transform.TransformPoint(localRandomPos) + spawnOffset;

        Instantiate(brainPrefab, worldPos, transform.rotation);
    }
}