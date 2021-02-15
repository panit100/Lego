using UnityEngine;
using System.Collections;
using System;

public class EnemyController : MonoBehaviour 
{

	Transform player;
	UnityEngine.AI.NavMeshAgent nav;

	public float delayEnemy = 3;
	public bool isWalking = false;

	public float moveSpeed = 3.5f;
	public float xSize = 1f;
	protected virtual void ChangeScale(float size){
		Vector3 scaleChange = new Vector3(size,size,size);
		transform.localScale += scaleChange;
	}	

	public virtual void PrintWelcomeText(){
		Debug.Log("Defaut Enemy");
	}

	protected virtual void ChangeColor(MeshRenderer meshRenderer){
		meshRenderer.material.color = Color.black;
	}
	
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();

		nav.speed = moveSpeed;
	}

	void Start() {
		ChangeScale(xSize);
		//PrintWelcomeText();
		Component[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
		foreach(MeshRenderer n in meshRenderers){
			ChangeColor(n);
		}

		StartCoroutine(DelayEnemy());
	}
	
	IEnumerator DelayEnemy() {
		yield return new WaitForSeconds(delayEnemy);
		isWalking = true;
	}

	
	// Update is called once per frame
	void Update () {
		if (isWalking) {
			nav.SetDestination (player.position);
		} else {
			nav.SetDestination (gameObject.transform.position);
		}
	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "Player") {
			try{
				GameObject.Find("GameController").GetComponent<ScoreController>().Die();
			}catch (Exception e){
				Debug.Log(e.Message);
			}


			GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
			
			foreach (GameObject enemy in enemys) {
				enemy.SendMessage("PlayerDie");
			}

			col.gameObject.SetActive(false);
		}
	}

	public void PlayerDie(){
		isWalking = false;
	}
}
