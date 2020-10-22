using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DETHSPWN_SCRIPT : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    public GameObject ExplosionSpawn;
    public bool itemdrop;


     
    void SpawnExplosion()
    {

        GameObject Explosion;
        Explosion = (Instantiate(ExplosionPrefab, ExplosionSpawn.transform.position, transform.rotation)) as GameObject;

        Destroy(gameObject);

    }

    void lootdrop()
    {
        itemdrop = true;

    }

}
