using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectAnimal(string animal)
    {

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
        SceneManager.LoadScene("Test scene Jolle");
    }
}
