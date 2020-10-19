using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    Animator myAnimator;

    public float invulnertimer;
    public float invulnertarget;
    public bool invicibility;
    public bool death;
    public int drop;
    public float deathtimer;
    public float deathtimertarget;
    public float droptimer;
    public float droptimertarget;
    //enemys hp
    public int Enemyhealth = 10;
    //player swords damage
    int swordhit = 1;
    KNOCKBACK_SCRIPT struck;
    //player ref
    public GameObject MyRef1;
    //how you get the crits

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();

        deathtimertarget = 5.0f;
        droptimertarget = 4.99f;

        drop = 0;
        invulnertarget = 0.0f;
        invulnertimer = 0.0f;
        //how the player and damages get found
        struck = GetComponent<KNOCKBACK_SCRIPT>();

    }
    void Update()
    {
        invulerability();
        //how enemy dies
        EnemyDead();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {//it detects the sword and soldier collision
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            if (invicibility == false)
            {
                invicibility = true;

                invulnertimer = 2.0f;

                var damage = collision.gameObject.GetComponent<POWERSCRIPT>();

                Enemyhealth -= damage.Damage;

                struck.knockBack = true;
                Debug.Log(Enemyhealth);

            }
        }

        else if (collision.gameObject.CompareTag("Hazard"))
        {

            var damage = collision.gameObject.GetComponent<POWERSCRIPT>();
            Enemyhealth -= damage.Damage;
        }
    }
    void invulerability()
    {
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



            drop++;
            if (death == true)
            {
                if (deathtimer >= deathtimertarget)
                {


                    Destroy(gameObject);
                }

                
                else
                {
                    deathtimer += Time.deltaTime;
                }


            }

            else
            {
                death = true;
            }
        }
    }
}
