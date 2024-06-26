using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTSMovement : MonoBehaviour
{
    public PlayerMovement playerMovement;         // Reference to the PlayerMovement script.
    private Rigidbody2D rb;                       // Rigidbody2D component of the player.
    private bool movingLeft;                      // Is the player moving left?
    private bool movingRight;                     // Is the player moving right?                      
    private SpriteRenderer srPlayer;              // The sprite renderer component of the player.
    private SpriteRenderer srLeg;                 // The sprite renderer component of the player's leg.
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        srPlayer = GetComponent<SpriteRenderer>();

        // Get the "Leg" child and its SpriteRenderer
        Transform legTransform = transform.Find("Leg");
        if (legTransform != null) {
            srLeg = legTransform.GetComponent<SpriteRenderer>();
            //Debug.Log("TS - Leg found!");
        }

        movingLeft = false;
        movingRight = false;
    }

    void Update() {
        if (movingLeft == true) {
            TSPlayerMoveLeft();
            srPlayer.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (movingRight == true) {
            TSPlayerMoveRight();
            srPlayer.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    // Touch screen left movement button.
    public void TSPlayerMoveLeft() {
        bool isTouchingWallLeft = playerMovement.CheckIfHitWall("left");

        if (!isTouchingWallLeft) {
            rb.velocity = new Vector2(-playerMovement.playerMoveSpeed, rb.velocity.y);
            // Flip the player, the player's leg to the LEFT side.
            srPlayer.flipX = true;
            srLeg.flipX = true;
            srLeg.transform.localPosition = new Vector2(-0.08f, -0.325f);
        }
    }

    // Touch screen right movement button.
    public void TSPlayerMoveRight() {
        bool isTouchingWallRight = playerMovement.CheckIfHitWall("right");

        if (!isTouchingWallRight && movingRight == true) {
            rb.velocity = new Vector2(playerMovement.playerMoveSpeed, rb.velocity.y);
            // Flip the player, the player's leg to the RIGHT side.
            srPlayer.flipX = false;
            srLeg.flipX = false;
            srLeg.transform.localPosition = new Vector2(0.08f, -0.325f);
        }
    }

    // Touch screen jump button.
    public void TSPlayerJump() {
        if (Mathf.Abs(rb.velocity.y) < 0.001f) {
            Vector2 jumpVelocity = new Vector2(0, playerMovement.playerJumpHeight);
            rb.velocity += jumpVelocity;
        }
    }

    public void StartMovingLeft() {
        movingLeft = true;
    }

    public void StopMovingLeft() {
        movingLeft = false;
    }

    public void StartMovingRight() {
        movingRight = true;
    }

    public void StopMovingRight() {
        movingRight = false;
    }
}
