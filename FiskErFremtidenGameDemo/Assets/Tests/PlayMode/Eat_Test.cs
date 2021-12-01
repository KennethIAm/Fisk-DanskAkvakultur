using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Eat_Test
{

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator Eat_TestWithEnumeratorPasses()
    {
        //ARRANGE
        GameObject gameObject = new GameObject();
        EelController eelCon = gameObject.AddComponent<EelController>();
        eelCon.gameObject.AddComponent<Eel>();
        eelCon._eel = eelCon.gameObject.GetComponent<Eel>();
        eelCon._eel.Init();

        GameObject foodobj = new GameObject();
        Food food = foodobj.AddComponent<Food>();
        food.SatisfieValue = 20;
        food.Name = "wet";

        float expectedvalue = Mathf.Clamp(eelCon._eel.HungerValue + food.SatisfieValue, 0, 100);


        //ACT
        yield return null;
        eelCon.GetFood(food);

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.


        //ASSERT
        Assert.AreEqual(expectedvalue, eelCon._eel.HungerValue);


    }
}
