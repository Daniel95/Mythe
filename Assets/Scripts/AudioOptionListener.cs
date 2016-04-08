using UnityEngine;
using System.Collections;

public class AudioOptionListener : MonoBehaviour {
    private bool optionMusic;
    void OnEnable()
    {
        if (GameObject.FindGameObjectWithTag("Data"))
            optionMusic = GameObject.FindGameObjectWithTag("Data").GetComponent<OptionsData>().GetMusic;
        if(optionMusic)
        {
            GetComponent<AudioSource>().volume = 1;
        }
        else
        {
            GetComponent<AudioSource>().volume = 0;
        }
    }
}
