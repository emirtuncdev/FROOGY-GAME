using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public enum Axis { X, Y }

    [Header("Hareket Ayarlarý")]
    [SerializeField] private Axis hareketYonu = Axis.X;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 3f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float hareket = Mathf.PingPong(Time.time * speed, distance) - (distance / 2f);

        if (hareketYonu == Axis.X)
        {
            transform.position = new Vector3(startPos.x + hareket, startPos.y, startPos.z);
        }
        else if (hareketYonu == Axis.Y)
        {
            transform.position = new Vector3(startPos.x, startPos.y + hareket, startPos.z);
        }
    }
}

