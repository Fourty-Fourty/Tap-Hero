using GameAnalyticsSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        GameAnalytics.Initialize();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnLevelStart(string currentLevel)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Level "+currentLevel);
    }
    void OnLevelCompleted(string currentLevel)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Level " + currentLevel);
    }
}
