using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    // Private Variables
    private int score;

    [SerializeField] private Text scoreValue;
    [SerializeField] private Text keysValue;
    [SerializeField] private Image healthBar;
    [SerializeField] private OptionsPopup optionsPopup;
    [SerializeField] private SettingsPopup settingsPopup;
    [SerializeField] private Door3Popup door3Popup;
    [SerializeField] private GameOverScreen gameOverScreen;

	// Use this for initialization
	void Start () {
	    score = 0;
	    scoreValue.text = score.ToString();

        keysValue.text = "0";

	    healthBar.fillAmount = 1;
	    healthBar.color = Color.green;

        optionsPopup.Close();
        settingsPopup.Close();
        door3Popup.Close();
        gameOverScreen.Close();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown("escape") && !optionsPopup.IsActive() && !settingsPopup.IsActive() && !gameOverScreen.IsActive()) {
            optionsPopup.Open();
	    }
	}

    void Awake() {
        Messenger.AddListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
        Messenger.AddListener(GameEvent.DOOR3_LOCKED, OnDoor3Locked);
        Messenger.AddListener(GameEvent.PLAYER_DEAD, OnPlayerDead);
        Messenger.AddListener(GameEvent.GAME_WON, OnGameWon);
        Messenger<int>.AddListener(GameEvent.PLAYER_HIT, OnPlayerHit);
        Messenger<int>.AddListener(GameEvent.HEALTH_CHANGED, OnPlayerHit);
        Messenger<int>.AddListener(GameEvent.KEY_COLLECTED, OnKeyCollected);
    }

    void OnDestroy() {
        Messenger.RemoveListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
        Messenger.RemoveListener(GameEvent.DOOR3_LOCKED, OnDoor3Locked);
        Messenger.RemoveListener(GameEvent.PLAYER_DEAD, OnPlayerDead);
        Messenger.RemoveListener(GameEvent.GAME_WON, OnGameWon);
        Messenger<int>.RemoveListener(GameEvent.PLAYER_HIT, OnPlayerHit);
        Messenger<int>.RemoveListener(GameEvent.HEALTH_CHANGED, OnPlayerHit);
        Messenger<int>.RemoveListener(GameEvent.KEY_COLLECTED, OnKeyCollected);
    }

    private void OnEnemyDead() {
        score++;
        scoreValue.text = score.ToString();
    }

    private void OnPlayerDead() {
        gameOverScreen.Open("Game Over");
    }

    private void OnGameWon() {
        gameOverScreen.Open("You Win!");
    }

    private void OnPlayerHit(int health) {
        switch (health) {
            case 5:
                healthBar.fillAmount = 1;
                healthBar.color = Color.green;
                break;
            case 4:
                healthBar.fillAmount = 0.8f;
                healthBar.color = Color.yellow;
                break;
            case 3:
                healthBar.fillAmount = 0.6f;
                healthBar.color = Color.yellow;
                break;
            case 2:
                healthBar.fillAmount = 0.4f;
                healthBar.color = Color.red;
                break;
            case 1:
                healthBar.fillAmount = 0.2f;
                healthBar.color = Color.red;
                break;
        }
    }

    private void OnKeyCollected(int keys) {
        keysValue.text = keys.ToString();
    }

    private void OnDoor3Locked() {
        StartCoroutine(Door3LockPopup());
    }

    private IEnumerator Door3LockPopup() {
        door3Popup.Open();
        yield return new WaitForSeconds(3);
        door3Popup.Close();
    }
}
