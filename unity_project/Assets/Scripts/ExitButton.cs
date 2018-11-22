using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ExitButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Make sure to attach these Buttons in the Inspector
    public Button exit;
    public Text texto;
    public AudioClip somHover;
    public AudioClip somClick;
    AudioSource som;

    void Start()
    {
        //Calls the TaskOnClick method when you click the Button
        exit.onClick.AddListener(TaskOnClick);
        som = GetComponent<AudioSource>();
    }

    void TaskOnClick()
    {
        //Output this to console when Button is clicked
        som.clip = somClick;
        StartCoroutine(PlayAndExit());
        
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

    IEnumerator PlayAndExit()
    {
        som.Play();
        yield return new WaitForSeconds(3);
        //do something
        ExitApplication();
    }

    void ExitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else 
        Application.Quit();
#endif
    }
}