using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private GameObject deathEffectPrefab;
    private AudioSource source;
    [SerializeField] private AudioClip deathSound;

    private bool isDead = false;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Die()
    {
        if (isDead) return; // zaten ölüyorsa tekrar çalışmasın
        isDead = true;

        if (deathEffectPrefab != null)
        {
            GameObject effect = Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }

        if (deathSound != null && source != null)
        {
            source.PlayOneShot(deathSound);
        }

        // 🔥 Sayacı sadece burada artırıyoruz!
        GameManagement.instance.EnemyKilled();

        Destroy(gameObject, 0.3f);
    }
}