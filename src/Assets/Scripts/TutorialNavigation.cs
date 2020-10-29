using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialNavigation : MonoBehaviour
{
    int selectedScreen = 0;
    int currentScreen = 0;

    void Start()
    {
        SelectPage();
    }

    public void NextScreen()
    {
        if (selectedScreen == 6) return;
        selectedScreen++;
    }

    public void PreviousScreen()
    {
        if (selectedScreen == 0) return;
        selectedScreen--;
    }

    void Update()
    {
        if (currentScreen != selectedScreen) 
        {
            SelectPage();
        }
        currentScreen = selectedScreen;
    }

    void SelectPage()
    {
        int i = 0;
        foreach (Transform screen in transform)
        {
            if (i == selectedScreen)
            {
                screen.gameObject.SetActive(true);
            }
            else
            {
                screen.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
