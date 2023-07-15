using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedAttack : MonoBehaviour
{
    public Animation finishOrabortAnimation;
    public float timer = 0f;
    public float threshold = 1f;
    public PrefabGenerator prefabManager;

    public bool WithBrimstone;

    void ChargeAttackUp()
    {
        while (Input.GetKeyDown(KeyCode.Z) && timer == 0f)
        {
            timer += Time.deltaTime;
            if (timer > threshold)
            {
                finishOrabortAnimation.Play();
                timer = 0f;
                prefabManager.AttackOnDemand();
            }
            else
            {
                finishOrabortAnimation.Play();
                timer = 0f;

                prefabManager.AttackOnDemand();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChargeAttackUp();
    }
}
