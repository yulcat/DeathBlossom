//======= Copyright (c) Valve Corporation, All rights reserved. ===============
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class SteamVR_SpawnGun : MonoBehaviour
{
    public GameObject prefab;
    public Rigidbody attachPoint;

    SteamVR_TrackedObject trackedObj;
    FixedJoint joint;

    public void GrabGun()
    {
		if(joint != null) return;
        var go = GameObject.Instantiate(prefab);
        go.transform.position = attachPoint.transform.position;
        go.transform.rotation = attachPoint.transform.rotation;
		go.GetComponent<HellfireShotgun>().SetDevice(trackedObj);

        joint = go.AddComponent<FixedJoint>();
        joint.connectedBody = attachPoint;
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void FixedUpdate()
    {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (joint != null && device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            var go = joint.gameObject;
            var rigidbody = go.GetComponent<Rigidbody>();
            Object.DestroyImmediate(joint);
			Destroy(go.GetComponent<HellfireShotgun>());
            joint = null;
            Object.Destroy(go, 15.0f);

            // We should probably apply the offset between trackedObj.transform.position
            // and device.transform.pos to insert into the physics sim at the correct
            // location, however, we would then want to predict ahead the visual representation
            // by the same amount we are predicting our render poses.

            var origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
            if (origin != null)
            {
                rigidbody.velocity = origin.TransformVector(device.velocity);
                rigidbody.angularVelocity = origin.TransformVector(device.angularVelocity);
            }
            else
            {
                rigidbody.velocity = device.velocity;
                rigidbody.angularVelocity = device.angularVelocity;
            }

            rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;
        }
    }
}
