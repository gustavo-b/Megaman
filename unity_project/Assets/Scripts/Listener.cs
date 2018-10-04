﻿using System;
using UnityEngine;

public class Listener : MonoBehaviour
{
    public static int currentSong = 0;
    public static int possibleSongTypes = 4;
    public static double songSpeed = 1;

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
        currentSong = 0;
        songSpeed = 1;
    }

    private void FlipCurrentSongToDarude()
    {
        currentSong = 1;
        songSpeed = 2;
    }

    private void FlipCurrentSongToMoody()
    {
        currentSong = 2;
        songSpeed = 0.5;
    }

    private void FlipCurrentSongToRock()
    {
        currentSong = 3;
        songSpeed = 1.2;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
