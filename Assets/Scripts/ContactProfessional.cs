using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ContactProfessional : MonoBehaviour
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

    public void Call(string number) {
        Application.OpenURL("tel:" + number);
    }

    public void Mail(string email) {
        Application.OpenURL("mailto:" + email);
    }

    public void HomeScene()
    {
        SceneManager.LoadScene("Home");
    }

    public void GoBack()
    {
        SceneManager.UnloadSceneAsync("ContactProfessional");
    }
}
