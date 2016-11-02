using UnityEngine;
using System.Collections;

public class CameraMotor : MonoBehaviour {

	private Transform lookAt;
	private Vector3 startOffset;
	private Vector3 moveVector;

	private float transition = 0.0f;
	private float animationDuration = 2.0f;
	private Vector3 animationOffset = new Vector3 (0, 5, 4);

	// Use this for initialization
	void Start () {
		lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
		startOffset = transform.position - lookAt.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		moveVector = lookAt.position + startOffset;
		//x - Left & Right
		moveVector.x = 1.5f;
		//y - up & down
		moveVector.y = Mathf.Clamp(moveVector.y,3,4); 
		//z

		if (transition > 1.0f) 
		{
			transform.position = moveVector;
		} 
		else 
		{
			//Animation at the start of the game
			transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector,transition);
			transition += Time.deltaTime * 1 / animationDuration;
			transform.LookAt (lookAt.position + Vector3.up);
		}

		//transform.position = lookAt.position;
	}
}
