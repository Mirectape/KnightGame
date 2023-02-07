using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public void ReplayLevel()
    {
        SceneManager.LoadScene(PlayerData.Instance.currentLevel);
    }

    public void BackToMainMenu()
    {
        PlayerData.Instance.SetDefaultValues();
        PlayerData.Instance.currentLevel--;
        SceneManager.LoadScene(PlayerData.Instance.currentLevel);
    }
}
