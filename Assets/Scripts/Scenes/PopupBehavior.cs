using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopupBehavior : MonoBehaviour
{
    public int nextLevel;
    public GameObject popupMenu;
    [SerializeField] private Text text; // text on the regular popUp
    [SerializeField] private Text achievementText; // text we give away as an achievement
    private float timeToAnalize; // To give achivements

    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            popupMenu.SetActive(true);
            Character.Instance.isActive = false;
            PlayerData.Instance.currentLevel = nextLevel;

            text.text = $"Time passed: {Mathf.Round(PlayerData.Instance.timePassed)} sec\n" +
                        $"Killed: {PlayerData.Instance.killed}\n" +
                        $"Secret chamber: {PlayerData.Instance.secretChamber}";
        }

        if(nextLevel == 0)
        {
            timeToAnalize = Mathf.Round(PlayerData.Instance.timePassed);
            AnalizeResults();
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void AnalizeResults()
    {
        if(timeToAnalize < 320 && PlayerData.Instance.secretChamber == "found")
        {
            achievementText.text = $"Your rank: 5/5\n" +
                                    $"Premature ejaculator";
        }
        else if(timeToAnalize < 410 && PlayerData.Instance.secretChamber == "found")
        {
            achievementText.text = $"Your rank: 4/5\n" +
                                    $"Sneaky bastard";
        }
        else if(timeToAnalize < 350 && PlayerData.Instance.secretChamber == "not found")
        {
            achievementText.text = $"Your rank: 3/5\n" +
                                    $"Skeleton's semen";
        }
        else if(timeToAnalize < 420 && PlayerData.Instance.secretChamber == "not found")
        {
            achievementText.text = $"Your rank: 2/5\n" +
                                    $"Sleepy hollow";
        }
        else if(PlayerData.Instance.secretChamber == "not found")
        {
            achievementText.text = $"Your rank: 1/5\n" +
                                    $"Mother nature's mistake";
        }
    }
}
