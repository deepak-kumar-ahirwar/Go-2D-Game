using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPlank : MonoBehaviour
{
    public float  delaytime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "planktemp")
        {
            yield return new WaitForSeconds(delaytime);
            Destroy(gameObject);
        }
    }

}
