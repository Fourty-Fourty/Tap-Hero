using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof( Button))]
public class ButtonClick : MonoBehaviour
{
    AudioManager audioManager;
    Button buttons;

    private void Start()
    {
        buttons = GetComponent<Button>();
        buttons.onClick.AddListener(makesound);
        audioManager = GameObject.Find("Audio Source").GetComponent<AudioManager>();
    }
    void makesound()
    {
        audioManager.Playsound();
    }

}
