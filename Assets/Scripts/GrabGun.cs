using UnityEngine;
using System.Collections;

public class GrabGun : MonoBehaviour {
	SteamVR_SpawnGun spawner;

	// Use this for initialization
	void Start () {
		spawner = GetComponentInParent<SteamVR_SpawnGun>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		if(col.GetComponent<ChestReload>()!=null)
			spawner.GrabGun();
	}
}
