using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckIfAroundHandle : MonoBehaviour
{
    [Header("Check if the player is inside the area to pull the handle")] public bool playerIsInside;
    [SerializeField, Header("UI, What the player needs to do")] private GameObject instructions;

    private void Awake()
    {
        playerIsInside = false;
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            playerIsInside = true;
            instructions.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            playerIsInside = false;
            instructions.SetActive(false);
        }       
    }
}
