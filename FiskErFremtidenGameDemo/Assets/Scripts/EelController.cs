using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EelController : MonoBehaviour
{
    bool isHungry = true;
    bool isAgeing = false;
    public Eel _eel;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Eel>();
        _eel = gameObject.GetComponent<Eel>();
        _eel.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHungry)
        {
            isHungry = false;
            StartCoroutine(DecreseHunger(2));
        }

        if (!_eel.IsAlive)
        {
            Destroy(gameObject);
        }

        if (!isAgeing)
        {
            isAgeing = true;
            StartCoroutine(StartAgeing(5));
        }
    }

    IEnumerator DecreseHunger(float timeS)
    {
        yield return new WaitForSeconds(timeS);
        _eel.Hunger(2);
        if (_eel.HungerValue <= 0)
        {
            _eel.Die();
        }
        isHungry = true;
    }

    IEnumerator StartAgeing(float timeS)
    {
        yield return new WaitForSeconds(timeS);
        _eel.AgeEel();
        isAgeing = false;
    }

    public void GetFood(Food food)
    {
        Debug.Log("Getting food");
        _eel.Eat(food);
    }


}
