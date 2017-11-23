using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Text countText;
	public Text winText;
	public Text attemptText;

	private Rigidbody rb;
	private int count;
	private int attempt;

	public float moveSensitivityX =  1.0f;
	public float moveSensitivityY = 1.0f;

	private bool        mPositionSet;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		attempt = 0;
		SetCountText ();
		winText.text = "";
//		StartCoroutine( ChangePosition() );
	}

	void Update(){ // Update every frame

//		if (Input.touchCount > 0) {
//			Debug.Log("Touch Detected.");
//			Touch myTouch = Input.GetTouch (0);
//
//			if (myTouch.phase == TouchPhase.Moved) {
//				Debug.Log("Touch Move Detected.");
//				Vector2 delta = myTouch.deltaPosition;
//				float positionX = delta.x * moveSensitivityX * Time.deltaTime;
//				float positionY = delta.y * moveSensitivityY * Time.deltaTime;
//
//				Vector3 movement = new Vector3 (positionX,0.0f,positionY);
//				rb.AddForce (movement * speed, ForceMode.Impulse);
//
//				rb.useGravity = true;
//
//				new WaitForSeconds(3);
//				rb.useGravity = false;
//				StartCoroutine( ChangePosition() );
//				attempt++;
//				SetAttemptText();
//			}
//		}
		// If ball hit surface, reset position
	}

	void FixedUpdate(){ // Update before any physics (Physic logic go here)

			

//		float moveHorizontal = Input.GetAxis("Horizontal");
//		float moveVertical = Input.GetAxis("Vertical");
//
//		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
//
//		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetAttemptText(){
		attemptText.text = "Attempt: " + attempt.ToString () + "/15";
		if (attempt > 15) {
			winText.text = "Try Again! Gotta Catch Em All!";
		}
	}

	void SetCountText(){
		countText.text = "Caught: " + count.ToString();
		if (count >= 10) {
			winText.text = "You Win!";
		}
	}

	// We'll use a Coroutine to give a little
	// delay before setting the position
	private IEnumerator ChangePosition() {

		yield return new WaitForSeconds(0.2f);
		// Define the Spawn position only once
		if ( !mPositionSet ){
			// change the position only if Vuforia is active
			if ( Vuforia.VuforiaBehaviour.Instance.enabled )
				SetPosition();
		}
	}

	// Define the position if the object
	// according to ARCamera position
	private bool SetPosition()
	{
		// get the camera position
		Transform cam = Camera.main.transform;

		// set the position 10 units forward from the camera position
		transform.position = (cam.up * -2) + (cam.forward * 10);
//		rb.useGravity = false;
		return true;
	}
}
	