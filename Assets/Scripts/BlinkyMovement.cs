using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkyMovement : MonoBehaviour {
	[SerializeField] private float speed = .3f;

	[SerializeField] private Transform[] waypoints;


	private Rigidbody2D rgbody;

	private Animator anim;
	private int curWaypoint;

	private void Awake() 
	{
		rgbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	private void FixedUpdate() 
	{
		if (transform.position != waypoints[curWaypoint].position) {
			Vector2 p = Vector2.MoveTowards(transform.position, 
											waypoints[curWaypoint].position,
											speed);
			rgbody.MovePosition(p);
		} else {
			//Change to next waypoint index, if all point reach return to first point
			curWaypoint = (curWaypoint+1) % waypoints.Length;
		}
		HandleAnimation();
	}

	private void HandleAnimation()
	{
		Vector2 dir = waypoints[curWaypoint].position - transform.position;
		anim.SetFloat("DirX", dir.x);
		anim.SetFloat("DirY", dir.y);
	}


	private void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.CompareTag(Tag.Player)) {
			Destroy(other.gameObject);
		}
	}

	

}
