using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))] // Instead of only checking ( Null Safety Checks )… you can ENFORCE components automatically
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [Header("Screen Boundaries")]
    [SerializeField] private float minX = -8f;
    [SerializeField] private float maxX = 8f;
    [SerializeField] private float minY = -4f;
    [SerializeField] private float maxY = 4f;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private GameManager gameManager;


    private Vector3 spawnPosition;


    private bool isAlive = true;
    public bool IsAlive => isAlive;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        gameManager = FindFirstObjectByType<GameManager>();

        // ✅ Null Safety Checks
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer is missing on Player!");
        }

        if (boxCollider2D == null)
        {
            Debug.LogError("BoxCollider2D is missing on Player!");
        }

        spawnPosition = transform.position;

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in scene!");
        }
    }

    private void Start()
    {
        Debug.Log("PlayerController attached and ready.");
    }

    private void Update()
    {
        if (isAlive)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            // Sans .normalized, en diagonale, le joueur irait plus vite.

            // Parce que le vecteur (1, 1) est plus long que (1, 0),
            // .normalized garde la même vitesse dans toutes les directions.
            Vector2 movementDirection = new Vector2(horizontalInput, verticalInput).normalized;

            transform.Translate(movementDirection * moveSpeed * Time.deltaTime);

            ClampPosition();
        }

    }

    private void ClampPosition()
    {
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX); // Take the `value`, but force it to stay between `min` and `max`.
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with an enemy!");

            // gameObject.SetActive(false); // Ça désactive le Player lorsqu’il touche l’ennemi. Donc visuellement, le Player disparaît. + update()ne plus execute.

            Die();
        }
    }

    private void Die()
    {
        isAlive = false;

        if (spriteRenderer != null)
            spriteRenderer.enabled = false;

        if (boxCollider2D != null)
            boxCollider2D.enabled = false;
        
        if (gameManager != null)
            gameManager.TriggerGameOver();
    }

}