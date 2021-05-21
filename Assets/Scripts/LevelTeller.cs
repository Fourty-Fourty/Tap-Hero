using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTeller : MonoBehaviour
{
    Text currentLevel;
    int levelNo;
    
    IEnumerator Start()
    {
        currentLevel = GetComponent<Text>();
        levelNo = SceneManager.GetActiveScene().buildIndex;
        levelNo = levelNo - 1;
        currentLevel.text = "Level " + levelNo.ToString();
        yield return new WaitForSeconds(1.5f);
    }

   
}
