using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour {
    // Private Variables
    [SerializeField] private OptionsPopup optionsPopup;
    [SerializeField] private Slider difficultySlider;
    [SerializeField] private Slider mouseXSlider;
    [SerializeField] private Slider mouseYSlider;
    [SerializeField] private Text enemySpeedValue;

    public void Open() {
        this.gameObject.SetActive(true);
    }

    public void Close() {
        this.gameObject.SetActive(false);
    }

    public void OnOKButton() {
        this.Close();

        PlayerPrefs.SetInt("enemySpeed", (int)difficultySlider.value);
        Messenger<float>.Broadcast(GameEvent.DIFFICULTY_CHANGED, difficultySlider.value);

        PlayerPrefs.SetFloat("mouseXSens", mouseXSlider.value + 2);
        PlayerPrefs.SetFloat("mouseYSens", mouseYSlider.value + 2);
        Messenger<float>.Broadcast(GameEvent.MOUSE_X_CHANGED, mouseXSlider.value);
        Messenger<float>.Broadcast(GameEvent.MOUSE_Y_CHANGED, mouseYSlider.value);

        optionsPopup.Open();
    }

    public void OnCancelButton() {
        this.Close();
        optionsPopup.Open();
    }

    public void OnDifficultyValue(float speed) {
        enemySpeedValue.text = speed.ToString();
    }

    public bool IsActive() {
        return this.gameObject.activeSelf;
    }

    // Use this for initialization
    void Start () {
        difficultySlider.value = PlayerPrefs.GetInt("enemySpeed", 1);
        mouseXSlider.value = PlayerPrefs.GetFloat("mouseXSens", 7);
        mouseYSlider.value = PlayerPrefs.GetFloat("mouseYSens", 7);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
