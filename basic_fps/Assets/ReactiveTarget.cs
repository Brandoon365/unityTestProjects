﻿using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	public void ReactToHit() {
		WanderingAI behavior = GetComponent<WanderingAI>();
		if ((behavior != null) && (behavior.IsAlive())) {
			behavior.SetAlive(false);
			StartCoroutine(Die());
		}

	}

	private IEnumerator Die() {
		this.transform.Rotate(-75, 0, 0);
		yield return new WaitForSeconds(1.5f);
		Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
