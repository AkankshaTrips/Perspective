using UnityEngine;
using System.Collections;

public class walking : MonoBehaviour {

	public AudioSource audio;
	public bool running = false;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {
			//audio.clip = AudioFile;
			running = true;
			//audio.Play();
		} else {
			running = false;
		}
		PlayFootsteps ();
	}

	void PlayFootsteps() {
		if (running) {
			if (audio.isPlaying) {

			} else {
				audio.Play ();
			}
		} else {
			audio.Stop ();
		}
	}
}
