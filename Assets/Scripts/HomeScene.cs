using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class HomeScene : MonoBehaviour
{
    public GameObject notification_bubble;

    public GameObject water, washer, light, lawn;

    private const string maintenanceNotificationKey = "maintenanceNotification";
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(maintenanceNotificationKey) == 1)
        {
            notification_bubble.SetActive(false);
        }
        else
        {
            notification_bubble.SetActive(true);
        }

        string[] utils = new string[4] { "water", "washer", "light", "lawn" };
        foreach (var util in utils)
        {

            if (util.Equals("water") && PlayerPrefs.GetInt(util) == 0)
            {
                Destroy(water);
            }

            else if (util.Equals("washer") && PlayerPrefs.GetInt(util) == 0 && PlayerPrefs.GetInt("dryer") == 0)
            {
                Destroy(washer);
            }

            else if (util.Equals("light") && PlayerPrefs.GetInt(util) == 0)
            {
                Destroy(light);
            }

            else if (util.Equals("lawn") && PlayerPrefs.GetInt(util) == 0)
            {
                Destroy(lawn);
            }

        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ACScene()
    {
        SceneManager.LoadScene("AC");
    }

    public void BlueprintsScene()
    {
        SceneManager.LoadScene("Blueprints");
    }

    public void MaintenanceTaskScene()
    {
        SceneManager.LoadScene("MaintenanceTask");
    }

    public void DocumentsScene()
    {
        SceneManager.LoadScene("Documents");
    }

    public void GoToHomeScene()
    {
        SceneManager.LoadScene("Home");
    }

}
