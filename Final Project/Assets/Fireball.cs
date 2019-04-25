using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fireball : MonoBehaviour
{

   
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //if(col.gameObject.tag == "Enemy")
        //{
        //    Destroy(gameObject);
        //    Destroy(col.gameObject);
           
        //}

        if (col.gameObject.tag == "Enemy1")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
           
        }
    }

}
