using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    [SerializeField, Header("Explosion sound")] private AudioSource boomSound;

    public void PlayExplosion()
    {
        if(boomSound != null) boomSound.Play();
    }
}
