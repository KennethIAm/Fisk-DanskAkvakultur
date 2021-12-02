using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class SignalRTests : MonoBehaviour
{
    [SerializeField]
    SimulationManager simMan;

    [SerializeField]
    PlayerController playerController;
    
    [DllImport("__Internal")]
    private static extern void SendLeaderboard(float score);

    [DllImport("__Internal")]
    private static extern void SendPlayerChoice(string data);

    public void SendScore()
    {
        print(playerController.Points);
        SendLeaderboard(playerController.Points);
    }

    public void SendAnimalChoice()
    {
        print("#################################");
        SendPlayerChoice("Eel");
        print("#################################");
    }

}
