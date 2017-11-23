using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	public GameObject bullerPrefab;
	public Transform spwanObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			GameObject go = Instantiate (bullerPrefab, spwanObject.position, spwanObject.rotation) as GameObject;
			go.GetComponent<Rigidbody> ().AddForce (transform.forward * 30, ForceMode.Impulse);
		}
	}
}
