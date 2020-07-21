using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {
	// Private variables
	private Camera playerCamera;
    private bool optionsOpen = false;

	// Use this for initialization
	void Start () {
		playerCamera = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && optionsOpen == false) {
			Vector3 point = new Vector3 (playerCamera.pixelWidth / 2, playerCamera.pixelHeight / 2, 0);
			Ray ray = playerCamera.ScreenPointToRay (point);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				// visually indicate where there was a hit
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget> ();
				// is this our target?
				if (target != null) {
					target.ReactToHit ();
				} else {
					StartCoroutine (SphereIndicator (hit.point));
				}
			}
		}
	}

	private IEnumerator SphereIndicator(Vector3 hitPosition) {
		GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		sphere.transform.position = hitPosition;

		yield return new WaitForSeconds (1);

		Destroy (sphere);
	}

    void Awake() {
        Messenger<bool>.AddListener(GameEvent.OPTIONS_MENU, OnOptionsMenu);
    }

    void OnDestroy() {
        Messenger<bool>.RemoveListener(GameEvent.OPTIONS_MENU, OnOptionsMenu);
    }

    private void OnOptionsMenu(bool opened) {
        optionsOpen = opened;
    }
}
