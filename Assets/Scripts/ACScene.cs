using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ACScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
