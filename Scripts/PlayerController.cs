using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public float jumpspeed = 10f;
    private float movement = 0f;
    private Rigidbody2D rigidbody;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private Animator playerAnimation;
    public Vector3 respawnPoint;
    public LevelManager gameLevelManager;
    public int endGameDelay;
    protected AudioSource jumpSound;
    private SoundManager sound;
   
    // Start is called before the first frame update
    void Start()
    {
        rigidbody=GetComponent<Rigidbody2D> ();
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager>();
        jumpSound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        movement = Input.GetAxis("Horizontal");
        if (movement >0f)
        {
            rigidbody.velocity = new Vector2(movement * speed, rigidbody.velocity.y);
            transform.localScale = new Vector2(0.650246f,0.6502462f);

        }
        else if(movement<0f)
        {
            rigidbody.velocity = new Vector2(movement * speed, rigidbody.velocity.y);
            transform.localScale = new Vector2(-0.650246f,0.650246f);
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }
     
        if(Input.GetButtonDown("Jump") && isTouchingGround )
        {
            
            rigidbody.velocity = new Vector2(rigidbody.velocity.x,jumpspeed);
            

        }

        playerAnimation.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "FallDetector")
        {

            gameLevelManager.Respawn();

        }

        if (other.tag == "CheckPoint")
        {
            respawnPoint = other.transform.position;

        }
      if(other.tag =="Bomb")
        {
   
            gameLevelManager.Respawn();
           
        }
        if (other.tag == "EndLevel1")
        {
            
            gameLevelManager.Score();
 

        }
        if (other.tag == "Enemy")
        {

            if (transform.position.y > other.transform.position.y+2f)
            {
                //Destroy enemy
                
                Destroy(other.transform.gameObject);
            }
            else
            {
                //Destroy player and do other stuff
                playerAnimation.SetBool("death", true);
                end();
            }
        }

       
   
       
       
    }
    public void end()
    {
        StartCoroutine("resetGame");

    }

    public IEnumerator resetGame()
    {
        
        yield return new WaitForSeconds(endGameDelay);
        SceneManager.LoadScene("menu");
       

    }

    


}
