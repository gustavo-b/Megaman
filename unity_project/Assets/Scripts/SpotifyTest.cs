using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SpotifyTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(GetRequest("https://accounts.spotify.com/authorize/?client_id=dc7407dc1c2042be8a8f5f78d6ccd3ad&response_type=code&redirect_uri=https%3A%2F%2Fwww.getpostman.com%2Foauth2%2Fcallback&scope=user-read-currently-playing&state=myDiggersby007"));
        StartCoroutine(GetRequest("https://api.spotify.com/v1/me/player/currently-playing?access_token=<acces_token que é pego no primeiro exchange>&grant_type=refresh_token&refresh_token=<refresh_token que é pego no primeiro exchange>"));
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
            Application.OpenURL();
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
