using UnityEngine;

public class ModificarParametro : MonoBehaviour
{
   public PlayerProgressRegistry objetoConParametroBooleano;

    public void SetNewBool(bool newBool)
    {
        // Modificar el parámetro del otro script
        objetoConParametroBooleano.showPlayerStats = newBool;
    }
}
