﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    public CHASEN_SCRIPT level;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Water")
        {
           level.changeScene(2);
        }
    }
}
