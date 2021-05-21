using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomIdGenerator : MonoBehaviour
{
    public Text Id;
    bool isIDExists;

    private void Start()
    {
        GenerateID(isIDExists);
    }
    private void GenerateID(bool Checker)
    {
        int GeneratedId = IsIdExists();
        if (GeneratedId == 0)
        {
            GeneratedId = Random.Range(999999, 9999999);
            Id.text ="COVID_20_ID : "+ GeneratedId.ToString();
            PlayerPrefs.SetInt(UTIL.PREFS_IS_UNIQUE_ID,GeneratedId);
            PlayerPrefs.Save();
            //now do something that say isIDExists to true
        } 
        else
        {
            Id.text ="COVID_20_ID : "+ GeneratedId.ToString();
        }
    }

    int IsIdExists(){
       return PlayerPrefs.GetInt(UTIL.PREFS_IS_UNIQUE_ID, 0);
    }
}
