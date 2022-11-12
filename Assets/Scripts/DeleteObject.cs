using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeleteObject : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;

    public void RemoveUtil(String util)
    {
        PlayerPrefs.SetInt(util, 0);
        Destroy(target);
    }

}