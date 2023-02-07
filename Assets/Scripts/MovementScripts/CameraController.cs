using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Animator cameraController;

    private void Awake()
    {
        cameraController = GetComponent<Animator>();
    }

    public void StartCutScene()
    {
        cameraController.SetBool("Cutscene1", true);
    }

    public void EndCutScene()
    {
        cameraController.SetBool("Cutscene1", false);
    }
}
