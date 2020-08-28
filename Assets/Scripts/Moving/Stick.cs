using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.UNetWeaver;
using UnityEngine;

public class Stick : MonoBehaviour
{
	public Joystick joystick;
	
	private float speed = 6f;
	private float speedLimit = 1.5f;
	private float jumpLimit = 7f;
	private float jumpForce = 7f;
	private float time = 0.05f;
	private float rotationForce = 3.5f;
	private Vector2 force = new Vector2(5,1);
	
	private Rigidbody2D body;
	
	private float horizontalMove;
	private float verticalMove;

	private Vector2 targetRight;
	private Vector2 targetLeft;
	
	private float targetRightX;
	private float targetLeftX;
	
	private float targetY;

	private bool isGround;

	List<Collider2D> GroundColliders = new List<Collider2D>();

	private int flip = 0;
	
	public AudioSource _audio;


	void Start()
	{
		body = GetComponent<Rigidbody2D>();
		_audio = GetComponent<AudioSource>();
	}
	void OnCollisionStay2D(Collision2D coll)
	{
		var myCollider = GetComponent<BoxCollider2D>();
		
		if (!GroundColliders.Contains(coll.collider))   
			foreach (var p in coll.contacts)
				if (p.point.y < myCollider.bounds.min.y)
				{
					GroundColliders.Add(coll.collider);
					
					break;
				}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		_audio.Play();
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (GroundColliders.Contains(coll.collider))
			GroundColliders.Remove(coll.collider);
	}
	
	void FixedUpdate()
	{
		targetRightX = transform.position.x + transform.localScale.x / 2f;
		targetLeftX = transform.position.x - transform.localScale.x / 2f;
		
		targetY = transform.position.y + transform.localScale.y / 2f;

		var moveHorizontal = joystick.Horizontal;

		isGround = GroundColliders.Count > 0;
		
		if (moveHorizontal > 0.9f && isGround)
		{
			targetRight = new Vector3(targetRightX, targetY);
			body.AddForceAtPosition(Vector3.right * speed, targetRight);
			flip = 1;
		}

		if (moveHorizontal < -0.9f && isGround)
		{
			targetLeft = new Vector3(targetLeftX, targetY);
			body.AddForceAtPosition(Vector3.left * speed, targetLeft);
			flip = -1;
		}
		// Ограничение скорости
		if(Mathf.Abs(body.velocity.x) > speedLimit)
		{
			body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speedLimit, body.velocity.y);
		}
		
		if(Mathf.Abs(body.velocity.y) > jumpLimit)
		{
			body.velocity = new Vector2(body.velocity.x, Mathf.Sign(body.velocity.y) * jumpLimit);
		}
		
	}

	public void JumpButton()
	{
		if (isGround)
		{
			StartCoroutine(Jump());
		}
	}
	
	IEnumerator Jump()
	{
		if (isGround)
		{
			targetRightX = transform.position.x + transform.localScale.x / 2f;
			targetLeftX = transform.position.x - transform.localScale.x / 2f;
			
			targetY = transform.position.y - transform.localScale.y / 2f;

			targetRight = new Vector2(targetRightX,targetY);
			targetLeft = new Vector2(targetLeftX,targetY);
			
			if (flip == 1)
			{
				body.AddForce(force * jumpForce, ForceMode2D.Impulse);
				yield return new WaitForSeconds(time);
			
				body.AddForceAtPosition(Vector3.left * jumpForce * rotationForce, targetRight);
			}
			else if (flip == -1)
			{
				body.AddForce(new Vector2(-force.x, force.y) * jumpForce, ForceMode2D.Impulse);
				yield return new WaitForSeconds(time);
			
				body.AddForceAtPosition(Vector3.right * jumpForce * rotationForce, targetLeft);
			}
			
			
		}

	}
}
