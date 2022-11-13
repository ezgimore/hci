using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ACScene : MonoBehaviour
{
    public GameObject help_panel;

    public GameObject notification_bubble;

    private const string maintenanceNotificationKey = "maintenanceNotification";
    
    // Start is called before the first frame update
    void Start()
    {
        help_panel.SetActive(false);

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
        SceneManager.LoadScene("ContactProfessional");
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
