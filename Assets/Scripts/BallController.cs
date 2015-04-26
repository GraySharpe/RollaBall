using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour 
{
	public float moveSpeed;
	public float jumpspeed;
	bool isGrounded = true;
	private Vector3 spawn;
	public GameObject deathParticle;

	void Start () 
	{
		spawn = transform.position;
		}
		
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
		if (collision.collider.CompareTag("Ground")||(collision.collider.CompareTag("Platform")))
		{
			isGrounded = true;
		}
		if (collision.transform.tag == "Enemy")
		{
			LivesTracker.Instance.Addscore(-1);
			Die();
			
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
	void Die()
	{
		Instantiate(deathParticle, transform.position, Quaternion.Euler(270,0,0));
		            transform.position = spawn;
		            }
	
}