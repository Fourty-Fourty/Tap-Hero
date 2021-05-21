using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : Singleton<AdManager>
{
  public  GameObject Adbutton;
    public GameObject text_Notification;

    bool Adremoved = false;

   public void RemoveAd()
    {
        Adbutton.SetActive(false);
        text_Notification.SetActive(true);
        Adremoved = true;
        PlayerPrefs.SetInt(UTIL.adRemoved , 1);
        PlayerPrefs.Save();
        UTIL.appPurchased = PlayerPrefs.GetInt(UTIL.adRemoved , 0);
        Debug.Log("Removed "+ PlayerPrefs.GetInt(UTIL.adRemoved , 0));
    }
}
