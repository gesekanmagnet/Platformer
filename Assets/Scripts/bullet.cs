using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col)
 	{
 		if (col.collider.tag == "Player" && col.collider.tag=="Ground")
 			Destroy(this.gameObject);
 		if (col.collider.tag == "Enemy")
 		{
 			col.collider.SendMessage("TakeDamage", 1);
			Destroy(this.gameObject);
 		}
 		Destroy(this.gameObject);
	}
}