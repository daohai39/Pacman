using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour {
	[SerializeField] private float speed = 0.4f;
	private Vector2 dest = Vector2.zero;
	private Rigidbody2D rgbody;
	private Animator anim;

	private void Start() 
	{
		dest = transform.position;
		rgbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	private void FixedUpdate() 
	{
		if ((Vector2)transform.position == dest) {
			HandleInput();
		}

		HandleMovement();

		HandleAnimation();
	}

	private bool ValidPosition(Vector2 dir) 
	{
		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
		return (hit.collider == GetComponent<Collider2D>());
	}

	private void HandleInput() 
	{
		if(Input.GetKey(KeyCode.UpArrow) && ValidPosition(Vector2.up))
			dest = (Vector2)transform.position + Vector2.up;
		if(Input.GetKey(KeyCode.DownArrow) && ValidPosition(Vector2.down))
			dest = (Vector2)transform.position + Vector2.down;
		if(Input.GetKey(KeyCode.LeftArrow) && ValidPosition(Vector2.left))
			dest = (Vector2)transform.position + Vector2.left;
		if(Input.GetKey(KeyCode.RightArrow) && ValidPosition(Vector2.right))
			dest = (Vector2)transform.position + Vector2.right;
	}

	private void HandleMovement()
	{
		Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
		rgbody.MovePosition(p);
	}

	private void HandleAnimation() 
	{
		Vector2 dir = dest - (Vector2)transform.position;
		anim.SetFloat("DirX", dir.x);
		anim.SetFloat("DirY", dir.y);
	}
}
