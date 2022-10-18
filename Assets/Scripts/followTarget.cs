using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTarget : MonoBehaviour {

	public Transform player;
	public Transform bg1;
	public Transform bg2;
	public Transform bg3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player.position.x != transform.position.x && 
		player.position.x > 0 && player.position.x < 12f)
		{
			transform.position = Vector3.Lerp
			(transform.position, new Vector3
			(player.position.x, transform.position.y, transform.position.z), 
			0.1f);
		}
		bg1.transform.position = new Vector2(transform.position.x * 1.0f, bg1.transform.position.y);
		bg2.transform.position = new Vector2(transform.position.x * 0.8f, bg2.transform.position.y);
		bg3.transform.position = new Vector2(transform.position.x * 0.6f, bg3.transform.position.y);
	}
}
