using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    private GameObject enemy;

    [SerializeField] private GameObject iguanaPrefab;
    private GameObject iguana;

    private int numEnemies = 6;
    private int numEnemies2 = 16;
    private int numEnemies3 = 4;
    private int numIguanas = 8;
    private GameObject[] enemies;
    private GameObject[] enemies2;
    private GameObject[] enemies3;
    private GameObject[] iguanas;

	// Use this for initialization
	void Start () {
        enemies = new GameObject[numEnemies];
	    enemies2 = new GameObject[numEnemies2];
        enemies3 = new GameObject[numEnemies3];
        iguanas = new GameObject[numIguanas];

	    for (int i = 0; i < iguanas.Length; i++) {
	        if (iguanas[i] == null) {
	            iguana = Instantiate(iguanaPrefab) as GameObject;
	            iguana.transform.position = new Vector3(-(i * i - i), 0, (float)-6.5);
	            float angle = Random.Range(0, 360);
	            iguana.transform.Rotate(0, angle, 0);
	            iguanas[i] = iguana;
	        }
	    }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < enemies.Length; i++) {
            if (enemies[i] == null) {
                enemy = Instantiate(enemyPrefab) as GameObject;
                enemy.transform.position = new Vector3((i * 1.1f), 0, 5);
                float angle = Random.Range(0, 360);
                enemy.transform.Rotate(0, angle, 0);
                enemies[i] = enemy;
            }
        }
	    for (int i = 0; i < enemies2.Length; i++) {
	        if (enemies2[i] == null) {
	            enemy = Instantiate(enemyPrefab) as GameObject;
	            enemy.transform.position = new Vector3((i * 1.1f), 0, -50);
	            float angle = Random.Range(0, 360);
	            enemy.transform.Rotate(0, angle, 0);
	            enemies2[i] = enemy;
	        }
	    }
	    for (int i = 0; i < enemies3.Length; i++) {
	        if (enemies3[i] == null) {
	            enemy = Instantiate(enemyPrefab) as GameObject;
	            enemy.transform.position = new Vector3((i * 1.1f), 0, 65);
	            float angle = Random.Range(0, 360);
	            enemy.transform.Rotate(0, angle, 0);
	            enemies3[i] = enemy;
	        }
	    }
    }
}
