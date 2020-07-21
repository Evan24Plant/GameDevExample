using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    [SerializeField] private Image crossHair;
    [SerializeField] private Text gameMessage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Open(string message) {
        // pause game and turn off crosshair
        Time.timeScale = 0;
        gameMessage.text = message;
        crossHair.gameObject.SetActive(false);
        // turn on popup
        this.gameObject.SetActive(true);
        // broadcast event
        Messenger<bool>.Broadcast(GameEvent.OPTIONS_MENU, true);
        // Activate mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Close() {
        this.gameObject.SetActive(false);
        Cursor.visible = false;
    }

    public void OnExitGameButton() {
        Application.Quit();
    }

    public void OnStartAgainButton() {
        // reload the same scene
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        // brodcast time activiated
        Messenger<bool>.Broadcast(GameEvent.OPTIONS_MENU, false);
    }

    public bool IsActive() {
        return this.gameObject.activeSelf;
    }
}
