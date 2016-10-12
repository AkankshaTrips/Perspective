using UnityEngine;
using System.Collections;

public class Orientation : MonoBehaviour {

	public float speed = 6f;
	public GameObject wallClimb; // wall object
	public Vector3 myNormal;
	public Vector3 myPrevNormal;
	public Rigidbody playerRigidbody;
	public int canMove = 1;

	private bool paused = true;
	private CamMouseLook camera;
	private Animator anim;


	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody> ();
		myNormal = Vector3.down;
		myPrevNormal = Vector3.down;
		camera = Camera.main.GetComponent<CamMouseLook> ();
		anim = this.gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		

		RaycastHit hit = new RaycastHit ();
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		if (Input.GetKeyDown (KeyCode.Space)) { //if Space is pressed do...
			canMove = 0;
			playerRigidbody.velocity = Vector3.zero;
			if (Physics.Raycast (transform.position, fwd, out hit, 3)) { //is there an object in front
				//print ("There is something in front of the object!");
				if (hit.collider.gameObject.tag == "wall") { // if object you hit was a wall
					
					playerRigidbody.velocity = Vector3.zero;
					Vector3 coor = new Vector3 (hit.point.x, hit.point.y, hit.point.z); // raycast coordinates
					transform.position = coor; // to teleport

					myPrevNormal = myNormal;
					WallNormal wallNormal = hit.collider.gameObject.GetComponent<WallNormal> ();

					myNormal = wallNormal.normal;

					//transform.Rotate (Vector3.left * 90, Space.World); //rotate 90 degrees
					Physics.gravity = myNormal * 10; // change gravity

					// change rotation

					if (myPrevNormal == Vector3.down) { // PLANE 1
						//transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
						if (myNormal == Vector3.forward) {
							transform.Rotate (Vector3.left * 90, Space.World);
						} else if (myNormal == Vector3.back) {
							transform.Rotate (Vector3.right * 90, Space.World);
						} else if (myNormal == Vector3.left) {
							transform.Rotate (Vector3.back * 90, Space.World);
						} else if (myNormal == Vector3.right) {
							transform.Rotate (Vector3.forward * 90, Space.World);
						}
					} else if (myPrevNormal == Vector3.forward) { // PLANE 2
						if (myNormal == Vector3.down) {
							transform.Rotate (Vector3.right * 90, Space.World);
						} else if (myNormal == Vector3.left) {
							transform.Rotate (Vector3.down * 90, Space.World);
						} else if (myNormal == Vector3.right) {
							transform.Rotate (Vector3.up * 90, Space.World);
						} else if (myNormal == Vector3.up) {
							transform.Rotate (Vector3.left * 90, Space.World);
						}
					} else if (myPrevNormal == Vector3.left) { // PLANE 3
						if (myNormal == Vector3.down) {
							transform.Rotate (Vector3.forward * 90, Space.World);
						} else if (myNormal == Vector3.forward) {
							transform.Rotate (Vector3.up * 90, Space.World);
						} else if (myNormal == Vector3.back) {
							transform.Rotate (Vector3.down * 90, Space.World);
						} else if (myNormal == Vector3.up) {
							transform.Rotate (Vector3.back * 90, Space.World);
						}
					} else if (myPrevNormal == Vector3.back) { // PLANE 4
						if (myNormal == Vector3.down) {
							transform.Rotate (Vector3.left * 90, Space.World);
						} else if (myNormal == Vector3.left) {
							transform.Rotate (Vector3.up * 90, Space.World);
						} else if (myNormal == Vector3.up) {
							transform.Rotate (Vector3.right * 90, Space.World);
						} else if (myNormal == Vector3.right) {
							transform.Rotate (Vector3.down * 90, Space.World);
						}
					} else if (myPrevNormal == Vector3.right) { // PLANE 5
						if (myNormal == Vector3.down) {
							transform.Rotate (Vector3.back * 90, Space.World);
						} else if (myNormal == Vector3.forward) {
							transform.Rotate (Vector3.down * 90, Space.World);
						} else if (myNormal == Vector3.back) {
							transform.Rotate (Vector3.up * 90, Space.World);
						} else if (myNormal == Vector3.up) {
							transform.Rotate (Vector3.forward * 90, Space.World);
						} 
					} else if (myPrevNormal == Vector3.up){ // Plane 6
						if (myNormal == Vector3.forward) {
							transform.Rotate (Vector3.right * 90, Space.World);
						} else if (myNormal == Vector3.left) {
							transform.Rotate (Vector3.forward * 90, Space.World);
						} else if (myNormal == Vector3.back) {
							transform.Rotate (Vector3.left * 90, Space.World);
						} else if (myNormal == Vector3.right) {
							transform.Rotate (Vector3.back * 90, Space.World);
						} 
					}

				}

			}
				

			//change gravity
			canMove = 1;
		}

		if (canMove == 1) {
			if (Input.GetKey (KeyCode.D)) {
				if (myNormal == Vector3.right) {
					transform.Rotate (Vector3.left * 5f, Space.World);
				}
				if (myNormal == Vector3.left) {
					transform.Rotate (Vector3.right * 5f, Space.World);
				}
				if (myNormal == Vector3.up) {
					transform.Rotate (Vector3.down * 5f, Space.World);
				}
				if (myNormal == Vector3.down) {
					transform.Rotate (Vector3.up * 5f, Space.World);
				}
				if (myNormal == Vector3.forward) {
					transform.Rotate (Vector3.back * 5f, Space.World);
				}
				if (myNormal == Vector3.back) {
					transform.Rotate (Vector3.forward * 5f, Space.World);
				}
			} 
			if (Input.GetKey (KeyCode.A)) {
				if (myNormal == Vector3.right) {
					transform.Rotate (Vector3.right * 5f, Space.World);
				}
				if (myNormal == Vector3.left) {
					transform.Rotate (Vector3.left * 5f, Space.World);
				}
				if (myNormal == Vector3.up) {
					transform.Rotate (Vector3.up * 5f, Space.World);
				}
				if (myNormal == Vector3.down) {
					transform.Rotate (Vector3.down * 5f, Space.World);
				}
				if (myNormal == Vector3.forward) {
					transform.Rotate (Vector3.forward * 5f, Space.World);
				}
				if (myNormal == Vector3.back) {
					transform.Rotate (Vector3.back * 5f, Space.World);
				}
			}

			float translation = Input.GetAxis ("Vertical") * speed;
			float straffle = Input.GetAxis ("Horizontal") * speed;
			translation *= Time.deltaTime;
			straffle *= Time.deltaTime;

			transform.Translate (0, 0, translation);
			//playerRigidBody.MovePosition(new Vector3(straffle, 0, translation));
			if (Input.GetKeyDown ("escape")) {
				if (paused) {
					Time.timeScale = 0;
					Cursor.visible = true;
					camera.enabled = false;
					paused = false;
				} else {
					Time.timeScale = 1;
					//camera.enabled = true;
					Cursor.visible = false;
					paused = true;
				}

			}

			Animating (translation, straffle); 
		}
	}


	void Animating (float h, float v) {
		bool walking = h != 0f || v != 0f;
		if (walking) {
			if (anim.GetInteger ("Speed") == 2) {
			} else {
				anim.SetInteger ("Speed", 2);
			}
		} else {
			anim.SetInteger ("Speed", 0);
		}
	}
}
