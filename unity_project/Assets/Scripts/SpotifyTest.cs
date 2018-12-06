using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using SimpleJSON;
using System;
using System.IO;

public class SpotifyTest : MonoBehaviour
{
    public static int songType = 1;
    private string trackId = "";
    private string loginHtml = "";
    private string songJson = "";
    private string audioFeaturesJson = "{\"energy\": 1.0}";
    private string accessToken = "";
    private string songName = "";
    private TrackDisplay trackDisplay;

    //private string refreshToken = "AQCRT0kkkxqBWqhHIUMnrKpzMlKAMlDf_PkkLrrW7gevnvDkSbeNdxbcsFgCmVQYVVQ4l-mtPrsv4N6af4kvAWA_jI-eRs85pIU4V5jcJzgGgNdUDdYplaq-UoxCBECkWI694A";

    // Use this for initialization
    void Start()
    {
        //var isLogin = 0;
        //Application.OpenURL("https://accounts.spotify.com/authorize?client_id=dc7407dc1c2042be8a8f5f78d6ccd3ad&response_type=code&redirect_uri=http%3A%2F%2F127.0.0.1%3A8080/callback&scope=user-read-currently-playing");
        //StartCoroutine(GetRequest("https://accounts.spotify.com/authorize/?client_id=dc7407dc1c2042be8a8f5f78d6ccd3ad&response_type=code&redirect_uri=http%3A%2F%2F127.0.0.1%3A8080/callback&scope=user-read-currently-playing", isLogin));
        StartCoroutine(PostRequest("https://accounts.spotify.com/api/token",
            "grant_type=authorization_code&code=" + AuthorizationCode() + "&redirect_uri=http%3A%2F%2F127.0.0.1%3A8080%2Fcallback&client_id=dc7407dc1c2042be8a8f5f78d6ccd3ad&client_secret=567a65fdb0e840b9ac943cf61c11f818"));
        InvokeRepeating("UpdateSong", 1.0f, 1.5f);
    }

    void UpdateSong()
    {
        var isSong = 1;
        StartCoroutine(GetRequest("https://api.spotify.com/v1/me/player/currently-playing?access_token=" + accessToken, isSong));
    }
    
    void GetSongData()
    {
        var isAudioFeatures = 2;
        var obj = JSON.Parse(this.songJson);
        if (!this.trackId.Equals(obj["item"]["id"].Value) || this.trackId.Equals(""))
        {
            this.trackId = obj["item"]["id"].Value;
            this.songName = obj["item"]["name"].Value;
            Debug.Log(this.trackId);
            Debug.Log("NOME DA MUSICA: " + songName);
            trackDisplay = GameObject.Find("DisplaySpotify").GetComponent<TrackDisplay>();
            trackDisplay.setSongName(songName);
            StartCoroutine(GetRequest("https://api.spotify.com/v1/audio-features/" + this.trackId + "?access_token=" + accessToken, isAudioFeatures));
        }
    }

    void SwitchBySongEnergy()
    {
        var obj = JSON.Parse(this.audioFeaturesJson);
        Debug.Log(obj["energy"].AsDouble);
        if (obj["energy"].AsDouble < 0.3)
        {
            songType = 3;
        }
        else if (obj["energy"].AsDouble >= 0.3f && obj["energy"].AsDouble < 0.5f)
        {
            songType = 1;
        }
        else if (obj["energy"].AsDouble >= 0.5f && obj["energy"].AsDouble < 0.7f)
        {
            songType = 4;
        }
        else
        {
            songType = 2;
        }
    }

    IEnumerator GetRequest(string uri, int typeOfCall)
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
            switch(typeOfCall)
            {
                case 0:
                    this.loginHtml = uwr.downloadHandler.text;
                    break;

                case 1:
                    this.songJson = uwr.downloadHandler.text;
                    GetSongData();
                    break;

                case 2:
                    this.audioFeaturesJson = uwr.downloadHandler.text;
                    SwitchBySongEnergy();
                    break;

                default:
                    break;
            }
        }
    }

    IEnumerator PostRequest(string url, string json)
    {
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
            var obj = JSON.Parse(uwr.downloadHandler.text);
            this.accessToken = obj["access_token"].Value;
        }
    }

    string AuthorizationCode()
    {
        string text = "";
        // Read the file as one string.
        while(text.Equals(""))
        {
            text = System.IO.File.ReadAllText("C:\\Program Files\\Spotifyman\\auth.txt");
        }

        return text.Substring(15);
    }
}
