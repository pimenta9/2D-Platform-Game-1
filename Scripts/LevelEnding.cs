using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnding : MonoBehaviour
{
    private AudioSource endingSoundEffect;

    private bool levelCompleted = false;

    private void Start()
    {
        endingSoundEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            endingSoundEffect.Play();
            Invoke("CompleteLevel", 2f);
            levelCompleted = true;
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
