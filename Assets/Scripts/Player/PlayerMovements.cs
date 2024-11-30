using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed;

    private Rigidbody rb;
    public GameStateManager gameStateManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        gameStateManager = FindFirstObjectByType<GameStateManager>();
    }

    private void Update()
    {
        if (gameStateManager != null && gameStateManager.isWin)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }

        HandleMovement();
    }

    private void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, 0, z) * speed;
        rb.linearVelocity = movement;
    }
}
