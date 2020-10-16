using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    //enemys hp
    public int Enemyhealth = 10;
    //player swords damage
    int swordhit = 1;

    //player ref
    public GameObject MyRef1;
    //how you get the crits

    // Start is called before the first frame update
    void Start()
    {      //how the player and damages get found

    }
    void Update()
    {
        //how enemy dies
        EnemyDead();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {//it detects the sword and soldier collision
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            var damage = collision.gameObject.GetComponent<POWERSCRIPT>();

            Enemyhealth -= damage.Damage;


            Debug.Log(Enemyhealth);


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
