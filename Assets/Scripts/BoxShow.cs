using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoxShow : MonoBehaviour
{
    // Get Game Object
    public GameObject box;
    public GameObject objBoss;
    public TextMeshProUGUI BossScoreText;

    // import all files
    private GameManager gameManager;
    private Countdown countdown;
    private RandomML randomML;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        countdown = FindObjectOfType<Countdown>();
        randomML = FindObjectOfType<RandomML>();
        countdown = FindObjectOfType<Countdown>();

        box.SetActive(false);
        objBoss.SetActive(false);
    }

    void Update()
    {
        // Update score boss
        if (countdown.bossSpawned) {
            BossScoreText.text = countdown.bossScore + " / 3";
        }
    }

    // Show Box
    public void ShowBox()
    {
        box.SetActive(true);
        objBoss.SetActive(false);
        countdown.TimerOn = true;
        gameManager.enabled = false;
        randomML.RandomMLBox();
    }

    // Show Box Boss
    public void ShowBoxBoss()
    {
        box.SetActive(true);
        objBoss.SetActive(true);
        countdown.TimerOn = true;
        gameManager.enabled = false;
        randomML.RandomMLBox();
    }
}
