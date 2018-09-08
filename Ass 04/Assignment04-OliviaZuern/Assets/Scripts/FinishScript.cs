using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour {
    [SerializeField]

    private GameObject player;
    public bool win;
    

	// Use this for initialization
	void Start () {
        win = (false);

	}
	
	// Update is called once per frame
	void Update () {

		
	}
   void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Player")
        {
            win = (true);
        }
    }
}
