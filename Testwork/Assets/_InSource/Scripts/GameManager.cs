using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameRunning = true;
    //public float worldScrollSpeed = 5f; // ����� �������� �������� ����

    public void GameOver()
    {
        isGameRunning = false;
        // ���������� �������� ���� ���� � ����
        // ����� ����� ��� ������� � MoveLeft � ParallaxBackground � ��������� ��
        Time.timeScale = 0; // ����� ������� ������ ���������� ��� ������ � ��������
        Debug.Log("Game Over!");
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}