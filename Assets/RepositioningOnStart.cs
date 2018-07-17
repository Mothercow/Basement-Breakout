using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositioningOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
