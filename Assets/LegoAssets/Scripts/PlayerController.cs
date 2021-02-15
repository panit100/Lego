using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	UnityEngine.AI.NavMeshAgent navigationAgent;
	Animator animator;

	// Use this for initialization
	void Start () {
		navigationAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMove ();

		if (animator) {
			float v = navigationAgent.velocity.x;
			if (v != 0){
				animator.SetBool("Moving",true);
			}else{
				animator.SetBool("Moving",false);
			}
		}
	}

	void PlayerMove (){
		if (Input.GetMouseButtonUp (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(ray, out hit, 500)){
				Debug.DrawLine(ray.origin, hit.point, Color.red, 1.0f);
				Debug.Log(hit.point);
				navigationAgent.SetDestination(hit.point);
			}
		}
	}

	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Enemy"){
			other.gameObject.GetComponent<EnemyController>().PrintWelcomeText();
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Gold") {
			GetComponent<AudioSource>().Play();
		}
	}
}
