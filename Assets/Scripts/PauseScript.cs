using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    Scene Cureentscence;
    string namescence;


    public void Restart()
    {
        Debug.Log("test");
        Time.timeScale = 1;
        Cureentscence = SceneManager.GetActiveScene();
        namescence = Cureentscence.name;
        SceneManager.LoadScene(namescence);
        GameObject[] bg_music  = GameObject.FindGameObjectsWithTag("Sound_bg");
        if(bg_music.Length>1){
            Destroy(bg_music[1]);
        }
    }
    public void mainmenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void PauseGame()
    {      
            Time.timeScale = 0;     
    }
    public void ResumeGame()
    {
            Time.timeScale = 1;                  
    }

}
