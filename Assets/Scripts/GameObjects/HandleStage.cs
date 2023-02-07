using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleStage : MonoBehaviour
{
    [SerializeField, Header("Camera behavior anim")] private Animator cameraControl;
    [SerializeField, Header("Set the area where the player can operate the handle")] private CheckIfAroundHandle conditions;
    [SerializeField, Header("GameObject you want to manipulate through the same stages")] private Animator platform;
    [SerializeField, Header("Mechanism sound")] private AudioSource mechanismSound;
    private Animator handle;
    private int currentStage;

    private void SetDefaulValues()
    {
        currentStage = 0;
        handle = GetComponent<Animator>();
        handle.SetInteger("Stage", currentStage);
        platform.SetInteger("Stage", currentStage);
    }

    private void ChangeStage()
    {
        if (mechanismSound != null) mechanismSound.Play();
        Character.Instance.isActive = false; // The player cannot move while stage is changing
        if (currentStage == 4) currentStage = 1;
        else currentStage++;
        handle.SetInteger("Stage", currentStage);
        platform.SetInteger("Stage", currentStage);
    }

    private void StartCutScene()
    {
        cameraControl.SetBool("Cutscene1", true);
        Invoke(nameof(StopCutScene), 3f);
    }

    private void StopCutScene()
    {
        cameraControl.SetBool("Cutscene1", false);
        Character.Instance.isActive = true; // By the end of the cutscene we allow the player move
    }

    private void Awake()
    {
        SetDefaulValues();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && conditions.playerIsInside && Character.Instance.isActive)
        {
            ChangeStage();
        }
    }
}
