using UnityEngine; 
using System.Collections;
using System;
using UnityEngine.Networking;
using TMPro;
using SimpleJSON;
public class API: MonoBehaviour {
    [SerializeField] TextMeshProUGUI PredictionText;
    private const string URL = "http://209.15.117.50/api";
    private string[] labels = {"FL", "Hc", "Hh", "LF", "OK", "PO", "RL", "TF", "Tu", "WBM", "Wd", "oP"};
    public void GenerateRequest (byte[] ImageByte) {
        WWWForm form = new WWWForm();
        form.AddBinaryData("image", ImageByte, "image.png", "image/png");
        StartCoroutine (ProcessRequest (URL, form));
    }

    private IEnumerator ProcessRequest (string uri, WWWForm Images) {
        using (UnityWebRequest request = UnityWebRequest.Post (uri,Images)) {
            request.SetRequestHeader("Access-Control-Allow-Origin", "*");
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError) {
                Debug.Log (request.error);
            } else {
                JSONNode prediction = JSON.Parse(request.downloadHandler.text);
                if (prediction["prediction"] == null) {
                    Debug.Log("Error");
                    PredictionText.text = "Null";
                    yield break;
                }
                string pred = labels[(int) prediction["argmax"]];
                PredictionText.text = pred;
                Debug.Log((string) prediction["argmax"]+" - "+pred);
            }
        }
    }

    public string GetPrediction(){
        return PredictionText.text;
    }
}