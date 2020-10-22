using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class NMYHP_SCRIPT : MonoBehaviour
{
    //the enemy spawn
    public Transform spawn;
    //the enemy animator
    Animator myAnimator;
    //invulnerability timer
    public float invulnertimer;
    //invunerability target
    public float invulnertarget;
    //checks for invincibility
    public bool invicibility;
    //dead variable
    public bool isdead;

    //enemys hp
    public int Enemyhealth;
    //knockback script
    KNCKBCK_SCRIPT struck;
    /*public int lootdrop;
    bool lootonce;
    
    public GameObject Bsnack;
    public GameObject Bmeal;
    public GameObject Mvial;
    public GameObject Mpotion;
    public GameObject GoldCoin;
    public GameObject CoinBag;
    public GameObject GoldBar;
    public GameObject playeref;
    */



    // Start is called before the first frame update
    void Start()
    {
      //  lootdrop = Random.Range(1, 7);

        //gets animator
        myAnimator = GetComponent<Animator>();

        //invunerability timer and target
        invulnertarget = 0.0f;
        invulnertimer = 0.0f;
        //knockback script
        struck = GetComponent<KNCKBCK_SCRIPT>();

    }
    void Update()
    {
        //objectdrop();
        invulerability();
        EnemyDead();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {//it detects the player attacks
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            if (invicibility == false)
            {
                invicibility = true;

                invulnertimer = 2.0f;

                var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();

                Enemyhealth -= damage.Damage;

                struck.knockBack = true;
                Debug.Log(Enemyhealth);

            }
        }
       else if (collision.gameObject.CompareTag("Fireball"))
        {
            if (invicibility == false)
            {
                invicibility = true;

                invulnertimer = 2.0f;

                var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();

                Enemyhealth -= damage.Damage;

                struck.knockBack = true;
                Debug.Log(Enemyhealth);

            }


        }
        //it detects the hazard
        else if (collision.gameObject.CompareTag("Hazard"))
        {

            var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();
            Enemyhealth -= damage.Damage;
        }
    }
    void invulerability()
    {//invcibility when hit
        if (invicibility == true)
        {

            invulnertimer -= Time.deltaTime;

            Debug.Log(invulnertimer);
            if (invulnertimer <= invulnertarget)
            {
                invicibility = false;
                Debug.Log("invicibilitygone");
                invulnertimer = 0.0f;

            }
        }



    }
    //where the enemy code dies
    void EnemyDead() {
        if (Enemyhealth <= 0)
        {
            myAnimator.SetBool("Death", true);

            isdead = true;
                
        }
    }
    /*
    void objectdrop()
    {
        if(isdead==true)

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
    }
    */
}
