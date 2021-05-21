using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Maincontroller : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("loaded");
    }


    public void Quiter()
    {
        Application.Quit();
    }

}
