using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScene : MonoBehaviour
{
    public GameObject notification_bubble;

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

    public void DocumentsScene()
    {
        SceneManager.LoadScene("Documents");
    }

    public void GoToHomeScene()
    {
        SceneManager.LoadScene("Home");
    }
    
    public void MaintenanceTaskScene()
    {
        SceneManager.LoadScene("MaintenanceTask");
    }

}