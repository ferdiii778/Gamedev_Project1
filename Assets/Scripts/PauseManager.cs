using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button pauseButton;
    public Button resumeButton;
    public Button restartButton;

    void Start()
    {
        pauseMenu.SetActive(false);

        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
        restartButton.onClick.AddListener(RestartGame);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        Debug.Log("Waktu dihentikan: " + Time.timeScale);
        pauseMenu.SetActive(true);
    }


    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // penting: restart harus reset timeScale
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f; // Pastikan waktu kembali normal sebelum keluar
        SceneManager.LoadScene("MainMenu"); // Ganti dengan nama scene MainMenu kamu
    }

}
