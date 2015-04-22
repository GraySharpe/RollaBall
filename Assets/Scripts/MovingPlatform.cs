using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour 
{
	public Transform DestinationSpot;
	public Transform OriginSpot;
	public float Speed;
	public bool Switch = false;

	void FixedUpdate()
	{
		//for these 2 if statements, it's checking the position of the platform.
		//if it's at the destination spot, it sets the Switch to true.
		if(transform.position == DestinationSpot.position)
		{
			Switch = true;
		}
		if(transform.position == OriginSpot.position)
		{
			Switch = false;
		}

		// if switch becomes true, it tells the platform to move to its origin.
		if(Switch)
		{
			transform.position = Vector3.MoveTowards(transform.position, OriginSpot.position, Speed);
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, DestinationSpot.position, Speed);

		}
	}
	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.CompareTag("Player"))
		{
			collision.gameObject.transform.parent = this.transform;
		}
	}
	void OnCollisionExit(Collision collision)
	{
		if(collision.collider.CompareTag("Player"))
		{
			collision.gameObject.transform.parent = null;
		}
	}
}

