using UnityEngine;
using UnityEngine.UI;

public class TrackDisplay : MonoBehaviour
{
    public Canvas canvas = null;
    public Text text = null;
    public Button buttonNextTrack = null;
    public Button buttonPreviousTrack = null;
    //private SpotifyTest;

    void Awake()
    {
        // Load the Arial font from the Unity Resources folder.
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        text.font = arial;
        text.fontSize = 14;
    }

    void Update()
    {
                text.text = "HELLO MARILENNE";
                text.text = "HELLO AGAIN MARILENNE";
    }
}