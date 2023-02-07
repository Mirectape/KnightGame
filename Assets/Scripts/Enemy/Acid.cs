using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    [SerializeField, Header("Splash Sound")] private AudioSource splashSound;
    private bool inTheAcid;

    private void SetDefaultValues() => inTheAcid = false;
    private void Awake()
    {
        SetDefaultValues();
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (!player.CompareTag("Player") && splashSound != null)
        {
            splashSound.Play();
        }
        if(player.CompareTag("Player"))
        {
            inTheAcid = true;
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            inTheAcid = false;
        }
    }
    private void Drowning()
    {
        Character.Instance.TakeDamage(0.1f);
    }

    private void Update()
    {
        if (inTheAcid) Drowning();
    }
}
