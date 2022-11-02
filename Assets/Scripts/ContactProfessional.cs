using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ContactProfessional : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Call(string number) {
        Application.OpenURL("tel:" + number);
    }

    public void HomeScene()
    {
        SceneManager.LoadScene("Home");
    }
}
