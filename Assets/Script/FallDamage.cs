using UnityEngine;

public class FallDamage : MonoBehaviour
{
    [SerializeField] float minFallY = -10f;
    [SerializeField] float impactThreshold = 5f;

    private float maxFallSpeed = 0f;
    private Rigidbody2D rb;
    private EnemyDeath death;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        death = GetComponent<EnemyDeath>();
    }

    private void Update()
    {
        if (transform.position.y < minFallY && death != null)
        {
            death.Die();
        }

        if (rb != null && rb.linearVelocity.y < maxFallSpeed)
        {
            maxFallSpeed = rb.linearVelocity.y;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && death != null)
        {
            float etkiliHiz = Mathf.Abs(maxFallSpeed);
            if (etkiliHiz >= impactThreshold)
            {
                death.Die();
            }

            maxFallSpeed = 0f;
        }
    }
}
