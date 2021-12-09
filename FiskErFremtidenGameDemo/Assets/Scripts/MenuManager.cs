using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    SimulationManager simManager;

    public void SelectAnimal(string animal)
    {
        simManager.ChosenAnimal = animal;
    }

    public void SelectFarmingMethod(string farmMethod)
    {
        simManager.FarmingMethod = farmMethod;
    }

    public void ChangeMenu(GameObject nextUI)
    {
        nextUI.SetActive(true);
    }
    public void DisableCurrentMenu(GameObject currentUI)
    {
        currentUI.SetActive(false);
    }

    public void Startgame()
    {
        print("Data to send to server and generate sim of: Animal - " + simManager.ChosenAnimal + " opdrættelsesmetode - " + simManager.FarmingMethod);
        SceneManager.LoadScene("Test scene Jolle");
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
