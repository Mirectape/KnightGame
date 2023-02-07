using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSurpriseEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] ememies;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            for (int i = 0; i < ememies.Length; i++)
            {
                ememies[i].SetActive(true);
            }
        }
    }
}
