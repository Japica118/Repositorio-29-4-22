using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    private SFXManager sfxManager;
    private BGMManager bgmManager;

      void Awake()
      {
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        bgmManager = GameObject.Find("BGMManager").GetComponent<BGMManager>();
      }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.tag == "Witch")
        {
            Destroy(hit.gameObject);
            sfxManager.WitchSound();
            bgmManager.StopBGM();
        }
    }
    
}
