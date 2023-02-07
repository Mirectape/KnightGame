using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Character : Entity, ITakeDamage, IAttack
{
    public bool isActive;
    [SerializeField] Animator bloodEffect;
    private PlayerMovement movementCharacteristics; //Class that describes the player's motion
    private Animator anim;

    #region Health Settings

    public bool isAlive { get; set; } // On false close the gameWindow
    [SerializeField] private float maxHealth;
    private float currentHealth;

    #endregion

    #region Attacking Settings

    [SerializeField, Header("How strong attack is")] private float attackForce;
    [SerializeField, Header("From where we attack")] private Transform attackPos;
    [SerializeField, Header("How far we can hit")] private float attackRange;
    [SerializeField, Header("Who we can hit")] private LayerMask enemy;
    private bool isRecharged = true;
    #endregion

    #region Audio Sources
    [Header("Sounds: ")]
    [SerializeField] private AudioSource attackSound;
    [SerializeField] private AudioSource beingHurt;

    #endregion

    public static Character Instance { get; set; }

    private IEnumerator BeingHit()
    {
        anim.SetBool("IsHit", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("IsHit", false);
    }

    private IEnumerator Dying()
    {
        anim.SetBool("IsDead", true);
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("IsDead", false);
    }

    private IEnumerator Destroying()
    {
        yield return new WaitForSeconds(1.1f); // Not less time to let a dying animation play
        isAlive = false;
    }

    private IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("IsAttacking", false);
    }

    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        isRecharged = true;
    }

    private void SetDefaultValues()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        movementCharacteristics = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        isActive = true;
        isAlive = true;
        isRecharged = true;
        bloodEffect.enabled = false; // We don't want to shed blood with no cause at the beginning
    }

    private void Awake()
    {
        SetDefaultValues();
    }
    
    public override void TakeDamage(float damage)
    {
        bloodEffect.enabled = true;
        currentHealth -= damage;
        bloodEffect.Rebind(); // Since each time an anim stops at its end we should wind it back before playing
        bloodEffect.Play("BloodShed");
        beingHurt.Play();
        CheckIfIsAlive();
    }

    public void TakeHealth()
    {
        currentHealth = maxHealth;
    }

    public override void CheckIfIsAlive()
    {
        if (currentHealth > 0)
        {
            StartCoroutine(BeingHit());
        }
            
        else
        {
            Die();
        }
    }

    public override void Die()
    {
        StartCoroutine(Dying());
        StartCoroutine(Destroying());
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void Attack()
    {
        if(movementCharacteristics.isOnGround && isRecharged && isActive)
        {
            anim.SetBool("IsAttacking", true);
            isRecharged = false;
            attackSound.Play();
            StartCoroutine(AttackAnimation());
            StartCoroutine(AttackCoolDown());
        }
    }

    public void OnAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponentInParent<Entity>().TakeDamage(attackForce);
        }
    }

    private void OnDrawGizmosSelected()
    {
        #region Attacking Sphere / Shows attacking range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
        #endregion
    }

    private void Update()
    {
        if(Input.GetButtonDown(GlobalStringVars.ATTACK))
        {
            Attack();
        }
    }
}
