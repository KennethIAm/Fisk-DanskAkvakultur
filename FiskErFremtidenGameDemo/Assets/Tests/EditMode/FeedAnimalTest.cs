using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    [Test]
    public void Test()
    {
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
        eelCon.GetFood(food);

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.


        //ASSERT
        Assert.AreEqual(expectedvalue, eelCon._eel.HungerValue);
    }
}