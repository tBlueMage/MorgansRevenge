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
        handleMovement();




        if ((Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.K)) || (Input.GetKeyDown(KeyCode.K) && Input.GetKey(KeyCode.Space)))
        {
            highslash = true;
            Fire();
        }

        else
        {
            highslash = false;
        }
    }
    void handleMovement()

    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localPosition = new Vector3(2.7f, 2.1f, -0.5f);

        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localPosition = new Vector3(-2.7f, 2.1f, -0.5f);

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
