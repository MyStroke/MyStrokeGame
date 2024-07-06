using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using TMPro;
using SimpleJSON;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class API : MonoBehaviour {
    [SerializeField] TextMeshProUGUI PredictionText;
    private const string URL = "https://www.mystroke-api.org/api";
    private string[] labels = {"FL", "Hc", "Hh", "LF", "OK", "PO", "RL", "TF", "Tu", "WBM", "Wd", "oP"};
    private string[] labelsTH = {"ท่าชูนิ้ว 3 นิ้ว", "ท่างอนิ้ว", "ท่ากำมือ", "ท่าชูนิ้วก้อย", "ท่าทางตกลง", "ท่าชี้นิ้ว", "ท่าผ่อนคลายนิ้วมือ", "ท่าเก็บนิ้วโป้ง", "ท่ายกนิ้วโป้ง", "การเคลื่อนไหวของข้อมืองอ", "ท่าแบมือประสานนิ้ว", "ท่าแบมือ"};

    public void GenerateRequest(byte[] ImageByte) {
        WWWForm form = new WWWForm();
        form.AddBinaryData("image", ImageByte, "image.png", "image/png");
        StartCoroutine(ProcessRequest(URL, form));
    }

    private IEnumerator ProcessRequest(string uri, WWWForm Images) {
        using (UnityWebRequest request = UnityWebRequest.Post(uri, Images)) {
            request.SetRequestHeader("Access-Control-Allow-Origin", "*");

            // Ignore SSL certificate errors (for debugging purposes)
            request.certificateHandler = new BypassCertificate();

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError) {
                Debug.Log(request.error);
            } else {
                JSONNode prediction = JSON.Parse(request.downloadHandler.text);
                if (prediction["prediction"] == null) {
                    Debug.Log("Null");
                    PredictionText.text = "Null";
                    yield break;
                }
                int predIndex = prediction["argmax"].AsInt;
                if (predIndex >= 0 && predIndex < labels.Length) {
                    string pred = labels[predIndex];
                    PredictionText.text = pred;
                    Debug.Log(predIndex + " - " + pred);
                } else {
                    Debug.Log("Invalid prediction index received");
                }
            }
        }
    }

    public string GetPrediction() {
        return PredictionText.text;
    }

    // Custom certificate handler to bypass SSL certificate validation
    private class BypassCertificate : CertificateHandler {
        protected override bool ValidateCertificate(byte[] certificateData) {
            // Always return true to bypass SSL certificate validation
            return true;
        }
    }
}
