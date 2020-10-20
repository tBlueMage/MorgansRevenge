using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public static Fireball fire;
    GameObject fireball;
   public bool shoot;
    public GameObject FireballPrefab;
    public GameObject FireballSpawn;
    bool righttrue;
    // Start is called before the first frame update

     void Awake()
    {

        fire = this;
    }
    void Start()
    {




        
    }

    // Update is called once per frame
    void Update()
    {

        handleMovement();


                if ((Input.GetKeyDown(KeyCode.O) &&!Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.W)))
                {if (MP.mana.Mp.value >= 1)
            {

                Fire();

                MP.mana.Mp.value -= 1;
            }

            else
            {
                shoot = false;

                MP.mana.Mp.value = 0;
                Debug.Log("Fire");
            }
                }


        else
        {
            shoot = false;
        }
            

    }
    void handleMovement()

    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localPosition = new Vector3(2.9f, 0, 0);
            righttrue = true;
        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localPosition = new Vector3(-2.9f, 0, 0);
            righttrue = false;
        }




    }
    void Fire()
    {
        shoot = true;


        //have a bullet

        Debug.Log("normalShot");

        //make a bullet
        fireball = (Instantiate(FireballPrefab, FireballSpawn.transform.position, transform.rotation)) as GameObject;

        //give it force

        if (righttrue == true)
        {
            fireball.GetComponent<Rigidbody2D>().AddForce(new Vector2(400, 0));
        }
        if (righttrue == false)
        {
            fireball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 0));
        }
        //destroy after 2 seconds
        Destroy(fireball, 1.0f);


    }


     
    

   
}
