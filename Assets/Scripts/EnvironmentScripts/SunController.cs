using UnityEngine;
using System.Collections;

public class SunController : MonoBehaviour {

    public float sunSpeed;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(Vector3.zero, Vector3.right, sunSpeed * Time.deltaTime);
        transform.LookAt(Vector3.zero);
	}
}
