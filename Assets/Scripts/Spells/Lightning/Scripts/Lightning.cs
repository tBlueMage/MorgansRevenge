using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{

    public GameObject LightningPrefab;
    public GameObject LightningSpawn;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

   



                if ((Input.GetKeyDown(KeyCode.O) && Input.GetKeyDown(KeyCode.D)))
                {
                    Fire();

                }

            

            
    }

    void Fire()
    {
        //have a bullet
        GameObject light;

        Debug.Log("normalShot");

        //make a bullet
        light = (Instantiate(LightningPrefab, LightningSpawn.transform.position, transform.rotation)) as GameObject;

        //give it force
        light.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

        //destroy after 2 seconds

      Destroy(light, 1.0f);

    }


    
}
