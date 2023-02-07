using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenHatch : MonoBehaviour
{
    [SerializeField] private Animator hatch;

    private void OnTriggerEnter2D(Collider2D arrow)
    {
        if(arrow.CompareTag("Arrow"))
        {
            hatch.SetBool("isOpen", true);
        }
    }
}
