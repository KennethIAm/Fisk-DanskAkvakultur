using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comingsoonscript : MonoBehaviour
{
    [SerializeField]
    GameObject ui1;
    [SerializeField]
    GameObject ui2;

    public void ChangeUi()
    {
        ui1.gameObject.SetActive(false);
        ui2.gameObject.SetActive(true);
    }
}
