using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaintenanceTaskScene : MonoBehaviour
{
    public GameObject panel, notification_panel, notification_bubble, empty_notification_text;

    private const string maintenanceNotificationKey = "maintenanceNotification";
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(maintenanceNotificationKey) == 1)
        {
            notification_panel.SetActive(false);
            notification_bubble.SetActive(false);
            empty_notification_text.SetActive(true);
        }
        else
        {
            notification_panel.SetActive(true);
            notification_bubble.SetActive(true);
            empty_notification_text.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DismissNotificationPanel()
    {
        PlayerPrefs.SetInt(maintenanceNotificationKey, 1);

        notification_panel.SetActive(false);
        notification_bubble.SetActive(false);
        empty_notification_text.SetActive(true);
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

}
