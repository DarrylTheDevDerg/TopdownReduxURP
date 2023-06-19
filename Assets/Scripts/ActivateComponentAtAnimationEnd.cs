using UnityEngine;

public class ActivateComponentAtAnimationEnd : MonoBehaviour
{
    public Animator animator;
    public MonoBehaviour scriptToActivate;

    void Start()
    {
        // Obtén una referencia al componente Animator
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Verifica si la animación ha llegado al final
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            // Activa el script deseado en el otro objeto
            scriptToActivate.enabled = true;
        }
    }
}
