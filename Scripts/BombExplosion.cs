using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BombExplosion : MonoBehaviour
{
    // Start is called before the first frame update
   
    public bool bombCheck;
    public PlayerController gamePlayer;
    public Animator bombAnimation;
    public float DieDelay;
    protected AudioSource explode;
    void Start()
    {
        bombAnimation = GetComponent<Animator>();
        gamePlayer = FindObjectOfType<PlayerController>();
        explode = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

   

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="player")
        { 
            bombCheck = true;
            bombAnimation.SetBool("touch", bombCheck);
            PlayerDie();
            explode.Play();
    
        }
        
    
    }

    public void PlayerDie()
    {
        StartCoroutine("resetGame");

    }
    
    public IEnumerator resetGame()
    {
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(DieDelay);
        SceneManager.LoadScene("menu");
        gamePlayer.gameObject.SetActive(true);

    }


}

