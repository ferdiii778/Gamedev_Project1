using UnityEngine;

public class Collectible : MonoBehaviour
{
    bool collected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return; // Cegah dobel ambil
        if (other.CompareTag("Player"))
        {
            collected = true;

            // Tambah skor
            ScoreManager.instance.AddPoint();
            // Hancurkan item
            Destroy(gameObject);
        }
    }
}
