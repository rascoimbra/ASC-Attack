using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigosSimples : Enemy
{
	public float walkDistance;

	private bool mov;
	//private bool attack = false;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	protected override void Update()
	{

		base.Update();

		anim.SetBool("mov", mov);
		//anim.SetBool("Attack", attack);

		if (Mathf.Abs(targetDistance) < walkDistance)
		{
			mov = true;
		}

			if (Mathf.Abs(targetDistance) < attackDistance)
			{
				//attack = true;
				mov = false;
			}



	}

	private void FixedUpdate()
	{
		if (mov)
		{
			if (targetDistance < 0)
			{
				rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
				if (!facingRight)
				{
					Flip();
				}
			}
			else
			{
				rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
				if (facingRight)
				{
					Flip();
				}
			}
		}
	}

	public void ResetAttack()
	{
		//attack = false;
	}



}
