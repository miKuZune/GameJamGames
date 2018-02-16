using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsUImanager : MonoBehaviour {

    public GameObject options;
    public GameObject other;
    void Start()
    {
        AudioSource music = Camera.main.GetComponent<AudioSource>();
        music.mute = false;
        options.SetActive(false);
    }

    public void OptionsClicked()
    {
        options.SetActive(true);
        other.SetActive(false);
    }

    public void BackToStart()
    {
        options.SetActive(false);
        other.SetActive(true);
    }
    public void Mute()
    {
        AudioSource music = Camera.main.GetComponent<AudioSource>();
        music.mute = !music.mute;
        if (!music.mute)
        {
            music.Play();
        }
    }
}
