using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject swordPrefab;

    public GameObject SwordSpawn;

    public static Sword midslash;
    public bool slash = false;


    // Start is called before the first frame update

     void Awake()
    {
        midslash = this;
    }
    void Start()
    {
        var reference = GameObject.FindGameObjectWithTag("Player");



    }


    // Update is called once per frame
    void  Update()
    {
        handleMovement();




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
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localPosition = new Vector3(3.2f, 0, 0);

        }

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

            //destroy after 2 seconds
            Destroy(blade, 0.10f);
        slash = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Sword" || collision.tag == "Soldier")
        {

            Destroy(gameObject);

        }


  


    }



}
