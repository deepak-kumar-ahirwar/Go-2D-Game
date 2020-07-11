using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scheckpointSound : MonoBehaviour
{
    // Start is called before the first frame update
    protected AudioSource checkpointsound;
    void Start()
    {
        checkpointsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            checkpointsound.Play();
        }
    }
}
