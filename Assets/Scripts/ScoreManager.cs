using UnityEngine;
using TMPro; // <== penting untuk TMP_Text

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text scoreText; // Pakai TMP_Text, bukan Text biasa
    private int score = 0;

    private void Awake()
    {
        // Singleton pattern biar bisa diakses dari Collectible.cs
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddPoint()
    {
        score++;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogWarning("⚠️ ScoreText belum di-assign ke ScoreManager!");
        }
    }
}
