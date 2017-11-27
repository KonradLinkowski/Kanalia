using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monolog : MonoBehaviour {

	static public AudioClip intro;
	static public AudioClip[] siatki;
	static public AudioClip[] teksty;
	static public AudioClip[] smierci;
	static public AudioClip[] sciany;
	static public AudioClip[] kraty;
	static public AudioClip outro;

	static public void Init ()
	{
		intro = Resources.Load("Audio/intro.mp3") as AudioClip;
		siatki = Resources.LoadAll<AudioClip>("Audio/siatki");
		teksty = Resources.LoadAll<AudioClip>("Audio/teksty");
		smierci = Resources.LoadAll<AudioClip>("Audio/smierci");
		kraty = Resources.LoadAll<AudioClip>("Audio/kraty");
		outro = Resources.Load("Audio/outro.mp3") as AudioClip;
	}

	static public AudioClip GetRandom(AudioClip[] ac)
	{
		print("audioclip get random");
		if (ac == null || ac.Length < 1)
		{
			print(ac);
			return null;
		}
		print(ac);
		return ac[Random.Range(0, ac.Length - 1)];
	}
}
