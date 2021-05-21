using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource buttonsound;
    public AudioClip btClip;
 
  public void Playsound()
    {
        buttonsound.PlayOneShot(btClip);
    }
}
