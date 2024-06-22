using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomML : MonoBehaviour
{
    private string[] labels = { "FL", "Hc", "Hh", "LF", "OK", "PO", "RL", "TF", "Tu", "WBM", "Wd", "oP" };
    private static System.Random rnd = new System.Random();
    public string randomLabel;
    private Animator animator;

    // Import all files
    private API data;

    // TextUI for ML
    public TextMeshProUGUI TextML;
    public Image ImageML;

    void Start()
    {
        data = FindObjectOfType<API>();
        animator = ImageML.GetComponent<Animator>();
    }

    public void RandomMLBox()
    {
        int randomIndex = RandomML2();
        randomLabel = labels[randomIndex];
        TextML.text = randomLabel;
        animator.Play(randomLabel);
    }

    private int RandomML2()
    {
        return rnd.Next(labels.Length);
    }
}
