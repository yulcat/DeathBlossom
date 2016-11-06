using UnityEngine;
using System.Collections;

public class HellfireShotgun : MonoBehaviour {
	SteamVR_TrackedObject trackedObj;
	public int shotCount = 20;
	public float spread = 4f;
	public Transform muzzle;
	int currentShotLeft = 4;

	public void SetDevice(SteamVR_TrackedObject obj)
	{
		trackedObj = obj;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(trackedObj==null || currentShotLeft<=0) return;
		var device = SteamVR_Controller.Input((int)trackedObj.index);
		if(device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
		{
			currentShotLeft--;
			for(int i=0; i<shotCount; i++)
			{
				var spread2d = (Random.insideUnitSphere + Random.insideUnitSphere) * spread;
				var shot = EffectSpawner.GetEffect("shot");
				shot.transform.position = muzzle.position;
				shot.transform.rotation = muzzle.rotation * Quaternion.Euler(spread2d);
				shot.GetComponent<HitScan>().Scan();
			}
		}
	}
}
