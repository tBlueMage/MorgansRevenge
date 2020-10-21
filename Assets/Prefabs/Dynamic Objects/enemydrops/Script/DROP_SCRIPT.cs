using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class DROP_SCRIPT : MonoBehaviour
{//how the dropprefab is called
    
    //how the objects drop
    public Transform spawn;
    public DETHSPWN_SCRIPT drop;
    public GameObject Bsnack;
    //public GameObject Bmeal;
    public GameObject Mvial;
   // public GameObject Mpotion;
    public GameObject GoldCoin;
    public GameObject CoinBag;
   // public GameObject GoldBar;
    public GameObject playeref;
    //player is called
    PLAYER_SCRIPT players;
    //int for the drop
    public int item;

    // Start is called before the first frame update
    void Start()
    {

        drop = GetComponent<DETHSPWN_SCRIPT>();

      
        //the range of the objects being dropped
        item = Random.Range(1, 4);
        
        //how player is called
        var player = GameObject.FindWithTag("Player");
        players = player.GetComponentInParent<PLAYER_SCRIPT>();
    }

     void Update()
    {
        LootDrop();

    }

    void LootDrop()
    {

        if (drop.itemdrop == true)
        {
            
            item = Random.Range(1, 4);
            drop.itemdrop = false;
            //when the player collides with a test dummy drop an object from 1 to 7
            if (item == 1)
            {
                GameObject drop1;

                drop1 = (Instantiate(CoinBag, spawn.transform.position, transform.rotation)) as GameObject;
                drop1.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

            }
            if (item == 2)
            {
                GameObject drop2;

                drop2 = (Instantiate(Bsnack, spawn.transform.position, transform.rotation)) as GameObject;
                drop2.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

            }
            if (item == 3)
            {
                GameObject drop3;

                drop3 = (Instantiate(Mvial, spawn.transform.position, transform.rotation)) as GameObject;
                drop3.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

            }
            if (item == 4)
            {
                GameObject drop4;
                drop4 = (Instantiate(GoldCoin, spawn.transform.position, transform.rotation)) as GameObject;
                drop4.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

            }
            /*
            if (item == 5)
            {
                GameObject drop5;

                drop5 = (Instantiate(GoldBar, spawn.transform.position, transform.rotation)) as GameObject;
                drop5.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

            }

            if (item == 6)
            {
                GameObject drop6;
                drop6 = (Instantiate(CoinBag, spawn.transform.position, transform.rotation)) as GameObject;
                drop6.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

            }
            if (item == 7)
            {
                GameObject drop7;

                drop7 = (Instantiate(GoldCoin, spawn.transform.position, transform.rotation)) as GameObject;
                drop7.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

            }
            //resets the drop range for the item drop

    */
        }
    }
    
}
