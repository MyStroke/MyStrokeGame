using System.Collections.Generic; 
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
    private Player player;
    private BoxShow boxShow;

    // Setting
    public bool bossSpawned = false;
    public int timeCurrent = 10;
    public int bossScore = 0;

    // Score Output
    public Dictionary<string, int> scoreOutput = new Dictionary<string, int>();

    void Start() {
        gameManager = FindObjectOfType<GameManager>();
        data = FindObjectOfType<API>();
        randomML = FindObjectOfType<RandomML>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (TimerOn)
        {
            // Check if the boss is spawned
            if (!bossSpawned) {
                if (TimeLeft > 0) {
                    TimeLeft -= Time.deltaTime;
                    updateTimer(TimeLeft);

                    if (data.GetPrediction() != null && data.GetPrediction() == randomML.randomLabel)
                    {
                        // Store the prediction in scoreOutput and increment the score
                        string prediction = data.GetPrediction();
                        if (scoreOutput.ContainsKey(prediction)) {
                            scoreOutput[prediction] += 1;
                        } else {
                            scoreOutput[prediction] = 1;
                        }

                        player.animator.Play("HeroKnight_Run");
                        updateTimer(timeCurrent - 1);
                        TimerOn = false;
                        gameManager.ContinueGame();

                        // Reset the timer
                        TimeLeft = timeCurrent;
                    }
                } else {
                    TimeLeft = 10;
                    TimerOn = false;
                    gameManager.GameOver();
                }
            }
            else {
                if (TimeLeft > 0) {
                    TimeLeft -= Time.deltaTime;
                    updateTimer(TimeLeft);

                    if (data.GetPrediction() != null && data.GetPrediction() == randomML.randomLabel)
                    {
                        // Store the prediction in scoreOutput and increment the score
                        string prediction = data.GetPrediction();
                        if (scoreOutput.ContainsKey(prediction)) {
                            scoreOutput[prediction] += 1;
                        } else {
                            scoreOutput[prediction] = 1;
                        }

                        int acttackIndex = player.RandomAttack();
                        player.animator.Play(player.attackList[acttackIndex]);

                        // Check if the boss is defeated
                        bossScore += 1;
                        randomML.RandomMLBox();

                        if (bossScore >= 3) {
                            player.animator.Play("HeroKnight_Run");
                            updateTimer(timeCurrent - 1);
                            TimerOn = false;
                            gameManager.ContinueGame();

                            // Reset the timer
                            TimeLeft = timeCurrent;

                            // Reset the boss info
                            bossScore = 0;
                            bossSpawned = false;
                        }
                        else {
                            // Reset the timer
                            TimeLeft = timeCurrent;
                            updateTimer(timeCurrent - 1);
                        }
                    }
                } else {
                    TimeLeft = 10;
                    TimerOn = false;
                    gameManager.GameOver();
                }
            }
        }
    }

    // Update Timer
    public void updateTimer(float currentTime) {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00}", seconds);
        TimerTxt.text = TimerTxt.text + " s"; 
    }
}
