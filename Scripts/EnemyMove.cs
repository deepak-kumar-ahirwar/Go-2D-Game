using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed;
    public int MoveDirectionX;
    public PlayerController gamePlayer;
    public float DieDelay;
    public AudioSource gameover;
    public bool Touch;


    void Start()
    {
        gameover = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(MoveDirectionX, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(MoveDirectionX, 0) * speed;
        if (hit.distance < 0.7f)
        {
            
            flip();
         
        }
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            gameover.Play();
        } 
    }

    void flip()
    {
        if (MoveDirectionX > 0)
        {
            
            MoveDirectionX = -1;
        }
        else
        {
            MoveDirectionX = 1;
        }
    }
 
  
}
