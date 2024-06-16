using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {
        get;
        private set;
    }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrement = 1f;
    public float gameSpeed {
        get;
        private set;
    }

    private Player player;
    private Spawner spawner;

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

        NewGame();
    }

    // New Game
    private void NewGame() {
        Monsters[] monsters = FindObjectsOfType<Monsters>();

        foreach (var monster in monsters) {
            Destroy(monster.gameObject);
        }

        gameSpeed = initialGameSpeed;
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
    }

    // Game Over
    public void GameOver() {
        gameSpeed =  0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
    }
}
