using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyDeath death = collision.gameObject.GetComponent<EnemyDeath>();

            if (death != null)
            {
                death.Die(); // GameManagement çaðrýsý bunun içinde olacak!
            }
        }
    }
}
