using UnityEngine;
using System.Collections;
public class GlitchEffect : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float glitchDuration = 0.1f;
    public float glitchIntensity = 0.1f;

    private float glitchTimer;
    private bool isGlitching;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartGlitchEffect();
        }

        if (isGlitching)
        {
            glitchTimer -= Time.deltaTime;
            if (glitchTimer <= 0f)
            {
                StopGlitchEffect();
            }
        }
    }

    private void StartGlitchEffect()
    {
        if (!isGlitching)
        {
            isGlitching = true;
            glitchTimer = glitchDuration;
            StartCoroutine("GlitchCoroutine");
        }
    }

    private void StopGlitchEffect()
    {
        isGlitching = false;
        spriteRenderer.material.SetFloat("_GlitchIntensity", 0f);
    }

    private IEnumerator GlitchCoroutine()
    {
        while (isGlitching)
        {
            float randomIntensity = Random.Range(-glitchIntensity, glitchIntensity);
            spriteRenderer.material.SetFloat("_GlitchIntensity", randomIntensity);

            yield return null;
        }
    }
}
