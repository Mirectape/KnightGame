using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    public float timePassed;
    public int killed;
    public string secretChamber;

    public int currentLevel;

    public static PlayerData Instance { get; set; }

    public void SetDefaultValues()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);

        timePassed = 0;
        killed = 0;
        secretChamber = "not found";
        currentLevel = 1;
    }

    private void Awake()
    {
        SetDefaultValues();
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
    }
}
