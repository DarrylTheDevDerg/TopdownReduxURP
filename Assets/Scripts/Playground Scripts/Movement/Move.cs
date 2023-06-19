using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Move With Arrows")]
[RequireComponent(typeof(Rigidbody2D))]
public class Move : Physics2DObject
{
	[Header("Input keys")]
	public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;

	[Header("Movement")]
	[Tooltip("Speed of movement")]
	public float speed = 5f;
	public Enums.MovementType movementType = Enums.MovementType.AllDirections;

	[Header("Orientation")]
	public bool orientToDirection = false;
	// The direction that will face the player
	public Enums.Directions lookAxis = Enums.Directions.Up;

	private Vector2 movement, cachedDirection;
	private float moveHorizontal;
    //private float moveVertical;

    [Header("Jump setup")]
    // the key used to activate the push
    public KeyCode key = KeyCode.Space;

    // strength of the push
    public float jumpStrength = 10f;

    [Header("Ground setup")]
    //if the object collides with another object tagged as this, it can jump again
    public string groundTag = "Ground";

    //this determines if the script has to check for when the player touches the ground to enable him to jump again
    //if not, the player can jump even while in the air
    public bool checkGround = true;

    private bool canJump = true;

    public bool hasSecondJump = false;
    private bool canSecondJump = false;


    // Update gets called every frame
    void Update ()
	{

        if (canJump
            && Input.GetKeyDown(key) || canSecondJump && hasSecondJump && Input.GetKeyDown(key))
        {
            // Apply an instantaneous upwards force
            rigidbody2D.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            if (!canJump)
            {
                canSecondJump = false;
            }
            canJump = !checkGround;
        }

        // Moving with the arrow keys
        if (typeOfControl == Enums.KeyGroups.ArrowKeys)
		{
            moveHorizontal = (Input.GetKey(KeyCode.RightArrow)? -1 : 0) + (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0);
		}
		else
		{
            moveHorizontal = (Input.GetKey(KeyCode.A) ? -1 : 0) + (Input.GetKey(KeyCode.D) ? 1 : 0);
		}
	}



	// FixedUpdate is called every frame when the physics are calculated
	void FixedUpdate ()
	{
        movement = new Vector2(moveHorizontal, 0);
        // Apply the force to the Rigidbody2d
        rigidbody2D.velocity = movement * speed * 10f;
	}

    private void OnCollisionEnter2D(Collision2D collisionData)
    {
        if (checkGround
            && collisionData.gameObject.CompareTag(groundTag))
        {
            canJump = true;
            canSecondJump = true;
        }
    }
}