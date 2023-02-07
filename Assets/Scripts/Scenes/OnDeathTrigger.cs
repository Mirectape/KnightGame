using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            Character.Instance.isAlive = false;
        }
    }
}
