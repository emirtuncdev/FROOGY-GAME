using UnityEngine;
public class NewMonoBehaviourScript : MonoBehaviour
{
   

    public float fallLimitY = -10f; // düþerse bu noktadan, otomatik ölsün

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


