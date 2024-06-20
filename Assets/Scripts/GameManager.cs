using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrement = 1f;
    public float gameSpeed { get; private set; }

    // Get Game Object
    public TextMeshProUGUI gameOverText; // Game Over
    public TextMeshProUGUI scoreUpdate; // Score
    public Button retryButton; // Retry Button

    // Get all files
    private Player player;
    private Spawner spawner;
    private BoxShow boxShow;
    private Countdown countdown;

    private float score;

    // Awake
    public void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            DestroyImmediate(gameObject);
        }
    }

    // OnDestroy
    private void OnDestroy() {
        if (instance == this) {
            instance = null;
        }
    }

    // Start Game
    private void Start() {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        boxShow = FindObjectOfType<BoxShow>();
        countdown = FindObjectOfType<Countdown>();

        NewGame();
    }

    // New Game
    public void NewGame() {
        Monsters[] monsters = FindObjectsOfType<Monsters>();

        foreach (var monster in monsters) {
            Destroy(monster.gameObject);
        }

        score = 0f;
        gameSpeed = initialGameSpeed;
        enabled = true;

        player.animator.Play("HeroKnight_Run");
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
    }

    // Game Over
    public void GameOver() {
        gameSpeed =  0f;
        enabled = false;

        player.animator.Play("HeroKnight_death");
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        boxShow.box.SetActive(false);
    }

    // Update
    private void Update() {
        score += gameSpeed * Time.deltaTime;
        scoreUpdate.text = $"{score:0}";
    }

    // Popup box for prediction
    public void BoxProcess() {
        gameSpeed = 0f;
        spawner.gameObject.SetActive(false);
        boxShow.ShowBox();
        countdown.TimerOn = true;
    }
}
