using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryCreator : MonoBehaviour
{
    private Vector2 screenBound;
    private Vector2 temp;
    public GameObject[] boundaryObjs;

    // Start is called before the first frame update
    void Start()
    {
        screenBound.x = Screen.width;
        screenBound.y = Screen.height;
        screenBound = Camera.main.ScreenToWorldPoint(screenBound);
        CreateBoundary();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateBoundary(){
        //left
        temp.x = screenBound.x*-1;
            boundaryObjs[0].transform.position = temp;
            boundaryObjs[0].transform.rotation = Quaternion.Euler(0 , 0 , 90);
        
        //Right
        temp.x = screenBound.x;
             boundaryObjs[1].transform.position = temp;
             boundaryObjs[1].transform.rotation = Quaternion.Euler(0 , 0 , 90);
             
        //Up
        temp.y = screenBound.y;
             boundaryObjs[2].transform.position = temp;
             boundaryObjs[2].transform.rotation = Quaternion.Euler(0 , 0 , 180);
        //Down
        temp.y = screenBound.y*-1;
            boundaryObjs[3].transform.position = temp;
            boundaryObjs[3].transform.rotation = Quaternion.Euler(0 , 0 , 180);

    }
}
