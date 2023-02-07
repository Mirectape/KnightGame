using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMusic : MonoBehaviour
{
    [SerializeField, Header("Final music")] private AudioSource finalMusic;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            ActivateFinalMusic();
            Destroy(gameObject);
        }
    }

    private void ActivateFinalMusic()
    {
        finalMusic.Play();
    }
}
