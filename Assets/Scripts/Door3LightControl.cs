using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3LightControl : MonoBehaviour {

    Light light;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        light.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake() {
        Messenger.AddListener(GameEvent.DOOR3_UNLOCKED, OnDoor3Unlocked);
    }

    void OnDestroy() {
        Messenger.RemoveListener(GameEvent.DOOR3_UNLOCKED, OnDoor3Unlocked);
    }

    private void OnDoor3Unlocked() {
        light.color = Color.green;
    }
}
