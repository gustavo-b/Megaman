using UnityEngine;
using UnityEngine.UI;

public class TextoNomeDaMusica : MonoBehaviour
{
    public Canvas canvas = null;
    public Text text = null;
    public Button buttonNextTrack = null;
    public Button buttonPreviousTrack = null;

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