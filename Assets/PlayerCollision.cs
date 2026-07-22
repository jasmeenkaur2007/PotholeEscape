using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public ScoreManager scoreManager;
    public AudioSource crashSound;
    public AudioSource engineSound;

    private bool hasCrashed = false;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && !hasCrashed)
        {
            hasCrashed = true;

            // Stop engine sound
            if (engineSound != null)
                engineSound.Stop();

            // Play crash sound
            if (crashSound != null)
                crashSound.Play();

            // Stop score
            scoreManager.StopScore();

            // Show Game Over
            gameOverText.gameObject.SetActive(true);

            // Stop car movement
            GetComponent<PlayerMovement>().enabled = false;

            // Restart game after 5 seconds
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}