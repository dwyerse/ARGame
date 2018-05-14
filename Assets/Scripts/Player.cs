using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    public float turnSpeed = 3.0f;
    public float walkSpeed = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var x = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;
        var z = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * walkSpeed;

        transform.Translate(x, 0, z);

    }
}
