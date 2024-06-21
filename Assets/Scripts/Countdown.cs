using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    // Count down timer
    public float TimeLeft = 10;
    public bool TimerOn = false;
    public TextMeshProUGUI TimerTxt;

    // import all files
    private GameManager gameManager;
    private RandomML randomML;
    private API data;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        data = FindObjectOfType<API>();
        randomML = FindObjectOfType<RandomML>();
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);

                if (data.GetPrediction() != null && data.GetPrediction() == randomML.randomLabel)
                {
                    gameManager.ContinueGame();
                }
            }
            else
            {
                TimeLeft = 10;
                TimerOn = false;
                gameManager.GameOver();
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00}", seconds);
        TimerTxt.text = TimerTxt.text + " s"; 
    }

}