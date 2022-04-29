using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
   public float jumpForce = 10f;
   
   public bool isGrounded;

   //Variable para saber si la bruja esta viva
    public bool estaVivo = true;

   
   private float dirx;
  
    public Animator _animator;
   public SpriteRenderer renderer; 
   Rigidbody2D _rBody;

   public float attackRange;
   public LayerMask enemyLayer;
   public Transform attackHitBox;

   private SFXManager sfxManager;


   void Awake()
   {
       _animator = GetComponent<Animator>();
       _rBody = GetComponent<Rigidbody2D>();
       sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
   }

    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");

        Debug.Log(dirx);

        if(dirx == -1)
        {
            renderer.flipX = true;
            _animator.SetBool("Correr", true);
        }

        else if (dirx == 1)
        {
            renderer.flipX = false;
            _animator.SetBool("Correr", true);
        }

        else
        {
            _animator.SetBool("Correr", false);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            _rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _animator.SetBool("Salto", true);
            sfxManager.JumpSound();
        }

         if(Input.GetButtonDown("Fire1"))
            {
                Attack();
                _animator.SetBool("Disparo", true);
                sfxManager.FireSound();
            }
        
    }

    public void Attack()
    {
    Collider2D[] attackedEnemies = Physics2D.OverlapCircleAll(attackHitBox.position, attackRange, enemyLayer);
        foreach(Collider2D enemy in attackedEnemies)
        {
            Destroy(enemy.gameObject);
        }
    }

   void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackHitBox.position, attackRange);
    }

    void FixedUpdate()
    {
        _rBody.velocity = new Vector2(dirx * speed, _rBody.velocity.y);
    }

}

