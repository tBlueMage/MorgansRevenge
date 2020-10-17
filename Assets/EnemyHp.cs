using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public float invulnertimer;
    public float invulnertarget;
    public bool invicibility;
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

                invulnertimer = 5.0f;

                var damage = collision.gameObject.GetComponent<POWERSCRIPT>();

                Enemyhealth -= damage.Damage;

                struck.knockBack = true;
                Debug.Log(Enemyhealth);

            }
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
            Destroy(gameObject);
        }
                         }
}
