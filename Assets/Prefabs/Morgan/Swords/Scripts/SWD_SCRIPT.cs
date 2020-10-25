﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWD_SCRIPT : MonoBehaviour
{
    //gets the sword prefab
    public GameObject swordPrefab;
    //spawns the sword
    public GameObject SwordSpawn;

    //makes the sword script static
    public static SWD_SCRIPT midslash;
    //the fire bool
    public bool slash = false;



     void Awake()
    {
        midslash = this;
    }



    // Update is called once per frame
    void  Update()
    {
        handleMovement();




        //makes the midslash happen when jump or crouch is pressed
        if (Input.GetKeyDown(KeyCode.K) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.Space))
        {
            Fire();
            Debug.Log("true");
        }


        else
        {
            slash = false;

        }
    }
    void handleMovement()


    {
        //makes sword face right
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localPosition = new Vector3(3.2f, 0, 0);

        }
        //makes sword face left
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localPosition = new Vector3(-3.2f, 0, 0);

        }




    }
    void Fire()
    {
      
            //have a bullet
            GameObject blade;

            Debug.Log("normalShot");

            //make a bullet
            blade = (Instantiate(swordPrefab, SwordSpawn.transform.position, transform.rotation)) as GameObject;

            //give it force
            blade.GetComponent<Rigidbody2D>().MovePosition(SwordSpawn.transform.position);

        //destroy after 0.10 seconds
        Destroy(blade, .10f) ;
        //makes slash equal true
        slash = true;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //destroys on collision with enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Destroy(gameObject);

        }

    }




}
