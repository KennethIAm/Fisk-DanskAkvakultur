using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private string _name;

    [SerializeField]
    private float _satisfieValue;


    public string Name
    {
        get { return _name; }
    }

    public float SatisfieValue
    {
        get { return _satisfieValue; }
    }



}
