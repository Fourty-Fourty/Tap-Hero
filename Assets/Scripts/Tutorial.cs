using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public GameObject[] setActiveThese;
    // Start is called before the first frame update

    public void Back()
    {
        for(int i=0;i<setActiveThese.Length;++i){
            setActiveThese[i].SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
