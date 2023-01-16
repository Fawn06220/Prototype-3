using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float gravityModifier;
    private bool isJumping = false;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!isJumping && context.performed && !gameOver)
        {
            addForce(playerRb, Vector3.up);
            isJumping = true;
            dirtParticle.Stop();
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        //ajout du non Gameover pour stopper effets de particules
        if (col.gameObject.CompareTag("Ground") && !gameOver)
        {
            onGround();
        }
        if (col.gameObject.CompareTag("Obstacle"))
        {
            youLose();
        }
    }
    void addForce(Rigidbody rb, Vector3 vec)
    {
        rb.AddForce(vec * jumpForce, ForceMode.Impulse);    
    }
    void youLose()
    {
        gameOver = true;
        dirtParticle.Stop();
        playerAudio.PlayOneShot(crashSound, 1.0f);
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 1);
        explosionParticle.Play();
        Debug.Log("GAME OVER !!!");
    }
    void onGround()
    {
        isJumping = false;
        dirtParticle.Play();
    }
}
