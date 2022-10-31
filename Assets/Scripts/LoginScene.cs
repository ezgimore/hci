using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// this script is attached to the EventSystem of the Login Scene
public class LoginScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // called from the OnClick function of create account button
    public void CreateAccountScene()
    {
        SceneManager.LoadScene("CreateAccount");
    }

    public void HomeScene()
    {
        SceneManager.LoadScene("Home");
    }
}
