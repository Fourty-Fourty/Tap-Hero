using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
     public Sprite[] spriteImage;
     public GameObject dyingEffect;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite  = spriteImage[Random.Range(0 ,spriteImage.Length)]; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        Instantiate(dyingEffect , transform.position ,  Quaternion.identity);
    }

    
}
