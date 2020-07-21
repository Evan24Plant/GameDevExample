using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3Popup : MonoBehaviour {

    public void Open() {
        this.gameObject.SetActive(true);
    }

    public void Close() {
        this.gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
