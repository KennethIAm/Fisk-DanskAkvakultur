using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eel : MonoBehaviour
{   
    private float _hungerValue;
    private bool _isAlive;

    public void Init(float hungerValue = 20f, bool isalive = true)
    {
        _hungerValue = hungerValue;
        _isAlive = isalive;
    }

    public float HungerValue
    {
        get { return _hungerValue; }
    }

    public bool IsAlive
    {
        get { return _isAlive; }
    }

    public void Hunger(float value)
    {
        _hungerValue = Mathf.Clamp(_hungerValue -= value, 0, 100);
    }

    public void Eat(float value)
    {
        _hungerValue = Mathf.Clamp(_hungerValue += value, 0, 100);
    }

    public void Die()
    {
        _isAlive = false;
    }

}
