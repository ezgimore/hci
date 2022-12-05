using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
using System.Text.RegularExpressions;

public class CreateAccountScene : MonoBehaviour
{
    // set via the Unity editor
    public GameObject account_panel, info_panel;
    public TMPro.TMP_Text error_text;
    public TMP_InputField u_name, pass, vpass, address, ac_model, ac_age, ac_serviced; 

    
    // Start is called before the first frame update
    void Start()
    {
        account_panel.SetActive(true);
        info_panel.SetActive(false);
        error_text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // called from the OnClick function of continue button
    public void ShowInfoPanel()
    {
       
        String u = u_name.GetComponent<TMP_InputField>().text;
        String p = pass.GetComponent<TMP_InputField>().text;
        String vp = vpass.GetComponent<TMP_InputField>().text;
        String a = address.GetComponent<TMP_InputField>().text;
        if (String.Equals(u,"") || String.Equals(p,"") || String.Equals(vp,"") || String.Equals(a,"") )
        {
            error_text.text = "Please fill in all fields";
            return;
        }
        else if (!Regex.IsMatch(u, "^[a-zA-Z0-9]+$") || !Regex.IsMatch(p, "^[a-zA-Z0-9]+$") || !Regex.IsMatch(vp, "^[a-zA-Z0-9]+$") )
        {
            error_text.text = "Please use alphanumeric strings for username and password";
            return;
        }
        else if (!String.Equals(p,vp))
        {
            error_text.text = "Passwords do not match";
            return;
        }
        account_panel.SetActive(false);
        info_panel.SetActive(true);
    }

    public void ShowAccountPanel()
    {
        account_panel.SetActive(true);
        info_panel.SetActive(false);
    }

    public void HomeScene()
    {
        // check values of amenities
        if (PlayerPrefs.GetInt("ac") == 1)
        {
            String model = ac_model.GetComponent<TMP_InputField>().text;
            String age = ac_age.GetComponent<TMP_InputField>().text;
            String serviced = ac_serviced.GetComponent<TMP_InputField>().text;

            if (model.Equals(""))
            {
                PlayerPrefs.SetString("ac_model", "");
            }
            else
            {
                PlayerPrefs.SetString("ac_model", model);
            }

            if (age.Equals(""))
            {
                PlayerPrefs.SetString("ac_age", "");
            }
            else
            {
                PlayerPrefs.SetString("ac_age", age);
            }

            if (serviced.Equals(""))
            {
                PlayerPrefs.SetString("ac_serviced", "");
            }
            else
            {
                PlayerPrefs.SetString("ac_serviced", serviced);
            }
        }
        
        SceneManager.LoadScene("Home");
    }

    public void SkipInitialize()
    {
        string[] utils = new string[6] { "water", "washer", "dryer", "light", "lawn", "ac" };
        foreach (var util in utils)
        {
            PlayerPrefs.SetInt(util, 0);
        }
        SceneManager.LoadScene("Home");
    }

    public void GoToLoginScene()
    {
        SceneManager.LoadScene("Login");
    }

}
