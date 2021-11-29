using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class SendLeaderboardData : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SendLeaderboard(float value);

    public void SendData(float Score)
    {
        print("Sending Score Data From c# To Js");
        print("This is the score from unity: " + Score);
        SendLeaderboard(Score);
    }
}
