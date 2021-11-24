using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eel : MonoBehaviour
{   
    private float _hungerValue;

    public void Init(float hungerValue = 100f)
    {
        _hungerValue = hungerValue;
    }

    public float HungerValue
    {
        get { return _hungerValue; }
    }

    public void Hunger(float value)
    {
        _hungerValue = Mathf.Clamp(_hungerValue -= value, 0, 100);
    }

    public void Eat(float value)
    {
        _hungerValue = Mathf.Clamp(_hungerValue += value, 0, 100);
    }

}
