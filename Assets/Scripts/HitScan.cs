using UnityEngine;
using System.Collections;

public class HitScan : MonoBehaviour {

	// Use this for initialization
	public void Scan () {
		Ray ray = new Ray(transform.position, transform.up * -1);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 40))
		{
			var plate = hit.collider.GetComponent<TargetCollider>();
			if(plate != null)
			{
				plate.target.Smash();
			}
			var effect = EffectSpawner.GetEffect("Spark");
			effect.SetActive(true);
			effect.transform.position = hit.point;
			effect.transform.rotation = Quaternion.LookRotation(hit.normal);
		}
		gameObject.SetActive(false);
	}
}
