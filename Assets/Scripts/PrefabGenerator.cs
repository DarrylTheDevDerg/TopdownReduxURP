using UnityEngine;

public class PrefabGenerator : MonoBehaviour
{
    public GameObject prefab;
    public float delay = 1f;
    private float rangeStat = 1.0f;
    private float timer = 0f;
    public Vector3 offset;

    private void Start()
    {
        // Retrieve the RangeStat value from PlayerPrefs
        if (PlayerPrefs.HasKey("Range Stat on Run"))
        {
            rangeStat = PlayerPrefs.GetFloat("Range Stat on Run", 1.25f);
        }

        if (PlayerPrefs.HasKey("Slash Speed Stat on Run"))
        {
            delay = PlayerPrefs.GetFloat("Slash Speed Stat on Run", 2.0f);
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
            bool isFlipped = transform.GetComponent<SpriteRenderer>().flipX;
            

            // Check if the parent object is flipped on the X axis
            if (isFlipped)
            {
                // Flip the scale of the generated prefab on the X axis
                Vector3 newScale = newPrefab.transform.localScale;
                newScale.x *= -1f;
                newPrefab.transform.localScale = newScale;

                newPrefab.transform.position += offset;

                // Get the sprite renderer of the prefab
                SpriteRenderer spriteRenderer = newPrefab.GetComponent<SpriteRenderer>();

                // Get the child sprite renderer if present
                SpriteRenderer childSpriteRenderer = newPrefab.GetComponentInChildren<SpriteRenderer>();
            }

            // Reset the timer
            timer = 0f;
        }
    }
}
