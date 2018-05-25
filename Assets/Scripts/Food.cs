using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tag {
	public static string Player = "Player";
}

public class Food : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.CompareTag(Tag.Player)) {
			Destroy(gameObject);
		}
	}

}
