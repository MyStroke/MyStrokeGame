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
    public float gameSpeedIncrement = 0.1f;
    public float gameSpeed {
        get;
        private set;
    }

    public void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy() {
        if (instance == this) {
            instance = null;
        }
    }

    private void Start() {
        NewGame();
    }

    private void NewGame() {
        gameSpeed = initialGameSpeed;
    }

    private void Update() {
        gameSpeed += gameSpeedIncrement * Time.deltaTime;
    }
}
