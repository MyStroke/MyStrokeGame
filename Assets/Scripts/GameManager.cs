using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
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

    private int score = 0;

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

        score = 0;
        gameSpeed = initialGameSpeed;
        enabled = true;

        player.animator.Play("HeroKnight_Run");
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        // Timer
        countdown.TimerOn = true;
        countdown.TimeLeft = 10;
        countdown.TimerOn = false;
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
        scoreUpdate.text = score.ToString("D3");
    }

    // Popup box for prediction
    public void BoxProcess() {
        gameSpeed = 0f;
        spawner.gameObject.SetActive(false);
        boxShow.ShowBox();
        countdown.TimerOn = true;
    }

    // Destroy Monsters
    public void DestroyMonsters()
    {
        Monsters[] monsters = FindObjectsOfType<Monsters>();

        foreach (var monster in monsters)
        {
            Destroy(monster.gameObject);
        }

    }

    // Continue Game
    public void ContinueGame()
    {
        gameSpeed = initialGameSpeed;
        enabled = true;
        countdown.TimerOn = false;
        player.animator.Play("HeroKnight_Run");
        score += 1;
        DestroyMonsters();
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        boxShow.box.SetActive(false);
        countdown.TimeLeft = 10;
    }
}
