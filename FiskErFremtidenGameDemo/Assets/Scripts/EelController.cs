using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EelController : MonoBehaviour
{
    bool isHungry = true;

    // Start is called before the first frame update
    void Start()
    {
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
        print(gameObject.GetComponent<Eel>().hunger);
        gameObject.GetComponent<Eel>().hunger = gameObject.GetComponent<Eel>().hunger -= 5;
        isHungry = true;
    }

    public void feedEel()
    {
        gameObject.GetComponent<Eel>().hunger = gameObject.GetComponent<Eel>().hunger += 20;
    }
}
