using UnityEngine;
using System.Collections;

public class PC : MonoBehaviour {
	
	private Animator m_Animator;

	private bool isJumping;
	private bool isDucking;

	private float jumpHeight = 0.3f;
	private float stdHeight = -0.6f;
	
	void Start () {
		m_Animator = GetComponent<Animator>();
	}

	void Update () {

		//Time.timeScale = 0.2F;
		float translation = Time.deltaTime * 2;
		transform.Translate(translation, 0, 0);

	}

	void OnTriggerEnter2D (Collider2D trigger) {
		if (trigger.collider2D.tag == "Finish") {
			print ("Winner");
			Application.LoadLevel ("win");//load win screen;
		} else if (trigger.collider2D.tag == "obstacle") {
			print ("TRIGGERED!!!!"); //move player backwards;
			this.transform.position = new Vector3 (transform.position.x-1.0f, this.transform.position.y, this.transform.position.z);
			
			//SlowDown();
			//Invoke("SpeedUp",2);
		} else if (trigger.collider2D.tag == "tsunami") {
			print ("Game Over");
			Application.LoadLevel ("lose");//load lose screen;
		}
	} 

	//CONTROLS:
	//up - jump - avoid sharks
	//nothing - neutral stance
	//down - duck - avoid birds


	void FixedUpdate () 
	{

		m_Animator.SetBool("isJumping", isJumping);
		m_Animator.SetBool("isDucking", isDucking);

		if(Input.GetButton("Jump")){
			Animator animator = GetComponent<Animator>() as Animator;
			animator.SetTrigger("isJumping");

			this.transform.position = new Vector3 (this.transform.position.x, jumpHeight, this.transform.position.z);
		}

		if(Input.GetButtonUp("Jump")){
			this.transform.position = new Vector3 (this.transform.position.x, stdHeight, this.transform.position.z);
		}

		if(Input.GetButton("Duck")){
			Animator animator = GetComponent<Animator>() as Animator;
			animator.SetTrigger("isDucking");
		}

	}
	
//	void SlowDown()
//	{
//		Time.timeScale = 0.3F;
//		float translation = Time.deltaTime * 1;
//		transform.Translate(translation, 0, 0);
//
//	}

//	void SpeedUp()
//	{
//		Time.timeScale = 1.0F;
//		float translation = Time.deltaTime * 2;
//		transform.Translate(translation, 0, 0);
//		
//	}

}
