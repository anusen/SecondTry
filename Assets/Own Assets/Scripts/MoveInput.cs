using UnityEngine;
using System.Collections;

public class MoveInput : MonoBehaviour {

	public float speed = 10.0f;
	public float jumpPower = 10.0f;

	float distToGround;

	// Use this for initialization
	void Start () {
		distToGround = collider.bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
		float jump = Input.GetAxis ("Vertical");
		float direction = Input.GetAxis ("Horizontal");

		Vector3 curPos = transform.position;
		curPos.x += direction * speed * Time.deltaTime;
		transform.position = curPos;

		if(jump > 0 && IsGrounded()) {
			rigidbody.AddForce(Vector3.up * jumpPower);
			Debug.Log ("Jump");
		}
	}

	bool IsGrounded() {
		return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
	}
}
