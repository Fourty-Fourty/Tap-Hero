using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{

    public GameObject rateUsPrefab;
    private int escapeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            escapeCount++;
            if(escapeCount>1){
                  Application.Quit();
            }
            if( escapeCount == 1){
                Instantiate(rateUsPrefab);
            }
        }
                
    }
}
