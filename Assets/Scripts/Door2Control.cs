using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2Control : MonoBehaviour {

    private bool doorIsOpen;

    // Use this for initialization
    void Start() {
        doorIsOpen = false;
    }

    // Update is called once per frame
    void Update() {

    }

    public void Operate() {
        if (doorIsOpen) {
            iTween.MoveTo(this.gameObject, new Vector3(0, 0, 24.5f), 5);
        } else {
            iTween.MoveTo(this.gameObject, new Vector3(0, -3.86f, 24.5f), 5);
        }

        doorIsOpen = !doorIsOpen;
    }
}