using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	//public GameMasterScript gM;

	float speed= 6.0f;
	public bool isGrounded;
	public float jForce = 20.0f;
    public GameObject Can;
	public GameObject resetPnt;

	public Rigidbody pRB;
	public Vector3 jV;

    public float timer;
    public Text txt;

	void Start () {
   
		pRB = GetComponent<Rigidbody> ();
        //playerFX = gameObject.GetComponent<AudioSource> ();
        Can.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        txt.text = "Time:" + Mathf.Floor(timer);
        MoveIt ();
		if (Input.GetButtonUp ("Fire1") && isGrounded) {
            //	Jump ();
        }

	}
	void OnTriggerEnter(Collider col){
		if (!isGrounded) {
			//playerFX.PlayOneShot (landFX);
			isGrounded = (true);
		}
	}

	void OnTriggerStay(Collider col){
		isGrounded = (true);
	}

	void OnTriggerExit(Collider col){
		isGrounded = (false);
	}

	void MoveIt(){
		float x = Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime;
		float y = Input.GetAxisRaw ("Vertical") * speed * Time.deltaTime;

		transform.Translate (x,0f,y);
	}


	public void restart (){
		//playerFX.PlayOneShot (dieFX);
		this.gameObject.transform.position = resetPnt.transform.position;
	}
}

