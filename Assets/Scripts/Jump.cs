using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
    public float jumpVelocity;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
        }
	}
}
