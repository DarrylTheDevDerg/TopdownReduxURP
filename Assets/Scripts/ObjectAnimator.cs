using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnimator : MonoBehaviour
{
    public Animator animator;
    public string moveTriggerName = "Move";
    public string randomTriggerName = "Random";

    public float staticThreshold = 0.01f;
    public float randomTriggerInterval = 3f;

    private float timer = 0f;
    private bool isMoving = false;

    private void Update()
    {
        // Detect movement
        if (transform.hasChanged)
        {
            isMoving = true;
            transform.hasChanged = false;
            timer = 0f;
        }
        else
        {
            isMoving = false;
        }

        animator.SetBool(moveTriggerName, isMoving);

        // Activate random trigger if static based on the timer
        if (!isMoving)
        {
            timer += Time.deltaTime;

            if (timer >= randomTriggerInterval)
            {
                ActivateRandomTrigger();
                timer = 0f;
            }
        }
    }

    private void ActivateRandomTrigger()
    {
        int randomTriggerIndex = Random.Range(0, animator.parameterCount);

        if (animator.parameters[randomTriggerIndex].type == AnimatorControllerParameterType.Trigger)
        {
            string randomTrigger = animator.parameters[randomTriggerIndex].name;
            animator.SetTrigger(randomTriggerName);
        }
    }
}
