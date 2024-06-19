using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxShow : MonoBehaviour
{
    public GameObject box;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        box.SetActive(false);
    }

    void Update()
    {
        
    }

    public void ShowBox()
    {
        box.SetActive(true);
        gameManager.enabled = false;
    }
}
