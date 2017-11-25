using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RayCastEvent : MonoBehaviour {

	public Camera cam;
	Ray ray;
	RaycastHit hit;
	GameObject lookingAt;
	int uiLayer = 1 << 5;
	float lookingTimer = 0;
	public float maxTime;
	// Use this for initialization
	void Start () {
		Debug.Log(LayerMask.NameToLayer("UI"));
	}
	
	// Update is called once per frame
	void Update () {
		ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
		if (Physics.Raycast (ray, out hit, 100, uiLayer)) {
			if (lookingAt == hit.collider.gameObject) {
				lookingTimer += Time.deltaTime;
				print (lookingTimer);
				if (lookingTimer > maxTime) {
					switch (lookingAt.name) {
					case "Start":
						print ("Start");
						SceneManager.LoadScene("gra", LoadSceneMode.Single);
						break;
					case "Opcje":
						print ("Opcje");
						break;
					case "Wyjście":
						print ("Wyjście");
						Application.Quit ();
						break;
					}
				}
			} else {
				lookingTimer = 0;
				lookingAt = hit.collider.gameObject;
			}
			print ("I'm looking at " + hit.transform.name);
		} else {
			lookingAt = null;
			print ("I'm looking at nothing!");
		}
	}
}
