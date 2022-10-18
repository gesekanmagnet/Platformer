using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {
	bool isJump = true;
	bool isDead = false;
		int idMove = 0;
		public Animator anim;
		public Rigidbody2D rb;
		public GameObject Projectile;
		public Vector2 projectileVelocity;
		public Vector2 projectileOffset;
		public float cooldown = 0.5f;
		bool isCanShoot = true;
	// Use this for initialization
	void Start () {
		isCanShoot = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			MoveLeft();
		}
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			MoveRight();
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}
		if(Input.GetKeyUp(KeyCode.RightArrow))
		{
			Idle();
		}
		if(Input.GetKeyUp(KeyCode.LeftArrow))
		{
			Idle();
		}
		if(Input.GetKeyDown(KeyCode.Z))
		{
			Fire();
		}
		Move();
		Dead();
	}

	void Fire()
 	{
 		if(isCanShoot)
 		{
 			GameObject bullet = Instantiate(Projectile, (Vector2)transform.position - projectileOffset * transform.localScale.x, Quaternion.identity);

 			// mengatur kecepatan dari projectile
 			Vector2 velocity = new Vector2(projectileVelocity.x * transform.localScale.x, projectileVelocity.y);
 			bullet.GetComponent<Rigidbody2D>().velocity = velocity * -1;

 			//Menyesuaikan scale dari projectile dengan scale karakter
 			Vector3 scale = transform.localScale;
 			bullet.transform.localScale = scale * -1;

 			StartCoroutine(CanShoot());
 			anim.SetTrigger("isShoot");
 		}
	}

	IEnumerator CanShoot()
 	{
 		anim.SetTrigger("isShoot");
 		isCanShoot = false;
 		yield return new WaitForSeconds(cooldown);
 		isCanShoot = true;
 	}

	void OnCollisionStay2D(Collision2D raga)
	{
		if(isJump)
		{
			anim.ResetTrigger("isJump");
			if(idMove == 0)
			{
				anim.SetTrigger("isIdle");
			}
			isJump = false;
		}
	}
	
	void OnCollisionExit2D(Collision2D raga)
	{
		anim.SetTrigger("isJump");
		anim.ResetTrigger("isRun");
		anim.ResetTrigger("isIdle");
		isJump = true;
	}
	
	public void MoveRight()
	{
		idMove = 1;
	}
	
	public void MoveLeft()
	{
		idMove = 2;
	}
	
	private void Move()
	{
		if(idMove == 1 && !isDead)
		{
			if(!isJump)
			{
				anim.SetTrigger("isRun");
			}
			transform.Translate(1 * Time.deltaTime * 5f, 0, 0);
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		if(idMove == 2 && !isDead)
		{
			if(!isJump)
			{
				anim.SetTrigger("isRun");
			}
			transform.Translate(-1 * Time.deltaTime * 5f, 0, 0);
			transform.localScale = new Vector3(1f, 1f, 1f);
		}
	}
	
	public void Jump()
	{
		if(!isJump)
		{
			rb.AddForce(Vector2.up * 300f);
		}
	}
	
	void OnTriggerEnter2D(Collider2D raga)
	{
		if(raga.transform.tag.Equals("Coin"))
		{
			Destroy(raga.gameObject);
		}
	}
	
	public void Idle()
	{
		if(!isJump)
		{
			anim.ResetTrigger("isJump");
			anim.ResetTrigger("isRun");
			anim.SetTrigger("isIdle");
		}
		idMove = 0;
	}
	
	public void Dead()
	{
		if(!isDead)
		{
			if(transform.position.y < -10f)
			{
				isDead = true;
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.tag == "Respawn")
		{
			SceneManager.LoadScene("GameOver");
		}

		if (collision.transform.tag.Equals("Peluru"))
 		{
 			isCanShoot = true;
 		}
 		if (collision.transform.tag.Equals("Enemy"))
 		{
 		//SceneManager.LoadScene("Game Over");
 			isDead = true;
 		}	
 	}
}