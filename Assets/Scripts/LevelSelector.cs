using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelector : MonoBehaviour
{
    public GameObject[] panelHolders;
    private bool[] panelUnlocked;
    private AudioSource lvlMusic;
    // Start is called before the first frame update

    void Start()
    {
        
        lvlMusic = GameObject.FindGameObjectWithTag("Google_Ad").GetComponent<AudioSource>();
        lvlMusic.Stop();
        panelUnlocked = new bool[panelHolders.Length];
        CalculateLockUnlockPanels();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CalculateLockUnlockPanels(){
        int lvlUnlocked = 10;
        lvlUnlocked = PlayerPrefs.GetInt(UTIL.PREFS_LVL_CLEARED,1);
        if(lvlUnlocked >= UTIL.MAX_LEVEL)
        {
            lvlUnlocked = UTIL.MAX_LEVEL;
        }
        Debug.Log("Total Lvel unlocked "+ lvlUnlocked);
         if(lvlUnlocked != -1)
         {
             for(int i=0;i<lvlUnlocked;++i){
                   //print(panelHolders[i].name);
                   //print(panelHolders[i].GetComponentInChildren(typeof(Text), true).gameObject.name);
                   //print(panelHolders[i].GetComponentsInChildren(typeof(Image), true)[1].gameObject.name);
                  panelHolders[i].GetComponentInChildren(typeof(Text), true).gameObject.SetActive(true);
                  panelHolders[i].GetComponentsInChildren(typeof(Image), true)[1].gameObject.SetActive(false);
                  panelUnlocked[i] = true;
             }
         }
    }

    public void ActiaveLevel(int index){
        if(!panelUnlocked[index-1]){
                return;
        }
        lvlMusic.Play();
        UTIL.levelIndex = index;
        SceneManager.LoadScene(UTIL.levelIndex + UTIL.lvlOffset);
    }
}
