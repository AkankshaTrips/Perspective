using UnityEngine;
using System.Collections;

public class WallNormal : MonoBehaviour {

	public Vector3 normal;

	// Use this for initialization
	void Start () {
		normal = gameObject.GetComponent<Vector3> ();
	}

}
