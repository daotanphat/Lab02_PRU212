using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] float forceX = 1f;
	[SerializeField] float forceY = 1f;
	Rigidbody2D rigidbody;
	Animator animator;
	bool isRight = true;
	bool isGrounded;
	float horizontalAxis;
	// Start is called before the first frame update
	void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		horizontalAxis = Input.GetAxis("Horizontal");

		animator.SetBool("run", horizontalAxis != 0);
		animator.SetBool("isGround", isGrounded);

		if (Input.GetKey(KeyCode.D))
		{
			rigidbody.AddForce(Vector2.right * forceX);
			if (!isRight)
			{
				flipObject();
			}
		}
		else if (Input.GetKey(KeyCode.A))
		{
			rigidbody.AddForce(Vector2.left * forceX);
			if (isRight)
			{
				flipObject();
			}
		}
		else if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && isGrounded)
		{
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, forceY);
			animator.SetTrigger("jump");
			isGrounded = false;
		}
	}

	void flipObject()
	{
		isRight = !isRight;
		Vector3 currentScale = transform.localScale;
		currentScale.x *= -1;
		transform.localScale = currentScale;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			Debug.Log("Collide");
			isGrounded = true;
		}
	}

	public bool canAttack()
	{
		return isGrounded;
	}
}
