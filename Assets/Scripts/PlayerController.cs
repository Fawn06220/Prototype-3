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
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!isJumping && context.performed)
        {
            addForce();
        }

    }
    private void OnCollisionEnter(Collision col)
    {
        isJumping = false;
    }
    private void addForce()
    {
        Debug.Log("saute");
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJumping = true;
    }
}
