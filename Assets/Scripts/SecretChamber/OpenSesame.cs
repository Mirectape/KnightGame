using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSesame : MonoBehaviour
{
    [SerializeField] GameObject cover;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cover.SetActive(false);
        PlayerData.Instance.secretChamber = "found";
    }

}
