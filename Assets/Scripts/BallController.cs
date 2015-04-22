using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour 
{
	public float moveSpeed;
	public float jumpspeed;
	bool isGrounded = true;
	
	void Update () 
	{
		float x = Input.GetAxis ("Horizontal")*moveSpeed * Time.deltaTime;
		float z = Input.GetAxis ("Vertical")*moveSpeed * Time.deltaTime;
		Vector3 force = new Vector3(x, 0f, z);
		if(Input.GetButton ("Jump")&& isGrounded)
		{
			force.y = jumpspeed;
			isGrounded = false;
		}
		rigidbody.AddForce (force);
		}
		void OnCollisionEnter(Collision collision)
		{
		if (collision.collider.CompareTag("Ground"))
		{
			isGrounded = true;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Coin"))
		{
			other.gameObject.SetActive(false);
			ScoreTracker.Instance.Addscore(10);
		}
	}
}
