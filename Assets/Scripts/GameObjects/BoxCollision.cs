using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollision : MonoBehaviour
{
    [SerializeField, Header("Box-drop sound")] private AudioSource boxDrop;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Box")
        {
            if(boxDrop != null) boxDrop.Play();
        }
    }
}
