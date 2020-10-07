using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

   

    public GameObject FireballPrefab;
    public GameObject FireballSpawn;

    // Start is called before the first frame update
    void Start()
    {




        
    }

    // Update is called once per frame
    void Update()
    {

       


                if ((Input.GetKeyDown(KeyCode.O) &&!Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.W)))
                {
                    Fire();
                }



            

    }
    void Fire()
    {
        //have a bullet
        GameObject blade;

        Debug.Log("normalShot");

        //make a bullet
        blade = (Instantiate(FireballPrefab, FireballSpawn.transform.position, transform.rotation)) as GameObject;

        //give it force
        blade.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 0));

        //destroy after 2 seconds
        Destroy(blade, 1.0f);

       

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.tag == "Fireball" || collision.tag == "Soldier")
        {

            Destroy(gameObject);

    }

}

   
}
