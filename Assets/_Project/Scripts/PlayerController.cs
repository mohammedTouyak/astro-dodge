using UnityEngine;

public class PlayerController : MonoBehaviour
{
     [SerializeField] private float moveSpeed = 5f;

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
    }
}