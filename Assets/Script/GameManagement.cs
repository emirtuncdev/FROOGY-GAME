using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public static GameManagement instance;

    private int totalEnemies = 0;
    private int deadEnemies = 0;
    private bool playerStopped = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Invoke(nameof(CountEnemies), 0.5f); // Düşmanlar sahneye gelsin
    }

    private void CountEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        totalEnemies = enemies.Length;
        Debug.Log("Toplam düşman: " + totalEnemies);
    }

    public void EnemyKilled()
    {
        deadEnemies++;
        Debug.Log("Düşman öldü: " + deadEnemies + "/" + totalEnemies);

        if (deadEnemies >= totalEnemies && playerStopped)
        {
            LoadNextLevel();
        }
    }

    public void PlayerStopped()
    {
        playerStopped = true;

        if (deadEnemies >= totalEnemies)
        {
            LoadNextLevel();
        }
        else
        {
            Debug.Log("Düşman kaldı → sahne restart");
            RestartGame();
        }
    }

    private void LoadNextLevel()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Tüm düşmanlar öldü → Bir sonraki sahneye geç");
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.Log("Son sahneydi → Menüye dön");
            SceneManager.LoadScene(0); // Menü sahnesi
        }
    }

    public void RestartGame()
    {
        Debug.Log("Sahne yeniden başlatılıyor...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
