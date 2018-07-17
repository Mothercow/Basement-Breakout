using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTelepads : MonoBehaviour {
    public GameObject Telepads;
    public GameObject Smokeanim;
    
	// Use this for initialization
	void Start () {
        Telepads.SetActive(false);
        Smokeanim.SetActive(false);
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
