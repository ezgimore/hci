using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateAccountScene : MonoBehaviour
{
    // set via the Unity editor
    public GameObject account_panel, info_panel;

    
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
        // TODO: check if password and verify password are the same

        account_panel.SetActive(false);
        info_panel.SetActive(true);
    }

    public void HomeScene()
    {
        SceneManager.LoadScene("Home");
    }
}
