using UnityEngine;

public class FallDamageKutu : MonoBehaviour
{
    [SerializeField] private float fallDamageThreshold = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                float impactSpeed = Mathf.Abs(rb.linearVelocity.y);

                if (impactSpeed >= fallDamageThreshold)
                {
                    EnemyDeath death = collision.gameObject.GetComponent<EnemyDeath>();
                    if (death != null)
                    {
                        death.Die(); // Efekt + yok etme i�lemi
                    }
                }
            }
        }
    }
}
