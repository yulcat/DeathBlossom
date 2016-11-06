using UnityEngine;
using System.Collections;

public class TargetCollider : MonoBehaviour {
	public TargetPlate target;

	// Use this for initialization
	void Start () {
		target = GetComponentInParent<TargetPlate>();
	}
}
