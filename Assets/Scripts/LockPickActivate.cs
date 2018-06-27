using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPickActivate : MonoBehaviour
{
    public GameObject lockPickGame;
    public GameObject lockPickGameLocation;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void MoveToLockPickGame()
    {
        lockPickGame.SetActive(true);
        Camera.main.GetComponentInParent<Transform>().position = lockPickGameLocation.transform.position;
    }
}
