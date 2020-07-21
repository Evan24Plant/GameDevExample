using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleKey : MonoBehaviour {

    private bool maxHeight;

	// Use this for initialization
	void Start () {
        maxHeight = false;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 3, 0);
        //StartCoroutine(FloatingKey());
    }

    private IEnumerator FloatingKey() {
        //iTween.MoveBy(this.gameObject, new Vector3(0, 0.75f, 0), 4);
        if (maxHeight == false) {
            iTween.MoveBy(this.gameObject, new Vector3(0, 0.75f, 0), 4);
        } else if (maxHeight == true) {
            iTween.MoveBy(this.gameObject, new Vector3(0, -0.75f, 0), 4);
        }
        
        yield return new WaitForSeconds(4);
        maxHeight = !maxHeight;
    }

    void OnTriggerEnter(Collider other) {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null) {
            // apply first-aid and remove the item
            player.NewKey();
            Destroy(this.gameObject);
        }
    }
}
