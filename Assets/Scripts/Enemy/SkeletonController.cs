using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SkeletonController : MonoBehaviour
{
    [SerializeField] GameObject a_Pathway;
    [SerializeField] AIPath[] skeletonMind;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            a_Pathway.SetActive(true);
            for (int i = 0; i < skeletonMind.Length; i++)
            {
                if (skeletonMind[i] != null) skeletonMind[i].enabled = true;
            }
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            for (int i = 0; i < skeletonMind.Length; i++)
            {
                if(skeletonMind[i] != null) skeletonMind[i].enabled = false;
            }
            a_Pathway.SetActive(false);
        }
    }
}
