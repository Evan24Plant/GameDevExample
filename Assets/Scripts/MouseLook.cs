using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
	// enum to set values by name instead of number.
	// makes code more reliable!
	public enum RotationAxes {MouseXAndY = 0, MouseX = 1, MouseY = 2}

	// public class-scope variable so it shows up in Inspector
	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityHorz = 7.0f;
	public float sensitivityVert = 7.0f;
	public float minVert = -45.0f;
	public float maxVert = 45.0f;

	private float rotationX = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (axes == RotationAxes.MouseX) {
			// horizontal rotation here
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHorz, 0);
		} else if (axes == RotationAxes.MouseY) {
			// vertical rotation here
			rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
			rotationX = Mathf.Clamp (rotationX, minVert, maxVert);

			transform.localEulerAngles = new Vector3 (rotationX, 0, 0);
		} else {
			// both horizontal and vertical rotation here
			rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
			rotationX = Mathf.Clamp (rotationX, minVert, maxVert);

			float delta = Input.GetAxis("Mouse X") * sensitivityHorz;
			float rotationY = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3 (rotationX, rotationY, 0);
		}

	}

    void Awake() {
        Messenger<bool>.AddListener(GameEvent.OPTIONS_MENU, OnOptionsMenu);
        Messenger<float>.AddListener(GameEvent.MOUSE_X_CHANGED, MouseXChange);
        Messenger<float>.AddListener(GameEvent.MOUSE_Y_CHANGED, MouseYChange);

        sensitivityHorz = PlayerPrefs.GetFloat("mouseXSens");
        sensitivityVert = PlayerPrefs.GetFloat("mouseYSens");
    }

    void OnDestroy() {
        Messenger<bool>.RemoveListener(GameEvent.OPTIONS_MENU, OnOptionsMenu);
        Messenger<float>.RemoveListener(GameEvent.MOUSE_X_CHANGED, MouseXChange);
        Messenger<float>.RemoveListener(GameEvent.MOUSE_Y_CHANGED, MouseYChange);
    }

    private void OnOptionsMenu(bool opened) {
        if (opened == true) {
            sensitivityHorz = 0.0f;
            sensitivityVert = 0.0f;
        } else {
            sensitivityHorz = PlayerPrefs.GetFloat("mouseXSens");
            sensitivityVert = PlayerPrefs.GetFloat("mouseYSens");
        }
    }

    private void MouseXChange (float speed) {
        sensitivityHorz = speed;
    }

    private void MouseYChange (float speed) {
        sensitivityVert = speed;
    }
}
