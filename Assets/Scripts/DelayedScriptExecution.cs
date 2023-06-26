using UnityEngine;

public class DelayedScriptExecution : MonoBehaviour
{
    public MonoBehaviour scriptToExecute;
    public float delayTime = 2f;

    private void Start()
    {
        Invoke("ExecuteScript", delayTime);
    }

    private void ExecuteScript()
    {
        if (scriptToExecute != null)
        {
            scriptToExecute.enabled = true;
        }
    }
}
