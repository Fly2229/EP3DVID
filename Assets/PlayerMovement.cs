using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public CelebrationManager celebrationManager;
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;
    public float jumpForce = 10f; // Fuerza de salto
    public LayerMask groundLayer; // Capa para detectar el suelo

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        // Obtener el componente Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Obtener la entrada del jugador
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular la dirección de movimiento en base a la entrada
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Mover el personaje
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);

        // Rotar el personaje hacia la dirección de movimiento
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        isGrounded = Physics.CheckSphere(transform.position, 0.5f, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }
   
    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto con el que colisionamos tiene el tag "Collectible"
        if (other.CompareTag("Collectible"))
        {
            // Destruir el objeto para simular que se ha recogido
            Destroy(other.gameObject);

            celebrationManager.Celebrate();


            // Aquí puedes añadir más lógica, como aumentar puntos, reproducir un sonido, etc.
            Debug.Log("Esfera recogida!");
        }
    }

}