using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDrop : MonoBehaviour
{
    public Transform spawn;

    public GameObject GoldCoin;
    public GameObject CoinBag;
    public DETHSPWN_SCRIPT drop;
    public int goldAmount;

    // Start is called before the first frame update
    void Start()
    {
        drop = GetComponent<DETHSPWN_SCRIPT>();

        goldAmount = Random.Range(1, 2);

    }

    // Update is called once per frame
    void Update()
    {
        LootDrop();

    }

    void LootDrop()
    {

        if (drop.itemdrop == true)
        {
            Debug.Log("hi tim");
            goldAmount = Random.Range(1, 2);
            drop.itemdrop = false;
            //when the player collides with a test dummy drop an object from 1 to 7
            if (goldAmount == 1)
            {
                GameObject drop1;

                drop1 = (Instantiate(GoldCoin, spawn.transform.position, transform.rotation)) as GameObject;
                drop1.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

            }
           
            if (goldAmount == 2)
            {
                GameObject drop4;
                drop4 = (Instantiate(CoinBag, spawn.transform.position, transform.rotation)) as GameObject;
                drop4.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

            }
        }
    }
}
