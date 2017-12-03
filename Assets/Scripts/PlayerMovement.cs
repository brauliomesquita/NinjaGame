using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D _rb;
	private Animator _an;

	public float speed = 10f;
	public float jumpForce = 400f;
	public float maxVelocityX = 4f;

	private bool _grounded;

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody2D> ();	
		_an = GetComponent<Animator> ();	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		var force = new Vector2 (0f, 0f);
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		var absVelX = Mathf.Abs (_rb.velocity.x);
		var absVelY = Mathf.Abs (_rb.velocity.y);

		_grounded = absVelY == 0;

		if (absVelX < maxVelocityX) {
			force.x = speed * moveHorizontal;
		}

		if (_grounded && Input.GetButton ("Jump")) {
			_grounded = false;
			force.y = jumpForce;
			_an.SetInteger ("AnimState", 2);
		}

		_rb.AddForce (force);

		var state = _an.GetInteger ("AnimState");

		if (moveHorizontal > 0 && state != 3) {
			transform.localScale = new Vector3 (1, 1, 1);
			if (_grounded) {
				_an.SetInteger ("AnimState", 1);
			}
		} else if (moveHorizontal < 0 && state != 3) {
			transform.localScale = new Vector3 (-1, 1, 1);
			if (_grounded) {
				_an.SetInteger ("AnimState", 1);
			}
		} else if (moveVertical < 0 && state == 1) {
			if (_grounded) {
				_an.SetInteger ("AnimState", 3);
			} 
		} else if (_grounded){
			_an.SetInteger ("AnimState", 0);
		}



	}
}
