using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour {

	private CharacterController controller;
	private float speed = 5.0f;
	private Vector3 moveVector;
	private float verticalVelocity = 0.0f;
	private float gravity = 12.0f;
	private bool isDead = false;

	private float animationDuration = 2.0f;
	private float startTime;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if(isDead)
		{
			return;
		}
		if (Time.time - startTime < animationDuration) 
		{
			controller.Move (Vector3.forward * speed * Time.deltaTime);
			return;
		}
		moveVector = Vector3.zero;

		if (controller.isGrounded) 
		{
			// is on the floor and will not fall
			verticalVelocity = -0.3f;
		} 
		else
		{
			verticalVelocity -= gravity * Time.deltaTime;
		}

		//x - Left & Right
		//press left or right arrow or a or d in keyboard will go left or right
		moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
		if (Input.GetMouseButton (0)) {
			//Are we holding touch on right side?
			if (Input.mousePosition.x > Screen.width / 2)
				moveVector.x = speed;
			else
				moveVector.x = -speed;
		}

		//y - up & down
		moveVector.y = verticalVelocity;

		//z - Forward & Backward
		moveVector.z = speed;

		// move forward 5m every single second
		controller.Move (moveVector * Time.deltaTime);
	}

	public void SetSpeed(float modifier)
	{
		speed = 5.0f + modifier;
	}

	// It is begin called every time our capsule hits something
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.point.z > transform.position.z + 0.1f && hit.gameObject.tag == "Enemy") 
		{
			Death ();
		}
	}

	private void Death(){
		isDead = true;
		GetComponent<Score> ().OnDeath ();
		Debug.Log ("Dead");
	}
}
