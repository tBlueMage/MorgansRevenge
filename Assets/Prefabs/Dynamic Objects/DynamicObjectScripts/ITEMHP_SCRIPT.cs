using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITEMHP_SCRIPT : MonoBehaviour
{
 //   public Transform spawn;


    Animator myAnimator;
    /*
    public GameObject Bsnack;
    public GameObject Bmeal;
    public GameObject Mvial;
    public GameObject Mpotion;
    public GameObject GoldCoin;
    public GameObject CoinBag;
    public GameObject GoldBar;
    public GameObject playeref;
    */
    bool isdead;
    bool lootonce;
    int lootdrop;
    public int ItemHealth;

    // Start is called before the first frame update

    void Start()
    {
        lootdrop = Random.Range(1, 7);

        myAnimator = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
       // objectdrop();
        LootDead();

    }


    void LootDead()
    {
        if (ItemHealth <= 0)
        {
            myAnimator.SetBool("Dead", true);



            isdead = true;

        }
    }
    /*
    void objectdrop()
    {
        if (isdead == true)

        {
            if (lootonce == true)
            {
                lootonce = false;
                Debug.Log("hi tim");

                //when the player collides with a test dummy drop an object from 1 to 7
                if (lootdrop == 1)
                {
                    GameObject drop1;

                    drop1 = (Instantiate(Bmeal, spawn.transform.position, transform.rotation)) as GameObject;
                    drop1.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

                }
                if (lootdrop == 2)
                {
                    GameObject drop2;

                    drop2 = (Instantiate(Bsnack, spawn.transform.position, transform.rotation)) as GameObject;
                    drop2.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

                }
                if (lootdrop == 3)
                {
                    GameObject drop3;

                    drop3 = (Instantiate(Mvial, spawn.transform.position, transform.rotation)) as GameObject;
                    drop3.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

                }
                if (lootdrop == 4)
                {
                    GameObject drop4;
                    drop4 = (Instantiate(Mpotion, spawn.transform.position, transform.rotation)) as GameObject;
                    drop4.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

                }

                if (lootdrop == 5)
                {
                    GameObject drop5;

                    drop5 = (Instantiate(GoldBar, spawn.transform.position, transform.rotation)) as GameObject;
                    drop5.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

                }

                if (lootdrop == 6)
                {
                    GameObject drop6;
                    drop6 = (Instantiate(CoinBag, spawn.transform.position, transform.rotation)) as GameObject;
                    drop6.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

                }
                if (lootdrop == 7)
                {
                    GameObject drop7;

                    drop7 = (Instantiate(GoldCoin, spawn.transform.position, transform.rotation)) as GameObject;
                    drop7.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

                }
                //resets the drop range for the item drop


            }
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            

                var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();

                ItemHealth -= damage.Damage;


           
        }
        else if (collision.gameObject.CompareTag("Fireball"))
        {

            var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();

            ItemHealth -= damage.Damage;
        }
        else if (collision.gameObject.CompareTag("Hazard"))
        {

            var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();
            ItemHealth -= damage.Damage;
        }
    }
    
}
