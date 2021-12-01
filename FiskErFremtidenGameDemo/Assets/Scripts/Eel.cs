using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eel : MonoBehaviour
{   
    private float _hungerValue;
    private bool _isAlive;
    private int _age;
    private string _wantedFood;

    public void Init(float hungerValue = 50f, bool isalive = true, int age = 1)
    {
        _hungerValue = hungerValue;
        _isAlive = isalive;
        _age = age;
    }

    public float HungerValue
    {
        get { return _hungerValue; }

    }

    public string WantedFood
    {
        get { return _wantedFood; }
        set { _wantedFood = value; }
    }

    public bool IsAlive
    {
        get { return _isAlive; }
    }

    public int Age
    {
        get { return _age; }
        set { _age = value; }
    }

    public void Hunger(float value)
    {
        _hungerValue = Mathf.Clamp(_hungerValue -= value, 0, 100);
    }

    public void Eat(Food food)
    {
        if (CheckFood(food))
        {
            _hungerValue = Mathf.Clamp(_hungerValue += food.SatisfieValue, 0, 100);
        }
    }

    private bool CheckFood(Food food)
    {
        if (food.Name.Equals(WantedFood)) return true;
        else return false;
    }

    public void Die()
    {
        _isAlive = false;
    }

    public void AgeEel()
    {
        _age += 1;
        if (Age <= 5) { WantedFood = "wet"; }
        else if (Age > 5 && Age < 10) { WantedFood = "dry"; }
        else { WantedFood = "beef"; }
    }

}
