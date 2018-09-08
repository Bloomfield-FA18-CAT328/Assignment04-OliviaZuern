using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    [SerializeField]
   private EnemyEnum state = EnemyEnum.Patrol;
    public List<GameObject> point;

    public GameObject intPoint;
    public GameObject player;
    public GameObject GOAL;
    public FinishScript finish;
    #region EnemyOpt
    public float speed = 3.0f;
    public float run = 5.0f;
    public float atk = 1.5f;
    public float atkDist = 1.0f;
   #endregion
    // Use this for initialization
    void Start () {
        ChangeToPatrol();
        finish = GOAL.GetComponent<FinishScript>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (state) {
            case EnemyEnum.Attack:
                Attacking();
                break;
            case EnemyEnum.chase:
                Chasing();
                break;
            case EnemyEnum.Patrol:
                Patrolling();
                break;
            case EnemyEnum.spin:
                Spinning();
                break;
        }
        if (finish.win == true){
            state = EnemyEnum.spin;
            GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f);
        }
	}
    void Attacking() {
        float step = atk * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position,step);

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > atkDist) { ChangeToChase(); }
    }

    void Patrolling() {
        float step = run * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, intPoint.transform.position, step);

        float distance = Vector3.Distance(transform.position, intPoint.transform.position);
        if (distance == 0) {
            int choice = Random.Range(0, point.Count);
            intPoint = point[choice];
        }
    }

    void Chasing() {
        float step = run * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= atkDist) { ChangeToAttack(); }
    }
    void Spinning() {
        transform.Rotate(Vector3.up * Time.deltaTime*300);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){
            ChangeToChase();
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            ChangeToPatrol();
           
        }
    }

    void ChangeToPatrol(){
        state = EnemyEnum.Patrol;
        GetComponent<Renderer>().material.color= new Color(0.5f, 0.5f, 0.5f);
    }
    void ChangeToAttack() {
        state = EnemyEnum.Attack;
             GetComponent<Renderer>().material.color= new Color(1.0f, 0.0f, 0.0f);
    }

    void ChangeToChase () {
        state = EnemyEnum.chase;
        GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 0.0f);
    }
}
