using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private string _name;

    [SerializeField]
    private float _satisfieValue;

    public Food(string name, float satisfieValue)
    {
        _name = name;
        _satisfieValue = satisfieValue;
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public float SatisfieValue
    {
        get { return _satisfieValue; }
        set { _satisfieValue = value; }
    }
}
