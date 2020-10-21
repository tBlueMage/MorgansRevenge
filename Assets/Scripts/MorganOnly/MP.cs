using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MP : MonoBehaviour
{
    public Slider Mp;
    public static MP mana;

    private void Awake()
    {
        mana = this;
    }
}
