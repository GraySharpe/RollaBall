using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public GameObject target; 		// view target
	Vector3 offset; 				// position reletive to our view target

	void Start () 
	{
		// compute the offset relative to our target
		offset = transform.position - target.transform.position;
	}
	

	void Update () 
	{
		transform.position = target.transform.position + offset;
	}
}
