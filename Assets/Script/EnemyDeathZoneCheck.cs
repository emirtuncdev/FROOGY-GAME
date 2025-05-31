using UnityEngine;
public class NewMonoBehaviourScript : MonoBehaviour
{
   

    public float fallLimitY = -10f; // d��erse bu noktadan, otomatik �ls�n

    private EnemyDeath death;

    private void Start()
    {
        death = GetComponent<EnemyDeath>();
    }

    private void Update()
    {
        if (transform.position.y < fallLimitY)
        {
            if (death != null)
            {
                death.Die();
            }
        }
    }
}


