using UnityEngine;
using System.Collections;

public class AudioOptionListener : MonoBehaviour {

    private bool optionMusic = true;
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
