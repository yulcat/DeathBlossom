using UnityEngine;
using System.Collections;

public class TargetPlate : MonoBehaviour {
	Vector3 initialRotation;

	// Use this for initialization
	void Start () {
		initialRotation = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
