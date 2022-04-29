using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{ 
    //Clip de audio para la muerte de la witch
    public AudioClip witchSFX;
    //Clip de audio muerte serpiente
    public AudioClip snakeSFX;
    //Clip de audio monedas
    public AudioClip jumpSFX;
    //Clip de audio bandera
    public AudioClip fireSFX;
    //Variable del audio source
    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void WitchSound()
    {
        _audioSource.PlayOneShot(witchSFX);
    }

    public void SnakeSound()
    {
        _audioSource.PlayOneShot(snakeSFX);
    }

    public void JumpSound()
    {
        _audioSource.PlayOneShot(jumpSFX);
    }

      public void FireSound()
    {
        _audioSource.PlayOneShot(fireSFX);
    }

}
