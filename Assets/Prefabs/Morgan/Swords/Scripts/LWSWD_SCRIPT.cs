﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LWSWD_SCRIPT: MonoBehaviour
{
    //gets the sword prefab
    public GameObject swordPrefab;
    //spawns the sword
    public GameObject SwordSpawn;
    //makes the lowsword script static
    public static LWSWD_SCRIPT lowslash;
    //makes the fire bool
    public bool slash = false;

    void Awake()
    {
        lowslash = this;
    }
    
    // Update is called once per frame
    void Update()
    {
        handleMovement();



        //only slashes when crouch is pressed
        if ((Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.K)) || (Input.GetKeyDown(KeyCode.K) && Input.GetKey(KeyCode.S)))
        {
            Fire();
          
        }
        else
        {
           slash = false;
        }
    }
    void handleMovement()

    {//makes the sword face right
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localPosition = new Vector3(2.4f, -2.6f, 0);

        }
        //makes the sword face left
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localPosition = new Vector3(-2.4f, -2.6f, 0);

        }





    }
    void Fire()
    {


       
            Debug.Log("lowSlash");
            //have a bullet
            GameObject blade;



            //make a bullet
            blade = (Instantiate(swordPrefab, SwordSpawn.transform.position, transform.rotation)) as GameObject;

            //give it force
            blade.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));
        slash = true;

        //destroy after 0.25 seconds
        Destroy(blade, 0.25f);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //destroys on enemy collision

        if (collision.gameObject.CompareTag("Enemy"))
        {

            Destroy(gameObject);

        }


    }


}
