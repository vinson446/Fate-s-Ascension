using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider hpBar;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] GameObject dialogueObj;
    [SerializeField] TextMeshProUGUI dialogueText;
    [TextArea(0, 10)]
    [SerializeField] string dialogue;
    [SerializeField] TextMeshProUGUI enemiesText;
    [SerializeField] TextMeshProUGUI enemiesKilledText;
    [SerializeField] GameObject endPanel;
    [SerializeField] TextMeshProUGUI endText;

    public int numEnemiesKilled;
    public int numEnemiesTotal;

    [SerializeField] Player player;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.TakeDamage(-30);
        }
    }

    void SetPlayerHealth()
    {
        hpBar.maxValue = player.HP;
        hpBar.value = hpBar.maxValue;

        hpText.text = hpBar.value + " / " + hpBar.maxValue;
    }

    public void UpdatePlayerHealth()
    {
        hpBar.value = player.HP;

        hpText.text = hpBar.value + " / " + hpBar.maxValue;

        if (hpBar.value <= 0)
        {
            EndGame(false);
        }
    }

    public void SetupEnemiesText()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        numEnemiesTotal = enemies.Length;

        enemiesKilledText.text = numEnemiesKilled.ToString() + " / "+ numEnemiesTotal.ToString();

        enemiesText.gameObject.SetActive(true);
        enemiesKilledText.gameObject.SetActive(true);
    }

    public void UpdateEnemiesText()
    {
        numEnemiesKilled++;

        enemiesKilledText.text = numEnemiesKilled.ToString() + " / " + numEnemiesTotal.ToString();

        if (numEnemiesKilled == numEnemiesTotal)
        {
            EndGame(true);
        }
    }

    public void ShowDialogue(bool show)
    {
        if (show)
        {
            dialogueObj.SetActive(true);
            dialogueText.text = dialogue;
        }
        else
        {
            dialogueObj.SetActive(false);
            dialogueText.text = "";
        }
    }

    void EndGame(bool win)
    {
        if (win)
        {
            endText.text = "MISSION COMPLETE";
        }
        else
        {
            endText.text = "MISSION FAILED";
        }

        endPanel.SetActive(true);
    }

    // buttons
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
