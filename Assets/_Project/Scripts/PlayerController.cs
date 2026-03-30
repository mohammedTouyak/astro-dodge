using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [Header("Screen Boundaries")]
    [SerializeField] private float minX = -8f;
    [SerializeField] private float maxX = 8f;
    [SerializeField] private float minY = -4f;
    [SerializeField] private float maxY = 4f;

    private void Start()
    {
        Debug.Log("PlayerController attached and ready.");
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Sans .normalized, en diagonale, le joueur irait plus vite.

        /* #Parce que le vecteur (1, 1) est plus long que (1, 0).
        .normalized corrige ça et garde la même vitesse dans toutes les directions. */
        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput).normalized;

        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);

        ClampPosition();
    }

    private void ClampPosition()
    {
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX); // Take the `value`, but force it to stay between `min` and `max`.
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}