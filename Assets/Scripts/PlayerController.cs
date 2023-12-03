using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Jasper Was Here


public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;
    public float inputx;
    Rigidbody2D rb;
    Vector3 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void FixedUpdate() {
        inputx = Input.GetAxis("Horizontal");
        movement = new Vector3(inputx, 0.0f, 0.0f);
        rb.AddForce(movement * speed);
    }

    // Check for collisions with items and enemies
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Item") {
            // Increase score
            GameObject.Find("SceneManager").GetComponent<SceneManager>().IncreaseScore();
            // Destroy the item
            Destroy(col.gameObject);
        } else if (col.gameObject.tag == "Enemy") {
            // Destroy the enemy
            Destroy(col.gameObject);
            // Lose Health
            GameObject.Find("SceneManager").GetComponent<SceneManager>().DecreaseHealth();
        }
    }
}
