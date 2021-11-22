using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Rocket rocket;
    public int deathCount;

    bool isMenuOpen;

    [SerializeField]GameObject uiObject;
    [SerializeField]GameObject startMenu;
    [SerializeField]GameObject gameUI;
    public Text deathText;







    private void Start()
    {
        DontDestroyOnLoad(uiObject);
    }

    private void Update()
    {
        deathText.text = "Death Count; " + deathCount;
    }




    public void StartGame()
    {
        isMenuOpen = false;
        if (isMenuOpen == false)
        {
            startMenu.SetActive(false);
            gameUI.SetActive(true);
        }
        SceneManager.LoadScene("Level 1");
    }




}
