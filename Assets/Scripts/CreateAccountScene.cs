using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class CreateAccountScene : MonoBehaviour
{
    // set via the Unity editor
    public GameObject account_panel, info_panel;
    public TMP_InputField u_name, pass, vpass, address; 

    
    // Start is called before the first frame update
    void Start()
    {
        account_panel.SetActive(true);
        info_panel.SetActive(false);
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
            return;
        }
        else if (!String.Equals(p,vp))
        {
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
        // TODO check values of amenities
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
}
