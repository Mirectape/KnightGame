using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour
{
    public GameObject explosion; // with an animation and the point effector working outward


    private void OnTriggerEnter2D(Collider2D wheelbarrow)
    {
        if (wheelbarrow.CompareTag("Wheelbarrow"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity); //Copy of the explosion animation
            gameObject.SetActive(false);
        }
    }
}
