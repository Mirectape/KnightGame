using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, ICharacterMovement
{
    #region JUMP SETTINGS

    [Range(1, 10)]
    [SerializeField, Header("How hard the Player jumps")] private float jumpForce; //Force with which the Player jumps

    [SerializeField, Header("Jump sound: ")] private AudioSource jumpSound;
    [SerializeField, Header("Landing sound: ")] private AudioSource landingSound;

    [Range(0.0f, 2.0f)]
    [SerializeField, Header("Circle's radius to indicate the Player is landed")] private float jumpOffSet; 
    // The radius of a circle we draw to indicate the Player is landed when it's intertwined with the ground

    [SerializeField, Header("Is the Player on the ground?")] public bool isOnGround; // If the Player is on the ground
    private bool isAboutToLand;

    [SerializeField, Header("The center's position of the Player's ground collider")] private Transform groundColliderTransform;

    [SerializeField, Header("Only 'Ground' can interact with the Player")] private LayerMask groundMask; 
    // Only layers with the LayerMask labeled 'Ground' can interact with the player
    #endregion

    #region HORIZONTAL MOVEMENT SETTINGS

    [Range(1,10)]
    [SerializeField, Header("The Player's horizontal movement speed")] private float speed;
    [SerializeField, Header("The Player's movement sounds")] private AudioSource motionSound;
    [SerializeField, Header("The Player's horizontal movement behavior")] AnimationCurve motionCurve;

    #endregion 

    private Rigidbody2D rigidbody; // We use rigidbody velocity component to move the player around
    private SpriteRenderer sprite; // We get an access to sprite to flip the player if he goes in another direction
    private Animator anim;

    private void SetDefaultValues()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        isAboutToLand = false;
    }
        
    
    /// <summary>
    /// Shows how the Player moves
    /// </summary>
    /// <param name="movement"></param>
    /// <param name="isJumpButtonPressed"></param>
    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed) Jump();

        if (Mathf.Abs(direction) > 0.0001f) HorizontalMove(direction);
        else anim.SetBool("IsRunning", false);

        sprite.flipX = direction < 0.0f; //To turn sprite in another direction
    }

    /// <summary>
    /// Describes the Player's jump abliities
    /// </summary>
    public void Jump()
    {
        if (isOnGround)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            jumpSound.Play();
        }
    }

    /// <summary>
    /// Describes when the Player is allowed to jump
    /// </summary>
    public void JumpConditions()
    {
        //true if the drawn cyrcle intersects the ground, false otherwise 
        isOnGround = Physics2D.OverlapCircle(groundColliderTransform.position, jumpOffSet, groundMask);
        if (isOnGround)
        {
            anim.SetBool("IsJumping", false);
        }
        else
        { 
            anim.SetBool("IsJumping", true);
            isAboutToLand = true;
        }
    }

    private void CheckLandingSoundCondtions()
    {
        if(isOnGround)
        {
            landingSound.Play();
            isAboutToLand = false;
        }
    }

    /// <summary>
    /// Describes the Player's motion along the ground
    /// </summary>
    public void HorizontalMove(float direction)
    {
        rigidbody.velocity = new Vector2(motionCurve.Evaluate(direction), rigidbody.velocity.y);
        if (isOnGround)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        { 
            anim.SetBool("IsRunning", false); 
        }
    }

    public void PlayRunningSound()
    {
        motionSound.Play();
    }

    private void Awake()
    {
        SetDefaultValues();
    }

    private void FixedUpdate()
    {
        JumpConditions();
        if(isAboutToLand) CheckLandingSoundCondtions();
    }
}
