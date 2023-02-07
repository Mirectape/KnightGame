using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestGivesHealth : MonoBehaviour
{
    [SerializeField, Header("ChestOpen sound")] AudioSource chestOpen;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            anim.SetBool("isOpen", true);
            Character.Instance.TakeHealth();
            if (chestOpen != null) chestOpen.Play();
        }
    }
}
