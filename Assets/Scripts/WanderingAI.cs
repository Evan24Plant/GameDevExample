using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStates { alive, dead };

public class WanderingAI : MonoBehaviour {

    // Global variables
    public float enemySpeed;
    public float obstacleRange = 5.0f;
    public float fireRate = 2.0f;

    // Private variables
    private EnemyStates state;
    private float nextFire = 0.0f;

    [SerializeField] private GameObject laserbeamPrefab;
    private GameObject laserbeam;

	// Use this for initialization
	void Start () {
        state = EnemyStates.alive;
	}
	
	// Update is called once per frame
	void Update () {
        if (state == EnemyStates.alive) {
            // Move the enemy and generate Ray
            transform.Translate(0, 0, enemySpeed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);

            // Spherecast and determine if Enemy needs to turn
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit)) {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>()) { 
                    // Spherecast hit Player, fire laser!
                    if ((laserbeam == null) && (Time.time > nextFire)) {
                        nextFire = Time.time + fireRate;
                        laserbeam = Instantiate(laserbeamPrefab) as GameObject;
                        laserbeam.transform.position = transform.TransformPoint(0, 1.5f, 1.5f);
                        laserbeam.transform.rotation = transform.rotation;
                    }

                } else if (hit.distance < obstacleRange) {
                    // Must've hit wall or other object, turn
                    float turnAngle = Random.Range(-110, 110);
                    transform.Rotate(0, turnAngle, 0);
                }
            }
        }
	}

    void Awake() {
        Messenger<float>.AddListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
        enemySpeed = 3.0f * (1 + (PlayerPrefs.GetInt("enemySpeed") / 10));
    }

    void OnDestroy() {
        Messenger<float>.RemoveListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
    }

    public void ChangeState(EnemyStates state) {
        this.state = state;
    }

    private void OnDifficultyChanged(float modifier) { 
        enemySpeed = 3.0f * (1 + (modifier / 10));
    }
}
