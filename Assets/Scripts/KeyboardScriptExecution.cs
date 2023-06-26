using UnityEngine;

public class KeyboardScriptExecution : MonoBehaviour
{
    public MonoBehaviour scriptToExecute;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            ExecuteScript();
        }
    }

    private void ExecuteScript()
    {
        if (scriptToExecute != null)
        {
            scriptToExecute.enabled = true;
        }
    }
}
