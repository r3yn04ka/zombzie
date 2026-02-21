using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int selectedZombiePosition = 0;
    public GameObject selectedZombie;
    public List<GameObject> zombies;

    public Vector3 selectedSize = new Vector3(1.2f, 1.2f, 1.2f);
    public Vector3 defaultSize = new Vector3(1f, 1f, 1f);

    public TMP_Text scoreText;
    public TMP_Text timerText;
    public GameObject loseScreen;

    private int score = 0;
    private float startTime;
    private bool isGameOver = false;

    void Start()
    {
        SelectZombie(zombies[0]);
        scoreText.text = "Score: " + score;
        startTime = Time.time;
        if (loseScreen != null) loseScreen.SetActive(false);
    }

    void Update()
    {
        if (isGameOver) return;

        float t = Time.time - startTime;
        if (timerText != null) timerText.text = "Time: " + t.ToString("F2");
    }

    public void GetZombieLeft()
    {
        if (isGameOver) return;
        if (selectedZombiePosition == 0) SelectZombie(zombies[zombies.Count - 1]);
        else SelectZombie(zombies[selectedZombiePosition - 1]);
    }

    public void GetZombieRight()
    {
        if (isGameOver) return;
        if (selectedZombiePosition == zombies.Count - 1) SelectZombie(zombies[0]);
        else SelectZombie(zombies[selectedZombiePosition + 1]);
    }

    public void PushUp()
    {
        if (isGameOver || selectedZombie == null) return;
        Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
        rb.AddForce(0, 0, 10, ForceMode.Impulse);
    }

    void SelectZombie(GameObject newZombie)
    {
        if (selectedZombie) selectedZombie.transform.localScale = defaultSize;
        selectedZombie = newZombie;
        selectedZombie.transform.localScale = selectedSize;
        selectedZombiePosition = zombies.IndexOf(selectedZombie);
    }

    public void AddScore()
    {
        score++;
        if (scoreText != null) scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameOver = true;
        if (loseScreen != null) loseScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}