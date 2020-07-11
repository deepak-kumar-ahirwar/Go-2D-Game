using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endLevel1 : MonoBehaviour

{
    public int endGameDelay;
    protected AudioSource won;
    // Start is called before the first frame update
    void Start()
    {
        won = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {

            won.Play();
            end();
            
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