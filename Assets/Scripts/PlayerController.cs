using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{

    // Stats
    public float AttackStat = 3.5f;
    public float SpeedStat = 1.0f;
    public float SlashSpeed = 7.5f;
    public float LuckStat = 0.0f;
    public float RangeStat = 1.25f;

    public float SlashSpeedLimit = 0.15f;

    // Cosas generales

    public float health = 4f;
    public float armor = 0f;
    public int maxMana = 50;
    public int currentMana = 50;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private bool isJumping = false;
    public bool CanDoubleJump = false;

    private Rigidbody2D rb;
    public GameObject childObject; // Objeto hijo cuyo SpriteRenderer se modificar�
    public Animator animator;
    public string triggerName;
    public Animation hurtAnimation;

    public AudioClip[] audioClips;
    public AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (PlayerPrefs.HasKey("Attack Stat on Run"))
        {
            AttackStat = PlayerPrefs.GetFloat("Attack Stat on Run", 3.5f);
        }

        if (PlayerPrefs.HasKey("Speed Stat on Run"))
        {
            SpeedStat = PlayerPrefs.GetFloat("Speed Stat on Run", 1.0f);
            moveSpeed = moveSpeed * SpeedStat;
        }

        if (PlayerPrefs.HasKey("Slash Speed Stat on Run"))
        {
            SlashSpeed = PlayerPrefs.GetFloat("Slash Speed Stat on Run", 7.5f);
        }

        if (PlayerPrefs.HasKey("Luck Stat on Run"))
        {
            LuckStat = PlayerPrefs.GetFloat("Luck Stat on Run", 0.0f);
        }

        if (PlayerPrefs.HasKey("Range Stat on Run"))
        {
            RangeStat = PlayerPrefs.GetFloat("Range Stat on Run", 1.25f);
        }

        // Obtener o agregar el componente AudioSource al objeto
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
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
    }

    public void PlayAudioClip(int clipIndex)
    {
        // Verificar si el índice es válido
        if (clipIndex >= 0 && clipIndex < audioClips.Length)
        {
            // Establecer el audio clip correspondiente al índice
            audioSource.clip = audioClips[clipIndex];

            // Reproducir el audio clip
            audioSource.Play();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            PlayAudioClip(0);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        PlayAudioClip(1);
        animator.SetTrigger(triggerName);

        if (health <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    public void RecoverHealth(float recoverAmount)
    {
        health += recoverAmount;
    }
}