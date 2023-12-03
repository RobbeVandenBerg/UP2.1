using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Text mesh pro to display score
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI healthText;
    public GameObject player;
    public GameObject item;
    public GameObject enemy;
    public GameObject ground;
    public int score = 0;
    public int health = 3;

    // Music to play in the background and loop
    public AudioSource music;

    public float minDelay = 0.5f;
    public float maxDelay = 2.0f;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = health.ToString();
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // Spawn items and enemies at random times from 0.5 to 2 seconds
        if (timer > Random.Range(minDelay, maxDelay)) {
            SpawnItem();
            timer = 0.0f;
        }
        if (timer > Random.Range(minDelay, maxDelay)) {
            SpawnEnemy();
            timer = 0.0f;
        }
    }

    void SpawnItem() {
        // Spawn the item at a random location in the air above camera and let it fall to the ground
        float x = Random.Range(-10.0f, 10.0f);
        float y = 11.0f;
        Instantiate(item, new Vector3(x, y, 0.0f), Quaternion.identity);
    }

    void SpawnEnemy() {
        // Spawn the enemy at a random location in the air above camera and let it fall to the ground
        float x = Random.Range(-10.0f, 10.0f);
        float y = 11.0f;
        Instantiate(enemy, new Vector3(x, y, 0.0f), Quaternion.identity);
    }

    public void IncreaseScore() {
        // Increase the score by 1
        score++;
        scoreText.text = score.ToString();
    }

    public void DecreaseHealth() {
        // Decrease the health by 1
        health--;
        healthText.text = health.ToString();
        // If health is 0, end the game
        if (health == 0) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("gameover");
        }
    }
}
