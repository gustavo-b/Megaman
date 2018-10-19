using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;

public class SpotifyTest : MonoBehaviour
{
    public static int songType = 1;
    private string trackId = "";
    private string currentJson = "";

    // Use this for initialization
    void Start()
    {
        StartCoroutine(GetRequest("https://accounts.spotify.com/authorize/?client_id=dc7407dc1c2042be8a8f5f78d6ccd3ad&response_type=code&redirect_uri=https%3A%2F%2Fwww.getpostman.com%2Foauth2%2Fcallback&scope=user-read-currently-playing&state=myDiggersby007"));
        InvokeRepeating("UpdateSong", 0.1f, 1.0f);
    }

    void UpdateSong()
    {
        StartCoroutine(GetRequest("https://api.spotify.com/v1/me/player/currently-playing?access_token=BQDUlL529ElaNuQq6dBccRo8KhPPe-Cu-8ge5VA-u5mVv2jX4wZWe-8gTOedqpAzDg9-O3eVgwSYjPVj1i-tNqeTF6chSw7iR-SWQJYgKavv9sI6brtPgt__UySpO7HCu5OMEhw9GSPPp194ULokeFI&grant_type=refresh_token&refresh_token=AQDgKzP43xNRdpA6ke3YFyfmO75rAhxn7lwD4UQmsF-EJeZyDSXbJcGBld2qJxGSTPRfMVdVBjjmeH7wB1rIn61951oGJcnEUmpJdNdDVvd6UCykH8zmK01jvYWaEgcDrFqBeA"));
        GetSongData();
    }

    void GetSongData()
    {
        var obj = JObject.Parse(this.currentJson);
        if (this.trackId != (string)obj["item"]["id"] || this.trackId.Equals(""))
        {
            this.trackId = (string)obj["item"]["id"];
            StartCoroutine(GetRequest("https://api.spotify.com/v1/audio-features/" + this.trackId + "?access_token=BQDUlL529ElaNuQq6dBccRo8KhPPe-Cu-8ge5VA-u5mVv2jX4wZWe-8gTOedqpAzDg9-O3eVgwSYjPVj1i-tNqeTF6chSw7iR-SWQJYgKavv9sI6brtPgt__UySpO7HCu5OMEhw9GSPPp194ULokeFI&grant_type=refresh_token&refresh_token=AQDgKzP43xNRdpA6ke3YFyfmO75rAhxn7lwD4UQmsF-EJeZyDSXbJcGBld2qJxGSTPRfMVdVBjjmeH7wB1rIn61951oGJcnEUmpJdNdDVvd6UCykH8zmK01jvYWaEgcDrFqBeA"));
            obj = JObject.Parse(this.currentJson);
            if ((float)obj["energy"] < 0.3f)
            {
                songType = 3;
            } else if ((float)obj["energy"] >= 0.3f && (float)obj["energy"] < 0.5f)
            {
                songType = 2;
            } else if ((float)obj["energy"] >= 0.5f && (float)obj["energy"] < 0.7f)
            {
                songType = 4;
            } else
            {
                songType = 2;
            }
        }
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
            this.currentJson = uwr.downloadHandler.text;
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
