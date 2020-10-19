using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowSword : MonoBehaviour
{
    public GameObject swordPrefab;
    public GameObject SwordSpawn;
    public static LowSword lowslash;

    public bool slash = false;

    void Awake()
    {
        lowslash = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        var reference = GameObject.FindGameObjectWithTag("Player");



    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();




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

    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localPosition = new Vector3(2.4f, -2.6f, 0);

        }

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

        //destroy after 2 seconds
        Destroy(blade, 0.25f);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Sword" || collision.tag == "Soldier")
        {

            Destroy(gameObject);

        }


    }


}
