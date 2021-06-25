using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    public AudioClip[] fxs;
    AudioSource audioS;
    
    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    public void SonidoChoque()
    {
        audioS.clip = fxs[0];
        audioS.Play();
    }

    public void Musica()
    {
        audioS.clip = fxs[1];
        audioS.Play();
    }
}
