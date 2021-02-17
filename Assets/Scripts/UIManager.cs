using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider hpBar;
    [SerializeField] TextMeshProUGUI hpText;
    TestPlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<TestPlayerScript>();
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
    }
}
