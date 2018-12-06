using UnityEngine;
using UnityEngine.UI;

public class TrackDisplay : MonoBehaviour
{
    public Canvas canvas = null;
    public Text text = null;
    private string songName = "";
    private SpotifyTest spotifyTest;

    void Awake()
    {
        // Load the Arial font from the Unity Resources folder.
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        text.font = arial;
        text.fontSize = 14;

        spotifyTest = GameObject.Find("Player").GetComponent<SpotifyTest>();
    }

    void Update()
    {
                text.text = songName;
    }

    public void setSongName (string songName)
    {
        this.songName = songName;
    }
}