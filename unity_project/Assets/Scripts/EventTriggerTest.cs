using UnityEngine;
using System.Collections;

public class EventTriggerTest : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            EventManager.TriggerEvent("test");
        }

        if (Input.GetKeyDown("2"))
        {
            EventManager.TriggerEvent("Spawn");
        }

        if (Input.GetKeyDown("3"))
        {
            EventManager.TriggerEvent("Destroy");
        }

        if (Input.GetKeyDown("4"))
        {
            EventManager.TriggerEvent("Junk");
        }
    }
}