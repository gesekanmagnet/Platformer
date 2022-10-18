using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class soundManager : MonoBehaviour {

	private static soundManager instance = null;
 	public static soundManager Instance
 	{
 		get { return instance; }
 	}
 	void Awake()
 	{
 		if (instance != null && instance != this)
 		{
 			Destroy(this.gameObject);
 			return;
 		}
 		else
 		{
 			instance = this;
 		}
 		DontDestroyOnLoad(this.gameObject);
	}
}