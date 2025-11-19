using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverMenu; 
    public void EnableGameOverMenu()
    {
        if (gameOverMenu.activeSelf) return; 

        gameOverMenu.SetActive(true);
        Debug.Log("GameOverScreen: Menampilkan Game Over UI.");

        Time.timeScale = 0f;
    }
    public void Menu()
    {
        SceneManager.LoadScene("Loby");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}