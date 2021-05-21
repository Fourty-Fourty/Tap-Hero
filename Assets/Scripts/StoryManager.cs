using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public GameObject[] virus;
    public GameObject[] dialogues;
    public GameObject[] herodialogues;
    public GameObject bg1;
    public GameObject crowd;
    public GameObject Wizard;
    public GameObject hero;
    public AudioSource audioSource;
    public AudioClip cough;
    public AudioClip pop,bgsound;
    public int timer=3;
    public GameObject skipButton;

    bool scence2;
    
  
    int i=0;


   private void Start()
    {
        skipButton.SetActive(false);
        audioSource.PlayOneShot(cough);
        StartCoroutine(StartGame());
        Scence1();
    }

    private void Update()
    {
        
    }
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(4);
        if( PlayerPrefs.GetInt(UTIL.PREFS_SKIP_STORY, 0) == 0)
        {
            PlayerPrefs.SetInt(UTIL.PREFS_SKIP_STORY, 1);
            Debug.Log("NotFound");
            PlayerPrefs.Save(); 
        }
        else {
            skipButton.SetActive(true);
            Debug.Log("Found");
        }
  

    }
    public void Scence1()
    {

        if (i <= virus.Length-1&&!scence2)
        {
            i += 1;
            StartCoroutine(VirusSpawning(virus[i - 1]));
        }       
        else
        {
      
            Debug.Log("Scence 1 Completed");
            Scence2();
        }

    }

    IEnumerator VirusSpawning(GameObject Virus)
    {
        yield return new WaitForSeconds(0.3f);
        audioSource.volume = 0.5f;
        Virus.SetActive(true);
              
        audioSource.PlayOneShot(pop);
        Scence1();

        yield return new WaitForSeconds(4);
        scence2 = true;
    }

    public void Scence2()
    {
        bg1.SetActive(true);
        StartCoroutine(Crowdcomes());
    }
    IEnumerator Crowdcomes()
    {
        Debug.Log("scence 2");
        audioSource.PlayOneShot(bgsound);
        audioSource.volume = 0.75f;
        yield return new WaitForSeconds(1f);
        crowd.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialogues[0].SetActive(true);
        yield return new WaitForSeconds(timer);
        dialogues[0].SetActive(false);
        dialogues[1].SetActive(true);
        yield return new WaitForSeconds(timer);
        dialogues[1].SetActive(false);
        dialogues[2].SetActive(true);
        yield return new WaitForSeconds(timer);
        dialogues[2].SetActive(false);
        dialogues[3].SetActive(true);
        yield return new WaitForSeconds(timer);
        dialogues[3].SetActive(false);
        dialogues[4].SetActive(true);
        yield return new WaitForSeconds(timer);
        dialogues[4].SetActive(false);
      StartCoroutine (Scence3());

    }

    IEnumerator  Scence3()
    {
        Debug.Log("scence 3");
        Wizard.SetActive(true);
        yield return new WaitForSeconds(timer);
        dialogues[5].SetActive(true);
        yield return new WaitForSeconds(timer);
        dialogues[5].SetActive(false);
        hero.SetActive(true);

        yield return new WaitForSeconds(timer);
        herodialogues[0].SetActive(true);
        yield return new WaitForSeconds(timer);
        herodialogues[0].SetActive(false);
        herodialogues[1].SetActive(true);
        yield return new WaitForSeconds(timer);
        herodialogues[1].SetActive(false);
        herodialogues[2].SetActive(true); 
        yield return new WaitForSeconds(timer);
        herodialogues[2].SetActive(false);
        herodialogues[3].SetActive(true); 
        yield return new WaitForSeconds(timer);
        herodialogues[3].SetActive(false);
        herodialogues[4].SetActive(true); 
        yield return new WaitForSeconds(timer);
        herodialogues[4].SetActive(false);
        herodialogues[5].SetActive(true); 
        yield return new WaitForSeconds(timer);
        herodialogues[5].SetActive(false);
        herodialogues[6].SetActive(true);
        yield return new WaitForSeconds(timer);
        herodialogues[6].SetActive(false);
        herodialogues[7].SetActive(true); 
        yield return new WaitForSeconds(timer);
        herodialogues[7].SetActive(false);
        herodialogues[8].SetActive(true); 
        yield return new WaitForSeconds(timer);
        herodialogues[8].SetActive(false);
        herodialogues[9].SetActive(true); 
        yield return new WaitForSeconds(timer);
        herodialogues[9].SetActive(false);
        herodialogues[10].SetActive(true);
        yield return new WaitForSeconds(timer);
        herodialogues[10].SetActive(false);
        herodialogues[11].SetActive(true); 
        yield return new WaitForSeconds(timer);
        herodialogues[11].SetActive(false);
        yield return new WaitForSeconds(timer);
        Debug.Log("Going to Game");
       SceneManager.LoadScene(1);
    }
}
