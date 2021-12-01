using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    private string _chosenAnimal;
    private string _farmingMethod;

    public string ChosenAnimal
    {
        get { return _chosenAnimal; }
        set { _chosenAnimal = value; }
    }

    public string FarmingMethod
    {
        get { return _farmingMethod; }
        set { _farmingMethod = value; }
    }

}
