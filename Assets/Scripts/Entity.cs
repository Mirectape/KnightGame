using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, ITakeDamage
{
    public virtual void TakeDamage(float damage)
    {

    }

    public virtual void CheckIfIsAlive()
    {
       
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
