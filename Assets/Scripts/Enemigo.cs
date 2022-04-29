using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    //Variable para controlar la velocidad de la serpiente
    public float movementSpeed = 4.5f;
    // Variable para saber en que direccion se mueve en el eje X
    private int directionX = 1;
    
    // Variable para almacenar el rigidbody del enemigo
    private Rigidbody2D rigidBody;
    //Variable para saber si la serpiente esta viva
    public bool estaVivo = true;

    private SFXManager sfxManager;
    private BGMManager bgmManager;



    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        bgmManager = GameObject.Find("BGMManager").GetComponent<BGMManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(estaVivo)
        {
            //Añade velocidad en el eje X
            rigidBody.velocity = new Vector2(directionX * movementSpeed, rigidBody.velocity.y);
        }

        else
        {
            rigidBody.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        //Si detecta una colision con un objeto de tag Trap
        if(hit.gameObject.tag == "Trap" || hit.gameObject.tag == "Snake")
        {
            Debug.Log("Me he chocado");

            if(directionX == 1)
            {
                directionX = -1;
            }

            //Si nos movemos a la izquierda, lo cambia a la derecha
            else
            {
                directionX = 1;
            }
        }

        else if(hit.gameObject.tag == "Witch")
        {
            Destroy(hit.gameObject);
            sfxManager.WitchSound();
            bgmManager.StopBGM();
        }
    }
}
