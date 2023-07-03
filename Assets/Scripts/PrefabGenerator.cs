using UnityEngine;

public class PrefabGenerator : MonoBehaviour
{
    public GameObject prefab;
    public float delay = 1f;
    private float rangeStat = 1.0f;
    private float timer = 0f;

    private void Start()
    {
        // Retrieve the RangeStat value from PlayerPrefs
        if (PlayerPrefs.HasKey("Range Stat"))
        {
            rangeStat = PlayerPrefs.GetFloat("Range Stat");
        }
    }

    private void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        if (timer >= delay && Input.GetKeyDown(KeyCode.Z))
        {
            // Calculate the position of the prefab considering the RangeStat value
            float offsetX = rangeStat * (transform.localScale.x > 0f ? 1f : -1f);
            Vector3 spawnPosition = transform.position + new Vector3(offsetX, 0f, 0f);

            GameObject newPrefab = Instantiate(prefab, spawnPosition, Quaternion.identity);

            // Get the parent object's scale
            Vector3 parentScale = transform.localScale;

            // Check if the parent object is flipped on the X axis
            if (parentScale.x < 0f)
            {
                // Flip the scale of the generated prefab on the X axis
                Vector3 newScale = newPrefab.transform.localScale;
                newScale.x *= -1f;
                newPrefab.transform.localScale = newScale;

                // Get the sprite renderer of the prefab
                SpriteRenderer spriteRenderer = newPrefab.GetComponent<SpriteRenderer>();

                // Flip the sprite renderer's sprite
                spriteRenderer.flipX = true;

                // Get the child sprite renderer if present
                SpriteRenderer childSpriteRenderer = newPrefab.GetComponentInChildren<SpriteRenderer>();

                // Flip the child sprite renderer's sprite
                if (childSpriteRenderer != null)
                {
                    childSpriteRenderer.flipX = true;
                }
            }

            // Reset the timer
            timer = 0f;
        }
    }
}
