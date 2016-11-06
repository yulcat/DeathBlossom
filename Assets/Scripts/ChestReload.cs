using UnityEngine;
using System.Collections;

public class ChestReload : MonoBehaviour {
	public Transform head;
	Vector3 deltaPosition; 

	// Use this for initialization
	void Start () {
		deltaPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.rotation = Quaternion.Euler(0,head.rotation.eulerAngles.y,0);
		transform.position = head.position + deltaPosition + transform.forward * -0.1f;
	}
}
