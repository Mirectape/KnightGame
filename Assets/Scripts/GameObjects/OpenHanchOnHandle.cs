using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenHanchOnHandle : MonoBehaviour
{
    [SerializeField] private Animator hatch;
    [SerializeField] private Animator handle;
    private bool playerIsInside;

    private void SetDefaultValues()
    {
        playerIsInside = false;
    }

    private void Awake()
    {
        SetDefaultValues();
    }

    private void OpenHatch()
    {
        handle.SetBool("isOpen", true);
        hatch.SetBool("isOpen", true);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.E) && playerIsInside)
        {
            OpenHatch();
        }
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            playerIsInside = true;
        }
    }


    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            playerIsInside = false;
        }
    }
}
