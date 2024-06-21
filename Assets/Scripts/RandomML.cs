using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class RandomML : MonoBehaviour
{
    private string[] labels = {"FL", "Hc", "Hh", "LF", "OK", "PO", "RL", "TF", "Tu", "WBM", "Wd", "oP"};
    private static System.Random rnd = new System.Random();
    public string randomLabel;

    // Import all files
    private API data;

    // TextUI for ML
    public TextMeshProUGUI TextML;
    
    // Video
    // public VideoPlayer videoPlayer;

    // // Mapping of labels to video file paths
    // private Dictionary<string, string> labelToVideoPath = new Dictionary<string, string>();
    // public string[] videoFiles;

    void Start()
    {
        data = FindObjectOfType<API>();

        // Assuming videoFiles have been filled elsewhere or manually in the editor
        // Initialize labelToVideoPath mapping
        // InitializeVideoMapping();
    }

    // void InitializeVideoMapping()
    // {
    //     // Assuming videoFiles is already populated with paths like "../Assets/VideoHand/FL.mp4"
    //     foreach (string videoPath in videoFiles)
    //     {
    //         string fileName = Path.GetFileNameWithoutExtension(videoPath);
    //         if (Array.Exists(labels, label => label == fileName))
    //         {
    //             labelToVideoPath[fileName] = videoPath;
    //         }
    //     }
    // }

    public void RandomMLBox()
    {
        int randomIndex = RandomML2();
        randomLabel = labels[randomIndex];
        TextML.text = randomLabel;

        // Play the video corresponding to the random label
        // if (labelToVideoPath.TryGetValue(randomLabel, out string videoPath))
        // {
        //     videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoPath);
        //     videoPlayer.Play();
        // }
    }

    private int RandomML2()
    {
        return rnd.Next(labels.Length);
    }
}