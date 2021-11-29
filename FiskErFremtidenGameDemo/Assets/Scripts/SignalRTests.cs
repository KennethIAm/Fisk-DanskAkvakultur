using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SignalRTests : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Hello();

    // Start is called before the first frame update
    void Start()
    {
        Hello();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
