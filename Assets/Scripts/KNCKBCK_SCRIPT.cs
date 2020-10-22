using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KNCKBCK_SCRIPT : MonoBehaviour
{
	public Rigidbody2D rb;
	public bool knockBack;
	public float thrust;
	// Use this for initialization
	void Start()
	{
		rb = this.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		knocked();
	}


	void knocked()
	{
		if (knockBack== true)
		{
			knockBack = false;
			//if intfont of player make - thrust if behind player make thrust
			rb.AddForce(transform.right * -thrust);
			rb.AddForce(transform.up * thrust);
		}

	}	
}
