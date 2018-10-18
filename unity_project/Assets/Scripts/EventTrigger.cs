using UnityEngine;
using System.Collections;

public class EventTrigger : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            EventManager.TriggerEvent("Normal");
        }

        if (Input.GetKeyDown("2"))
        {
            EventManager.TriggerEvent("Darude");
        }

        if (Input.GetKeyDown("3"))
        {
            EventManager.TriggerEvent("Moody");
        }

        if (Input.GetKeyDown("4"))
        {
            EventManager.TriggerEvent("Rock");
        }
    }
}