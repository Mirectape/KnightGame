using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRubeGoldberg : MonoBehaviour
{
    [SerializeField, Header("Camera behavior anim")] private Animator cameraControl;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            cameraControl.SetBool("Cutscene2", true);
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            cameraControl.SetBool("Cutscene2", false);
        }
    }
}
