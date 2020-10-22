﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIREBLL_SCRIPT : MonoBehaviour
{
    //calls the player script for unlock
    public PLAYER_SCRIPT unlock;

    //sets the fireball up for other scripts
    public static FIREBLL_SCRIPT fire;

    //the fireball game object
    GameObject fireball;

    //the true variable
   public bool shoot;

    //prefab for the fireball game object
   public GameObject FireballPrefab;

    //spawn point for the fireball
    public GameObject FireballSpawn;
    
    //checks if the players right
    bool righttrue;
    // Start is called before the first frame update

        
     void Awake()
    {
        //makes the script equal to itself
        fire = this;
    }
  

    // Update is called once per frame
    void Update()
    {

        handleMovement();

       
        //checks to see if only the O key is hit
            if ((Input.GetKeyDown(KeyCode.O) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.W)))
        {
            //checks if its unlocked
            if (unlock.fireunlock == 1)
            {
                //checks if manas greater than 1
                if (MP_SCRIPT.mana.Mp.value >= 1)
                {

                    //finally shoots it
                    Fire();

                    MP_SCRIPT.mana.Mp.value -= 1;
                }
                else
                {
                    shoot = false;

                    MP_SCRIPT.mana.Mp.value = 0;
                    Debug.Log("Fire");
                }
            }

            else
            {
                shoot = false;

            }


        }
        else
        {
            shoot = false;
        }
            

    }
    void handleMovement()

    {
        //sets the point right
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localPosition = new Vector3(2.9f, 0, 0);
            righttrue = true;
        }

        //sets the point left
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localPosition = new Vector3(-2.9f, 0, 0);
            righttrue = false;
        }




    }
    void Fire()
    {
        //sets the shoot equal to true
        shoot = true;


        //have a bullet

        Debug.Log("normalShot");

      
        //makes a bullet
        fireball = (Instantiate(FireballPrefab, FireballSpawn.transform.position, transform.rotation)) as GameObject;

        //give it force to right

        if (righttrue == true)
        {
            fireball.GetComponent<Rigidbody2D>().AddForce(new Vector2(400, 0));
        }
        //give it force to left

        if (righttrue == false)
        {
            fireball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 0));
        }
        //destroy after 1 second
        Destroy(fireball, 1.0f);


    }


     
    

   
}
