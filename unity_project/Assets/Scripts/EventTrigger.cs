using UnityEngine;
using System.Collections;

public class EventTrigger : MonoBehaviour
{
    void Update()
    {
        if (SpotifyTest.songType == 1)
        {
            EventManager.TriggerEvent("Normal");
        }

        if (SpotifyTest.songType == 2)
        {
            EventManager.TriggerEvent("Darude");
        }

        if (SpotifyTest.songType == 3)
        {
            EventManager.TriggerEvent("Moody");
        }

        if (SpotifyTest.songType == 4)
        {
            EventManager.TriggerEvent("Rock");
        }
    }
}