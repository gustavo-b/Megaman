using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SpotifySettingsButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Make sure to attach these Buttons in the Inspector
    public Button spotifysettings;
    public Text texto;
    public AudioClip somHover;
    public AudioClip somClick;
    AudioSource som;

    void Start()
    {
        //Calls the TaskOnClick method when you click the Button
        spotifysettings.onClick.AddListener(TaskOnClick);
        som = GetComponent<AudioSource>();
    }

    void TaskOnClick()
    {
        //Output this to console when Button is clicked
        som.clip = somClick;
        StartCoroutine(PlayAndOpenURL());
         }

    public void OnPointerEnter(PointerEventData eventData)
    {
        texto.color = Color.white;
        som.clip = somHover;
        som.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        texto.color = Color.green;
    }

    IEnumerator PlayAndOpenURL()
    {
        som.Play();
        yield return new WaitWhile(() => som.isPlaying);
        //do something
        Application.OpenURL("https://accounts.spotify.com/authorize/?client_id=dc7407dc1c2042be8a8f5f78d6ccd3ad&response_type=code&redirect_uri=http%3A%2F%2F127.0.0.1%3A8080/callback&scope=user-read-currently-playing&state=myDiggersby007");
    }
}