using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Skeleton : Entity, ITakeDamage, IAttack
{
    private Animator anim;
    private SpriteRenderer sprite; //To flip our monster if necessary 
    private AIPath aIPath; // Artificial intellegence library instance

    #region Health Settings

    [SerializeField] private float currentHealth;
    private bool isAlive;

    #endregion

    #region Attacking Settings

    [SerializeField, Header("How strong his attack is")] private float attackForce;
    [SerializeField, Header("From where he attack")] private Transform attackPos;
    [SerializeField, Header("How far he can hit")] private float attackRange;
    [SerializeField, Header("Who he can hit")] public LayerMask player;
    private bool isRecharged;

    #endregion

    #region Audio Settings
    [SerializeField, Header("Skeleton's movement sound")] private AudioSource motionSound;
    [SerializeField, Header("Skeleton's hitting sound")] private AudioSource hitSound;
    [SerializeField, Header("Skeleton's die sound")] private AudioSource dieSound;
    [SerializeField, Header("Skeleton's being hit sound")] private AudioSource beingHitSound;
    #endregion

    public static Skeleton Instance { get; set; }

    private IEnumerator Dying()
    {
        anim.SetBool("IsDead", true);
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("IsDead", false);
    }

    private IEnumerator IsBeingHit()
    {
        anim.SetBool("IsHit", true);
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("IsHit", false);
    }

    private IEnumerator Destroying()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(this.gameObject);
        PlayerData.Instance.killed++;
    }

    private IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("IsAttacking", false);
    }

    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(0.2f);
        isRecharged = true;
    }

    private void SetDefaultValues()
    {
        if (Instance == null) Instance = this;
        else if (Instance == this) Destroy(gameObject);
        isAlive = true;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        aIPath = GetComponent<AIPath>();
        isRecharged = true;
    }

    private void Awake()
    {
        SetDefaultValues();
    }

    public override void TakeDamage(float damage)
    {
        currentHealth -= damage;
        CheckIfIsAlive();
    }

    public override void CheckIfIsAlive()
    {
        if (currentHealth > 0)
        {
            isAlive = true;
            StartCoroutine(IsBeingHit());
        }

        else
        {
            isAlive = false;
            Die();
        }
    }
    public override void Die()
    {
        StartCoroutine(Dying());
        StartCoroutine(Destroying());
        
    }

    public void DyingSound()
    {
        dieSound.Play();
    }

    public void SkeletonMotion()
    {
        if(Mathf.Abs(aIPath.desiredVelocity.x) > 0)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        sprite.flipX = aIPath.desiredVelocity.x <= 0.0f;
    }

    public void Update()
    {
        SkeletonMotion();
        Attack();
    }

    public void Attack()
    {
        if(aIPath.TargetReached && isRecharged)
        {
            anim.SetBool("IsAttacking", true);
            isRecharged = false;
            StartCoroutine(AttackAnimation());
            StartCoroutine(AttackCoolDown());
        } 
    }
    public void PlayRunningSound()
    {
        motionSound.Play();
    }

    public void PlayBeingHitSound()
    {
        beingHitSound.Play();
    }

    public void OnAttack()
    {
        hitSound.Play();
        Character.Instance.TakeDamage(attackForce);
    }

}
