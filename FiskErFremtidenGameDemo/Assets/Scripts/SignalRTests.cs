using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class SignalRTests : MonoBehaviour
{
    [SerializeField]
    Text score;

    [DllImport("__Internal")]
    private static extern void Hello(Text score);

    public void SendScore(Text score)
    {
        Hello(score);
    }

}
