using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Swimming : MonoBehaviour {
	public float speed;
	public Transform ts;
	public GameObject go;
	public float maxTlen;
	float currentTlen;
	public float reklamowka;
	public Image red;
	// Use this for initialization
	void Start () {
		currentTlen = maxTlen;
	}

	void Update() {
		red.color = new Color (1, 0, 0, (maxTlen - currentTlen) / maxTlen);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		currentTlen -= Time.deltaTime;
		if (currentTlen <= 0) {
			SceneManager.LoadScene ("gra");
		}
		transform.Translate(ts.forward * speed * Time.deltaTime);
	}
	public void buttonClick()
	{
		go.GetComponent<MeshRenderer>().material.color = Color.red;
	}

	void OnTriggerEnter(Collider col) {

		if (col.CompareTag("Wall")) {
			SceneManager.LoadScene ("gra");
		}
		if (col.CompareTag ("Siatka")) {
			currentTlen += reklamowka;
			Destroy (col.gameObject);
		}
	}

}
