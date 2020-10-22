using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MP_SCRIPT : MonoBehaviour
{
    public Slider Mp;
    public static MP_SCRIPT mana;

    private void Awake()
    {
        mana = this;
    }
}
