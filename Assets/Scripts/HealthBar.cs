﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
	public float maxHealth = 100;
	public float currentHealth = 100;
	private float originalScale;

	// Use this for initialization
	void Start () {
		originalScale = gameObject.transform.localScale.x;
		
	}
	
	// Update is called once per frame
	
}
