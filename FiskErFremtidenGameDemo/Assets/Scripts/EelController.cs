using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EelController : MonoBehaviour
{
    [SerializeField]
    GameObject _prefab;

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
        _eel.Eat(food);
    }

    private void FindPartner()
    {
        _eel.Breed();
    }


}
