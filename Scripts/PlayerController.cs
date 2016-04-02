using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;

	private bool facingLeft = true;
	private Animator anim;
	private Rigidbody2D rbody;
	private GameObject obj;

	void Start() {
		rbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		anim.SetFloat("InputY", -1f);        //start facing down
	}

	void Update(){
		//GetAxis returns float value from -1 -> 1
		//GetAxisRaw returns true or false
		Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		if(movement != Vector2.zero) {
			anim.SetBool("IsWalking", true);
			anim.SetFloat("InputX", movement.x);
			anim.SetFloat("InputY", movement.y);

//			if(movement.y == 0)
//				if(movement.x > 0 && facingLeft)
//					Flip();
//				else if(movement.x < 0 && !facingLeft)
//					Flip();
		} else
			anim.SetBool("IsWalking", false);

		rbody.MovePosition(rbody.position + movement * Time.deltaTime * speed);
	}

	public void SetAnimation(bool b) {
		anim.SetBool("IsWalking", b);
	}

	void Flip() {
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}