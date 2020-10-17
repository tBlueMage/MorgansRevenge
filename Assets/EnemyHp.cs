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
    Player damage;

    // Start is called before the first frame update
    void Start()
    {      //how the player and damages get found
        var item = GameObject.FindWithTag("Player");
        damage = item.GetComponentInParent<Player>();

    }
    void Update()
    {
        //how enemy dies
        EnemyDead();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {//it detects the sword and soldier collision
        if (collision.tag == "Sword" || collision.tag == "Dog")
        {


                
                    Enemyhealth -= swordhit;

                

            }
       
        //fireball and soldier collision detected
        if (collision.tag == "Fireball" || collision.tag == "Dog")
        {
            Enemyhealth -= 1;
            Debug.Log(Enemyhealth);
        }
        //windwall and soldier collision detected
        if (collision.tag == "WindWall" || collision.tag == "Dog")
        {
            Enemyhealth -= 1;
            Debug.Log(Enemyhealth);
        }
        //explosion and soldier collision detected
        if (collision.tag == "Explosion" || collision.tag == "Dog")
        { 
            Enemyhealth -= 4;
            Debug.Log(Enemyhealth);
        }
        //frostwave and soldier collision detected
        if (collision.tag == "Frost" || collision.tag == "Dog")
        { 
            Enemyhealth -= 4;
            Debug.Log(Enemyhealth);
        }
        //lighting and soldier collision detected
        if (collision.tag == "Lightning" || collision.tag == "Dog")
        {
            Enemyhealth -= 1;
            Debug.Log(Enemyhealth);
        }
        //lava and soldier collision detected
        if (collision.tag == "Lava" || collision.tag == "Dog")
        {
            Enemyhealth -= 999;
            Debug.Log(Enemyhealth);
        }
        //water and soldier collision detected
        if (collision.tag == "Water" || collision.tag == "Dog")
        {
            Enemyhealth -= 999;
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
