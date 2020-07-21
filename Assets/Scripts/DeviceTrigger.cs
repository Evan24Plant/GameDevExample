using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceTrigger : MonoBehaviour {

    private bool door3Lock;

    [SerializeField] private GameObject device;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake() {
        door3Lock = true;
        Messenger<int>.AddListener(GameEvent.KEY_COLLECTED, OnKeyCollected);
    }

    void OnDestroy() {
        Messenger<int>.RemoveListener(GameEvent.KEY_COLLECTED, OnKeyCollected);
    }

    void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            DoorControl door = device.GetComponent<DoorControl>();
            if (door != null) {
                door.Operate();
            }

            Door2Control door2 = device.GetComponent<Door2Control>();
            if (door2 != null) {
                door2.Operate();
            }

            Door3Control door3 = device.GetComponent<Door3Control>();
            if (door3 != null && !door3Lock) {
                door3.Operate();
            } else if (door3 != null) {
                Messenger.Broadcast(GameEvent.DOOR3_LOCKED);
            }

            Door4Control door4 = device.GetComponent<Door4Control>();
            if (door4 != null) {
                door4.Operate();
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.name == "Player") {
            DoorControl door = device.GetComponent<DoorControl>();
            if (door != null) {
                door.Operate();
            }

            Door2Control door2 = device.GetComponent<Door2Control>();
            if (door2 != null) {
                door2.Operate();
            }

            Door3Control door3 = device.GetComponent<Door3Control>();
            if (door3 != null && !door3Lock) {
                door3.Operate();
            }

            Door4Control door4 = device.GetComponent<Door4Control>();
            if (door4 != null && !door3Lock) {
                door4.Operate();
            }
        }
    }

    void OnKeyCollected (int keys) {
        if (keys > 1) {
            door3Lock = false;
            Messenger.Broadcast(GameEvent.DOOR3_UNLOCKED);
        }
    }
}
