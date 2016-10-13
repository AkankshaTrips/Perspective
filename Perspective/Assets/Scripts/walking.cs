using UnityEngine;
using System.Collections;

public class walking : MonoBehaviour {

	public AudioSource audio;
	public bool running = false;
	public Orientation orient;
	public AudioClip audioClip;

	// Use this for initialization
	void Start () {
		orient = GameObject.Find("PlayerRobot").GetComponent<Orientation> ();
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
		if (orient.paused == true) {
			if (running) {
				if (audio.isPlaying) {

				} else {
					audio.Play ();
				}
			} else {
				audio.Stop ();
			}
		} else {
			audio.Stop ();
		}
	}
}
