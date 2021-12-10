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
    [SerializeField]
    GameObject CM;
    [SerializeField]
    Text pointText;


    EelController[] _EelsInScene;
    Food[] _foodButtons;
    Food _currentFood;

    private float _points;
    public float Points
    {
        get { return _points; }
        set { _points = value; }
    }

    void Start()
    {
        _foodButtons = FindObjectsOfType<Food>();
        FindEelsInScene();
    }

    void Update()
    {
        pointText.text = Points.ToString();

        FindEelsInScene();

        StartCoroutine(ExtractEels(5));

        if (Input.GetMouseButton(1))
        {
            CM.SetActive(true);
        }
        else CM.SetActive(false);
    }

    /// <summary>
    ///  Will feed all the Eels with matching current wanted food and the selected food.
    /// </summary>
    public void FeedEel()
    {
        if (_currentFood != null)
        {
            foreach (EelController eel in _EelsInScene)
                if (eel.isActiveAndEnabled)
                {
                    eel.GetFood(_currentFood);
                }
        }
        else
            print("No Food Chosen!");
    }

    /// <summary>
    ///  will find all Eels in scene and put them in a list.
    /// </summary>
    private void FindEelsInScene()
    {
        _EelsInScene = FindObjectsOfType<EelController>();
    }

    /// <summary>
    ///  will set the current selected food.
    /// </summary>
    public void SelectFood(Food obj)
    {
        _currentFood = obj;

        foreach (Food button in _foodButtons)
            if (button.isActiveAndEnabled)
            {
                button.gameObject.GetComponent<Image>().color = unselectedColor;
            }

        obj.gameObject.GetComponent<Image>().color = selectedColor;
    }

    /// <summary>
    ///  This will extract an eel once it is ready for extraction.
    /// </summary>
    public IEnumerator ExtractEels(float timeS)
    {
        foreach (EelController eel in _EelsInScene)
        {
            if (eel._eel.IsExtractable)
            {
                Destroy(eel.gameObject);
                Points += 1;
            }
        }

        yield return new WaitForSeconds(timeS);
    }

    /// <summary>
    ///  Shows info in simulation for player controlls and mechanics.
    /// </summary>
    public void ShowInfo(GameObject infoBTN)
    {
        if (infoBTN.activeInHierarchy)
            infoBTN.SetActive(false);
        else
            infoBTN.SetActive(true);
    }

}
