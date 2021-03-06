using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eel : MonoBehaviour
{
    private float _hungerValue;
    private bool _isAlive;
    private int _age;
    private string _wantedFood;
    private bool _isBreedable;
    private bool _isExtractable;
    private GameObject _prefab;
    private bool _hasBred = false;

    public void Init(GameObject prefab, float hungerValue = 50f, bool isalive = true, int age = 1, string wantedFood = "wet", bool isBreedable = false)
    {
        _prefab = prefab;
        _hungerValue = hungerValue;
        _isAlive = isalive;
        _age = age;
        _wantedFood = wantedFood;
        _isBreedable = isBreedable;
    }

    public GameObject Prefab
    {
        get { return _prefab; }
        set { _prefab = value; }
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

    public bool IsExtractable
    {
        get { return _isExtractable; }
    }

    public bool IsBreedable
    {
        get { return _isBreedable; }
    }

    public int Age
    {
        get { return _age; }
        set { _age = value; }
    }

    /// <summary>
    ///  Hunegr will decrese the objects hunger each time its called.
    /// </summary>
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

    /// <summary>
    ///  Check food Cheks if its the current wanted food for this object.
    /// </summary>
    private bool CheckFood(Food food)
    {
        if (food.Name.Equals(WantedFood)) return true;
        else return false;
    }

    public void Die()
    {
        _isAlive = false;
    }

    /// <summary>
    ///  AgeEel will increse the Eels age and set some propeties depending on the age.
    /// </summary>
    public void AgeEel()
    {
        _age += 1;

        if (Age <= 3) { WantedFood = "wet"; }
        else if (Age > 3 && Age < 7) { WantedFood = "dry"; }
        else { WantedFood = "beef"; }

        if (Age > 5) _isBreedable = true;

        if (Age > 10) _isExtractable = true;
    }

    /// <summary>
    ///  Breed will chek if This Object has bred and if not crate new on 1 to 3 new objects.
    /// </summary>
    public void Breed()
    {
        if (!_hasBred)
        {
            float iterations = Random.Range(1f,3f);
            for (int i = 0; i < iterations; i++)
            {
                Instantiate(_prefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            }
            _hasBred = true;
        }
    }

}
