using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;

    void Start()
    {
        // Hide Game Over text when game starts
        gameOverText.gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Show Game Over text
            gameOverText.gameObject.SetActive(true);

            // Stop player movement
            GetComponent<PlayerMovement>().enabled = false;

            // Restart game after 5 seconds
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}