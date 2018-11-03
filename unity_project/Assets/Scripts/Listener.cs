using System;
using UnityEngine;

public class Listener : MonoBehaviour
{
    public static int currentSong = 0;
    public readonly static int possibleSongTypes = 4;
    public static double songSpeed = 10;

    // Use this for initialization
    void Start()
    {
        EventManager.StartListening("Normal", FlipCurrentSongToNormal);
        EventManager.StartListening("Darude", FlipCurrentSongToDarude);
        EventManager.StartListening("Moody", FlipCurrentSongToMoody);
        EventManager.StartListening("Rock", FlipCurrentSongToRock);
    }

    private void FlipCurrentSongToNormal()
    {
        //Debug.Log("Normal");
        currentSong = 0;
        songSpeed = 10;
    }

    private void FlipCurrentSongToDarude()
    {
        //Debug.Log("Darude");
        currentSong = 1;
        songSpeed = 20;
    }

    private void FlipCurrentSongToMoody()
    {
        //Debug.Log("Moody");
        currentSong = 2;
        songSpeed = 5;
    }

    private void FlipCurrentSongToRock()
    {
        //Debug.Log("Rock");
        currentSong = 3;
        songSpeed = 15;
    }
}
