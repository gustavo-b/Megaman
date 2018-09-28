using UnityEngine;
using System.Collections;

public class EventTriggerTest : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKeyDown("0"))
        {
            EventManager.TriggerEvent("Normal");
        }

        if (Input.GetKeyDown("1"))
        {
            EventManager.TriggerEvent("Darude");
        }

        if (Input.GetKeyDown("2"))
        {
            EventManager.TriggerEvent("Moody");
        }

        if (Input.GetKeyDown("3"))
        {
            EventManager.TriggerEvent("Rock");
        }

        if (Input.GetKeyDown("4"))
        {
            EventManager.TriggerEvent("Junk");
        }
    }
}