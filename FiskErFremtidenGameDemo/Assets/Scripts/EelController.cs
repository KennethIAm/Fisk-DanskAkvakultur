using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EelController : MonoBehaviour
{
    bool isHungry = true;
    Eel _eel;

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
        // StartCoroutine(DecreseHunger(5));
        while (isHungry)
        {
            print("Is hungry");
            isHungry = false;
            StartCoroutine(DecreseHunger(2));
        }
    }

    IEnumerator DecreseHunger(float time)
    {
        print("Decrese hunger");
        yield return new WaitForSeconds(time);
        _eel.Hunger(5);
        isHungry = true;
    }

    public void feedEel()
    {
        _eel.Eat(20);
    }
}
