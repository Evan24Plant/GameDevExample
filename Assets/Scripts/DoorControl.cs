using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour {

    private bool doorIsOpen;

	// Use this for initialization
	void Start () {
	    doorIsOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Operate() {
        if (doorIsOpen) {
            iTween.MoveTo(this.gameObject, new Vector3(15.5f, 0, 0), 5);
        } else {
            iTween.MoveTo(this.gameObject, new Vector3(15.5f, -3.86f, 0), 5);
        }

        doorIsOpen = !doorIsOpen;
    }
}
