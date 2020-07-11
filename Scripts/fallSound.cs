using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallSound : MonoBehaviour
{
    // Start is called before the first frame update
    protected AudioSource fallsound;
    void Start()
    {
        fallsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            fallsound.Play();
        }
    }
}
