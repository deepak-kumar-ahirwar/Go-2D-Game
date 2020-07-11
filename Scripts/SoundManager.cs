using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public  AudioClip jumpSound,hitSound,gameOverSound;
    public  AudioSource audiosrc;
    void Start()
    {
        
        jumpSound = Resources.Load<AudioClip>("jump_21");
        gameOverSound = Resources.Load<AudioClip>("gameOver");
        hitSound = Resources.Load<AudioClip>("hit_05");


        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
  
     public  void playSound (string clip)
    {
        switch (clip)
        {
            
            case "jump_21":
                audiosrc.PlayOneShot(jumpSound);
                break;
            case "hit_05":
                audiosrc.PlayOneShot(hitSound);
                break;
            case "gameOver":
                audiosrc.PlayOneShot(gameOverSound);
                break;
        }
    }
}
