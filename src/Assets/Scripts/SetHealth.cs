using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataBase_Temp dataBase_Temp = GameObject.Find("DataBase_Temp").GetComponent<DataBase_Temp>();
        dataBase_Temp.initVariables();

        SceneManager.LoadScene("MainMenu");
    }
}
