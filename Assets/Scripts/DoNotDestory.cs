
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestory : MonoBehaviour
{
     void Awake()
    {
          DontDestroyOnLoad(this.gameObject);
    }
     void Start()
    {
       /*
         GameObject[] temp = GameObject.FindGameObjectsWithTag("Sound_bg");
         if(temp == null)
            return;
         if(temp.Length>1){
             for(int i=0;i<temp.Length;++i){
                    Destroy(temp[i]);
             }
         }
    */
          GameObject[] temp = GameObject.FindGameObjectsWithTag("Google_Ad");

          if(temp == null)
            return;
         if(temp.Length>1){
             for(int i=temp.Length-1;i>0;--i){
                    Destroy(temp[i]);
             }
         }

         
    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
