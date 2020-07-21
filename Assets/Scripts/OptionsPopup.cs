using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPopup : MonoBehaviour {
    //  Private Variables
    [SerializeField] private Image crossHair;
    [SerializeField] private SettingsPopup settingsPopup;

    public void Open() {
        // Pause game & turn off crosshair
        Time.timeScale = 0;
        crossHair.gameObject.SetActive(false);
        // Turn on popup
        this.gameObject.SetActive(true);
        // Activate mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Messenger<bool>.Broadcast(GameEvent.OPTIONS_MENU, true);
    }

    public void Close() {
        // Turn off popup & turn on crosshair
        this.gameObject.SetActive(false);
        crossHair.gameObject.SetActive(true);
        // Lock the mouse cursor to center of view
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Messenger<bool>.Broadcast(GameEvent.OPTIONS_MENU, false);
    }

    public void OnSettingsButton() {
        this.gameObject.SetActive(false);
        settingsPopup.Open();
    }

    public void OnExitGameButton() {
        Application.Quit();
    }

    public void OnReturnToGameButton() {
        // Unpause game & close popup
        Time.timeScale = 1;
        Close();
    }

    public bool IsActive() {
        return this.gameObject.activeSelf;
    }
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
