using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;

// this script is attached to the EventSystem of the Login Scene
public class LoginScene : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField passcode;
    // Start is called before the first frame update
    void Start()
    {
        /*inputField.GetComponent<TMP_InputField>().text*/
        PlayerPrefs.SetInt("maintenanceNotification", 0);
        string[] utils = new string[6] { "water", "washer", "dryer", "light", "lawn", "ac" };
        foreach (var util in utils)
        {
            PlayerPrefs.SetInt(util, 1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // called from the OnClick function of create account button
    public void CreateAccountScene()
    {
        SceneManager.LoadScene("CreateAccount");
    }

    public void HomeScene()
    {
        if(String.Equals(username.GetComponent<TMP_InputField>().text,"") || String.Equals(passcode.GetComponent<TMP_InputField>().text,""))
            return;
        SceneManager.LoadScene("Home");
    }
}
