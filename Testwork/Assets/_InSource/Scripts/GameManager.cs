using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameRunning = true;
    //public float worldScrollSpeed = 5f; // Общая скорость движения мира

    public void GameOver()
    {
        isGameRunning = false;
        // Остановить движение всех труб и фона
        // Можно найти все объекты с MoveLeft и ParallaxBackground и выключить их
        Time.timeScale = 0; // Самый простой способ остановить всю физику и движение
        Debug.Log("Game Over!");
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}