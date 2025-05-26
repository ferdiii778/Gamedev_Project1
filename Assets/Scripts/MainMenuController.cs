using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Fungsi untuk tombol START
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame"); // Pastikan "MainGame" sudah ada di Build Settings
    }

    // Fungsi untuk tombol LEVEL
    public void OpenLevel()
    {
        SceneManager.LoadScene("LevelSelect"); // Ganti sesuai nama scene level kamu
        Debug.Log("Level scene belum tersedia.");
    }

    // Fungsi untuk tombol EXIT
    public void ExitGame()
    {
        Debug.Log("Keluar dari game...");
        Application.Quit(); // Ini hanya akan bekerja saat game sudah dibuild
    }
}
