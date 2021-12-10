using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignalRTests : MonoBehaviour
{
    [SerializeField]
    SimulationManager simMan;

    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    Button EndButton;
    
    [DllImport("__Internal")]
    private static extern void SendLeaderboard(float score);

    [DllImport("__Internal")]
    private static extern void SendPlayerChoice(string data);

    /// <summary>
    ///  SendScore will onvoke a method in a javascript file.
    /// </summary>
    public void SendScore()
    {
        EndButton.gameObject.SetActive(false);
        print(playerController.Points);
        SendLeaderboard(playerController.Points);
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    ///  SendAnimalChoice will onvoke a method in a javascript file.
    /// </summary>
    public void SendAnimalChoice()
    {
        print("#################################");
        SendPlayerChoice("Eel");
        print("#################################");
    }

}
