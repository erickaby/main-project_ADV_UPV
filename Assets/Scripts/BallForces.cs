using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForces : MonoBehaviour

{

	public float force;

	private Rigidbody RB;

	[SerializeField]

	static readonly float TimeToDie = 20f;

	private void FixedUpdate()

	{

		//direction is the forward vector of the object from localposition of the parent 

		if (transform.parent)

			RB.AddForce(transform.parent.forward * force, ForceMode.VelocityChange);

	}

	Animator animator;

	private void Start()

	{

		RB = GetComponent<Rigidbody>();

		animator = GetComponent<Animator>();

		// Destroy(gameObject, TimeToDie); 

	}

	private bool AlreadyExploited = false;

	private void OnCollisionEnter(Collision collision)

	{

		if (!AlreadyExploited)
		{

			if (collision.gameObject.tag == "Player") Explotion();

			else

			if (collision.gameObject.tag == "furniture") Explotion();

		}

	}



	private void Explotion()

	{

		AlreadyExploited = true;

		animator.SetTrigger("exploit");

		Destroy(gameObject, 2f);   // after explotion we remove the gameobj 

	}

}