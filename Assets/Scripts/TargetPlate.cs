using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TargetPlate : MonoBehaviour {
	Vector3 initialRotation;
	float rotation;
	bool moving = false;
	AudioSource source;

	// Use this for initialization
	void Start () {
		initialRotation = transform.localRotation.eulerAngles;
		initialRotation.x = Mathf.DeltaAngle(0f,initialRotation.x);
		rotation = initialRotation.x;
		source = GetComponent<AudioSource>();
		transform.rotation = Quaternion.identity;
		StartCoroutine(Recover());
	}
	
	public void Smash()
	{
		if(moving) return;
		moving = true;
		transform.DOKill();
		transform.DOLocalRotate(Vector3.zero,0.2f).OnComplete(()=>StartCoroutine(Recover()));
	}
	IEnumerator Recover()
	{
		yield return new WaitForSeconds(Random.Range(2f,10f));
		moving = false;
		// source.Play();
		transform.DOLocalRotate(initialRotation,1f);
	}
}
