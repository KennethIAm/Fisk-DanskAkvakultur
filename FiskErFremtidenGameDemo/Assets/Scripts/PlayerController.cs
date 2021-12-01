using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    Color selectedColor;
    [SerializeField]
    Color unselectedColor;

    EelController[] EelsInScene;
    Food[] foodButtons;

    Food currentFood;

    void Start()
    {
        foodButtons = FindObjectsOfType<Food>();
    }

    public void FeedEel()
    {
        FindEelsInScene();

        foreach (EelController eel in EelsInScene)
            if (eel.isActiveAndEnabled)
            {
                eel.GetFood(currentFood);
            }
    }

    private void FindEelsInScene()
    {
        EelsInScene = FindObjectsOfType<EelController>();
    }

    public void SelectFood(Food obj)
    {
        currentFood = obj;

        foreach (Food button in foodButtons)
            if (button.isActiveAndEnabled)
            {
                button.gameObject.GetComponent<Image>().color = unselectedColor;
            }

        obj.gameObject.GetComponent<Image>().color = selectedColor;
    }

}
