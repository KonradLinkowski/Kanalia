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
	AudioSource tekster;
	//public Image red;
	//public Animator anim;
	bool death;
	float niepotrzebnyTimer = 0;
	public float animacjiCzas;
	Rigidbody rb;
	public GameObject fajnaMina;

	float tekstTimer = 0;
	public float tekstMaxTime;
	// Use this for initialization
	void Start () {

		Monolog.Init();

		currentTlen = maxTlen;
		death = false;
		//anim.SetTrigger("Start");
		rb = GetComponent<Rigidbody>();
		tekster = GetComponent<AudioSource>();
	}
	void Update() {
		tekstTimer += Time.deltaTime;
		if (tekstTimer > tekstMaxTime)
		{
			print("test");
			tekstTimer = 0;
			tekster.PlayOneShot(Monolog.GetRandom(Monolog.teksty));
		}
		//red.color = new Color (1, 0, 0, (maxTlen - currentTlen * 2) / maxTlen);
		if (death)
		{
			niepotrzebnyTimer += Time.unscaledDeltaTime;
			print(niepotrzebnyTimer);
			if (niepotrzebnyTimer >= animacjiCzas)
			{
				SceneManager.LoadScene("gra");
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		currentTlen -= Time.deltaTime;
		if (currentTlen <= 0) {
			SceneManager.LoadScene ("gra");
		}
		if (!death)
			rb.velocity = ts.forward * speed;
		//rb.MovePosition(ts.position + ts.forward * speed * Time.deltaTime);

	}
	public void buttonClick()
	{
		go.GetComponent<MeshRenderer>().material.color = Color.red;
	}

	void OnTriggerEnter(Collider col) {

		if (col.CompareTag("Mina")) {
			var fajnyObject = Instantiate(fajnaMina, col.gameObject.transform.position, col.gameObject.transform.rotation);
			Destroy(col.gameObject);
			fajnyObject.GetComponent<AudioSource>().Play();
			RaycastHit[] hitInfo = Physics.SphereCastAll(fajnyObject.transform.position, 3.0f, Vector3.zero);
			foreach (var hit in hitInfo) {
				print(hit);
				fajnyObject.transform.GetChild(0).GetComponent<Rigidbody>().AddExplosionForce(10.0f, fajnyObject.transform.position, 5.0f);
			}
			tekster.PlayOneShot(Monolog.GetRandom(Monolog.smierci));
			death = true;
			rb.velocity = new Vector3(0, 0, 0);
		}
		if (col.CompareTag ("Siatka")) {
			tekster.PlayOneShot(Monolog.GetRandom(Monolog.siatki));
			currentTlen += reklamowka;
			Destroy (col.gameObject);
		}
	}

}
