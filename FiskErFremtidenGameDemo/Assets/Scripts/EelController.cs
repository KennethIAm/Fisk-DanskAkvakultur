using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EelController : MonoBehaviour
{
    /// <summary>
    ///  This class performs the actions for the Eel object in the scene.
    /// </summary>

    [SerializeField]
    GameObject _prefab;

    [SerializeField]
    Slider _healthBar;

    [SerializeField]
    RawImage _WantedFoodimg;

    [SerializeField]
    Texture2D foodimg1, foodimg2, foodimg3;


    bool isHungry = true;
    bool isAgeing = false;
    public Eel _eel;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Eel>();
        _eel = gameObject.GetComponent<Eel>();
        _eel.Init(prefab:_prefab);
    }

    // Update is called once per frame
    void Update()
    {
        _healthBar.value = _eel.HungerValue;

        if (_eel.WantedFood == "wet")
        {
            _WantedFoodimg.texture = foodimg1;
        }
        else if (_eel.WantedFood == "dry")
        {
            _WantedFoodimg.texture = foodimg2;
        }
        else
        {
            _WantedFoodimg.texture = foodimg3;
        }

        if (isHungry)
        {
            isHungry = false;
            StartCoroutine(DecreseHunger(2));
        }

        if (!_eel.IsAlive) Destroy(gameObject);


        if (!isAgeing)
        {
            isAgeing = true;
            StartCoroutine(StartAgeing(5));
        }

        if (_eel.IsBreedable) FindPartner();
    }

    /// <summary>
    ///  DecreseHunger decreses hunger every (timeS) seconds.
    /// </summary>
    IEnumerator DecreseHunger(float timeS)
    {
        yield return new WaitForSeconds(timeS);
        _eel.Hunger(10);
        if (_eel.HungerValue <= 0)
        {
            _eel.Die();
        }
        isHungry = true;
    }

    /// <summary>
    ///  StartAgeing will age the obect every (timeS) seconds.
    /// </summary>
    IEnumerator StartAgeing(float timeS)
    {
        yield return new WaitForSeconds(timeS);
        _eel.AgeEel();
        isAgeing = false;
    }

    public void GetFood(Food food)
    {
        _eel.Eat(food);
    }

    private void FindPartner()
    {
        _eel.Breed();
    }


}
