using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Stats
    public float AttackStat = 3.5f;
    public float SpeedStat = 1.0f;
    public float SlashSpeed = 2.0f;
    public float LuckStat = 0.0f;
    public float RangeStat = 1.25f;

    public float SlashSpeedLimit = 30.0f;

    // Cosas generales

    public float health = 6f;
    public float armor = 0f;
    private float maxHealth = 12f;
    public int maxMana = 50;
    public int currentMana = 50;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private bool isJumping = false;
    public bool CanDoubleJump = false;

    private Rigidbody2D rb;
    public GameObject childObject; // Objeto hijo cuyo SpriteRenderer se modificará


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.X) && health > 0f)
        {
            health -= 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.C) && health < maxHealth)
        {
            health += 0.5f;
        }
    }

    void Update()
    {
        // Movimiento horizontal
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalInput, 0, 0) * Time.deltaTime * moveSpeed;

        // Flip sprite renderer del objeto hijo
        SpriteRenderer sr = childObject.GetComponent<SpriteRenderer>();
        if (horizontalInput < 0)
        {
            sr.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            sr.flipX = false;
        }

        // Salto
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }

        // Manejo de Mana
        if (currentMana < maxMana)
        {
            currentMana += 1;
        }

        // Limite duro de HP
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        // Limite duro de Velocidad
        if (SpeedStat > 12)
        {
            SpeedStat = 12;
        }
        else if (SpeedStat < 3)
        {
            SpeedStat = 3;
        }

        // Limite duro de Velocidad de Ataque
        if (SlashSpeed > SlashSpeedLimit)
        {
            SlashSpeed = SlashSpeedLimit;
        }
        else if (SlashSpeed < 0.1f)
        {
            SlashSpeed = 0.1f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}