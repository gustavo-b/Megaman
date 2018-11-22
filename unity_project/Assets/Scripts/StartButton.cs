using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;

public class StartButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Make sure to attach these Buttons in the Inspector
    public Button start;
    public Text texto;
    public AudioClip somHover;
    public AudioClip somClick;
    AudioSource som;

    void Start()
    {
        //Calls the TaskOnClick method when you click the Button
        start.onClick.AddListener(TaskOnClick);
        som = GetComponent<AudioSource>();
    }

    void TaskOnClick()
    {
        //Output this to console when Button is clicked
        som.clip = somClick;
        StartCoroutine(PlayAndStart());
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Megaman");
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

    IEnumerator PlayAndStart()
    {
        som.Play();
        yield return new WaitWhile(() => som.isPlaying);
        //do something
        LoadScene();
    }
}