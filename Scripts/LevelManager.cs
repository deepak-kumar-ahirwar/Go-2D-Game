using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController gamePlayer;
    public float respawndelay;
    public int coins;
    public Text coinText;
    public Text leftTime;
    public bool touch;
    public float timeLeft=150;
    public float Scores;
    public int PlayerScore;
    public Text EndLevel1;
    public int endGameDelay;
 

    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController>();
        coinText.text = "coins: " + coins;
        leftTime.text = "Time Left:" + timeLeft;

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
       leftTime.text = "Time Left:" + (int)timeLeft;  
        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene("menu");
        }
    }
    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
 
    }
    
    public IEnumerator RespawnCoroutine()
    {
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawndelay);
        gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.gameObject.SetActive(true);
        
        
    }
  
    public void addCoins(int numberOfCoins)
    {
        coins += numberOfCoins;
        coinText.text = "Coins: " + coins;
    }

   
    public void Score()
    {
        EndLevel1.text ="You Won\n" +"Total Scores: " + (int)PlayerScore + "\n Total Coins:" + (int)coins + "\n ";
        PlayerScore += (int)(timeLeft * 10);
    }


   
}
