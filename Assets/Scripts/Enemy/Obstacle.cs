using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField, Header("Damage it causes the player")] private float damage;
    
    /// <summary>
    /// If the players collides with the obstacle his health falls by the damage margin
    /// </summary>
    /// <param name="collision"></param>
    /// 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Character.Instance.gameObject)
        {
                Character.Instance.TakeDamage(damage);
        }
    }
}
