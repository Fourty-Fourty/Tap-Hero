using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
   // public int ScenceNo;

    public void ChangeScence(int ScenceNo)
    {
        SceneManager.LoadScene(ScenceNo);
    }

}
