using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float jump;
    public float mileStone;
    public float speedMultiplier;
    public LayerMask ground;
    public AudioSource deathSound;
    public AudioSource jumpSound;

    private float mileStoneCount;
    private Rigidbody2D rigidBody;
    private Collider2D playerCollider;
    private Animator animator;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        mileStoneCount = mileStone;
    }
    void Update()
    {

        if (transform.position.x > mileStoneCount) {
            mileStoneCount += mileStone;
            speed = speed * speedMultiplier;
            mileStone += mileStone * speedMultiplier;
        }

        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);

        bool grounded = Physics2D.IsTouchingLayers(playerCollider, ground);

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
            if (grounded) {
                jumpSound.Play();
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jump);
            }
        }

        animator.SetBool("Grounded", grounded);
    }
}
