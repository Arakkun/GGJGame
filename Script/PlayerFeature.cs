﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeature : MonoBehaviour {
	public Collider2D myCollider;
	// Use this for initialization
	void Start () {
		myCollider = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
