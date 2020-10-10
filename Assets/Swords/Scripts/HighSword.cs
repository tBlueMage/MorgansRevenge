using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighSword : MonoBehaviour
{
    public GameObject swordPrefab;
    public GameObject SwordSpawn;


    public bool highslash = false;

    // Start is called before the first frame update
    void Start()
    {

        var reference = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {




        if ((Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.X)) || (Input.GetKeyDown(KeyCode.X) && Input.GetKey(KeyCode.Space)))
        {
            highslash = true;
            Fire();
        }

        else
        {
            highslash = false;
        }
    }
    void Fire()
    {

       

            Debug.Log("HighSlash");
            //have a bullet
            GameObject blade;



            //make a bullet
            blade = (Instantiate(swordPrefab, SwordSpawn.transform.position, transform.rotation)) as GameObject;

            //give it force
            blade.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

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
