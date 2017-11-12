using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDirection : MonoBehaviour {

	public float windChangeTime;
	private float timeCount = 0;
	private float t;
	// Use this for initialization
	void Start () {
		
	}

	void Update(){
			float t = Time.deltaTime - timeCount;
			if (t == 3) {
				timeCount = t;
				transform.rotation = Random.rotation;
			}
		}		
}
