using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{

    private AudioSource _audioSource;
   
    void Awake()
    {
        //Asignamos la variable
        _audioSource = GetComponent<AudioSource>();
    }
 
    void Start()
    {
        _audioSource.Play();
    }

    //Funcion para parar el BMG
    public void StopBGM()
    {
        _audioSource.Stop();
    }
}
