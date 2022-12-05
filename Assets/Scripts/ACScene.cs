using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class ACScene : MonoBehaviour
{
    public GameObject help_panel, ac_guide_panel, ac_guide_panel_2;

    public GameObject notification_bubble;

    public TMP_InputField ac_model, ac_age, ac_serviced; 

    private const string maintenanceNotificationKey = "maintenanceNotification";
    
    // Start is called before the first frame update
    void Start()
    {
        help_panel.SetActive(false);
        ac_guide_panel.SetActive(false);
        ac_guide_panel_2.SetActive(false);

        if (PlayerPrefs.GetInt(maintenanceNotificationKey) == 1)
        {
            notification_bubble.SetActive(false);
        }
        else
        {
            notification_bubble.SetActive(true);
        }

        if (PlayerPrefs.GetInt("ac") == 1)
        {
            String model = PlayerPrefs.GetString("ac_model");
            String age = PlayerPrefs.GetString("ac_age");
            String serviced = PlayerPrefs.GetString("ac_serviced");

            if (!model.Equals(""))
            {
                ac_model.GetComponent<TMP_InputField>().text = model;
            }

            if (!age.Equals(""))
            {
                ac_age.GetComponent<TMP_InputField>().text = age;
            }
            
            if (!serviced.Equals(""))
            {
                ac_serviced.GetComponent<TMP_InputField>().text = serviced;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHelpInfo()
    {
        help_panel.SetActive(true);
    }

    public void HideHelpInfo()
    {
        help_panel.SetActive(false);
    }

    public void ContactScene()
    {
        SceneManager.LoadScene("ContactProfessional", LoadSceneMode.Additive);
    }

    public void HomeScene()
    {
        SceneManager.LoadScene("Home");
    }

        public void BlueprintsScene()
    {
        SceneManager.LoadScene("Blueprints");
    }

    public void DocumentsScene()
    {
        SceneManager.LoadScene("Documents");
    }

    public void MaintenanceTaskScene()
    {
        SceneManager.LoadScene("MaintenanceTask");
    }
}
