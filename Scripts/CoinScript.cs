using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngineInternal;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    private LevelManager gameLevelManager;
    public int coinValue;
    protected AudioSource coinSound;


    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
        coinSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            coinSound.Play();
            gameLevelManager.addCoins(coinValue);
            yield return new WaitForSeconds(coinSound.clip.length/2);
            Destroy(gameObject);
        }
    }

}
