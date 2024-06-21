using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxShow : MonoBehaviour
{
    public GameObject box;

    // import all files
    private GameManager gameManager;
    private Countdown countdown;
    private RandomML randomML;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        countdown = FindObjectOfType<Countdown>();
        randomML = FindObjectOfType<RandomML>();

        box.SetActive(false);
    }

    void Update()
    {
        
    }

    public void ShowBox()
    {
        box.SetActive(true);
        countdown.TimerOn = true;
        gameManager.enabled = false;
        randomML.RandomMLBox();
    }
}
