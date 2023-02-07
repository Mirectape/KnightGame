using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Character player;
    [SerializeField] private int deathMenu;

    private void CheckOnGameOver()
    {
        if (!player.isAlive)
        {
            SceneManager.LoadScene(deathMenu);
        }
    }

    private void Update()
    {
        CheckOnGameOver();
    }
}
