using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private TrajectoryController trajectoryController;
    [SerializeField] private AudioClip croakSound;
    [SerializeField] private float launchPower = 5f;
    [SerializeField] private float maxLaunchForce = 10f;
    [SerializeField] private float fallThreshold = -10f;
    [SerializeField] private float velocityThreshold = 0.1f;
    [SerializeField] private float idleCheckDelay = 3f;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    private Vector3 startingPosition;
    private bool hasJumped = false;
    private bool alreadyChecked = false;
    private float idleTimer = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        rb.gravityScale = 0; // Ba�ta yer�ekimi olmas�n
    }

    private void OnMouseDown()
    {
        if (hasJumped) return;// zıplamıssa bir işlem yapma 

        startingPosition = transform.position;
        trajectoryController.ShowTrajectory(transform.position, Vector2.zero);
    }

    private void OnMouseDrag()
    {
        if (hasJumped) return;

        Vector3 destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        destination.z = 0;

        Vector3 direction = destination - startingPosition;
        float maxDistance = 1f;

        if (direction.magnitude > maxDistance)
            direction = direction.normalized * maxDistance;

        transform.position = startingPosition + direction;

        Vector3 pullDirection = startingPosition - transform.position;
        pullDirection = Vector3.ClampMagnitude(pullDirection, maxLaunchForce);
        trajectoryController.ShowTrajectory(transform.position, pullDirection * launchPower);
    }

    private void OnMouseUp()
    {
        if (hasJumped) return;

        trajectoryController.HideTrajectory();
        audioSource.PlayOneShot(croakSound);

        Vector3 releasePosition = transform.position;
        Vector3 direction = startingPosition - releasePosition;
        direction = Vector3.ClampMagnitude(direction, maxLaunchForce);

        rb.linearVelocity = direction * launchPower;
        rb.gravityScale = 1;

        hasJumped = true;
    }

    private void Update()
    {
        if (hasJumped)
        {
            if (rb.linearVelocity.magnitude < velocityThreshold)
            {
                idleTimer += Time.deltaTime;

                if (idleTimer >= idleCheckDelay && !alreadyChecked)
                {
                    alreadyChecked = true;
                    GameManagement.instance.PlayerStopped();
                }
            }
            else
            {
                idleTimer = 0f; // Hala hareket varsa s�reyi s�f�rla
            }
        }

        if (transform.position.y < fallThreshold)
        {
            GameManagement.instance.RestartGame();
        }
    }
}
