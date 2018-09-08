using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour {
    [SerializeField]

    private GameObject player;
    public bool win;
    public GameObject winp;

    public float timer;
    public Text txt;

	// Use this for initialization
	void Start () {
        win = (false);

	}
	
	// Update is called once per frame
	void Update () {
        if (win == false)
        {
            timer += Time.deltaTime;
            txt.text = "Time:" + Mathf.Floor(timer);
        }
    }
   void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Player")
        {
            win = (true);
            winp.SetActive(true);
        }
    }
}
