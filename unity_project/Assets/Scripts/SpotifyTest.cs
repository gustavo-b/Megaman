using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SpotifyTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(GetRequest("https://api.spotify.com/v1/me/player/currently-playing?access_token=BQBKiqJTDKpn-Ftbi7GwjYGQaZeCnHm_B2FylFFtHYMU0KM9QQlUYwfQGyWkoy7tHK63_n8Hnqy1fszwDlGPjTEt8-b_RLoYRIloZ1Rd7XXOVJMkhHjuZOOP0WkEpwHZzj_gK3iD8n2-6SHZQKa_GC4"));
    }

    IEnumerator GetRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }

    IEnumerator PostRequest(string url, string json)
    {
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
}
