using UnityEngine;

public class ActivateAnimatorTrigger : MonoBehaviour
{
    public Animator animator;
    public string triggerName = "YourTriggerName";

    void Start()
    {
        // Obtén una referencia al componente Animator
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Activa el trigger del Animator
        animator.SetTrigger(triggerName);
 
    }
}
