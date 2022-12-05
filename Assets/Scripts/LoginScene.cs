using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;
using System.Text.RegularExpressions;

// this script is attached to the EventSystem of the Login Scene
public class LoginScene : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField passcode;
    public TMPro.TMP_Text error_text;
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
        error_text.text = "";
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
        if(!Regex.IsMatch(username.GetComponent<TMP_InputField>().text, "^[a-zA-Z0-9]+$") || !Regex.IsMatch(passcode.GetComponent<TMP_InputField>().text, "^[a-zA-Z0-9]+$"))
        {
            error_text.text = "Username/Password is incorrect";
            return;
        }
        SceneManager.LoadScene("Home");
    }
}
