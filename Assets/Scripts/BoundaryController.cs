using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour {

	private void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log ("Crate exit");
		if (other.tag == "Crate") {
			Destroy (other.gameObject);
		}
	}
}
