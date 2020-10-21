using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class DestroyBlock : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
    }
   void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        { 
            Destroy(gameObject);
        }
    }
    }