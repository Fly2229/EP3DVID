using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrationManager : MonoBehaviour
{
    public Animator animator;  // Asigna el Animator del personaje en el Inspector.
    private string[] celebrationAnimations = { "Celebrate" };

    // Llama a esta función cuando el personaje complete una tarea.
    public void Celebrate()
    {
        // Elegir una animación al azar de la lista.
        string randomAnimation = celebrationAnimations[Random.Range(0, celebrationAnimations.Length)];

        // Activar la animación.
        animator.Play(randomAnimation);
    }
}