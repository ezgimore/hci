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
    public GameObject account_panel, info_panel, confirm_remove_panel, content_panel;
    public TMPro.TMP_Text error_text;
    public TMP_InputField u_name, pass, vpass, address, ac_model, ac_age, ac_serviced; 
    public TextMeshProUGUI confirm_remove_text;
    private string current_removed_appliance;

    // Start is called before the first frame update
    void Start()
    {
        account_panel.SetActive(true);
        info_panel.SetActive(false);
        confirm_remove_panel.SetActive(false);
        error_text.text = "";
        current_removed_appliance = "";
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

    public void ShowConfirmRemovePanel(string appliance_name)
    {
        confirm_remove_panel.SetActive(true);
        confirm_remove_text.SetText("Are you sure you want to remove " + (appliance_name.Equals("AC") ? "A/C" : appliance_name) + "?");
        current_removed_appliance = appliance_name;
    }


    // NOTE: This method requires current_removed_appliance be set to the name of the appliance entry in the editor so it may be removed
    public void RemoveAppliance()
    {
        GameObject appliance_entry = content_panel.transform.Find(current_removed_appliance).gameObject;
        Destroy(appliance_entry);
        PlayerPrefs.SetInt(current_removed_appliance.ToLower(), 0);
        HideConfirmRemovePanel();
    }

    public void HideConfirmRemovePanel()
    {
        confirm_remove_panel.SetActive(false);
    }

}
