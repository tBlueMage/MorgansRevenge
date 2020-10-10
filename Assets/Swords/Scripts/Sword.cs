﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject swordPrefab;

    public GameObject SwordSpawn;


    public bool slash = false;


    // Start is called before the first frame update
    void Start()
    {
        var reference = GameObject.FindGameObjectWithTag("Player");



    }

    // Update is called once per frame
    void Update()
    {




        if (Input.GetKeyDown(KeyCode.X) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.Space))
        {
            Fire();
            slash = true;

        }

        else
        {
            slash = false;

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

            //destroy after 2 seconds
            Destroy(blade, 0.5f);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Sword" || collision.tag == "Soldier")
        {

            Destroy(gameObject);

        }


  


    }



}
