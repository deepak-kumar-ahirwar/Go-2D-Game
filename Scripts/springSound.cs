using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class springSound : MonoBehaviour
{
    // Start is called before the first frame update
    protected AudioSource spring;
    void Start()
    {
        spring = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            spring.Play();
        } 
    }
}
