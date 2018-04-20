using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q_Alpha_AlienC : MonoBehaviour {

	float distance;
	float proportion;
	Vector2 initSpeed;
	public AudioSource source;
	public AudioClip explosion;

	public GameObject planet;
	public GameObject alien;
	private Q_Alpha_Spawner spawner;
    public Animator animator;
    public Rigidbody2D m_Rigidbody;
    public RigidbodyConstraints2D pos;

    private IEnumerator Die()
    {

        yield return new WaitForSeconds(0.8F);
        Destroy(gameObject);
    }


    void Start ()
	{
		initSpeed = GetComponent<Rigidbody2D>().velocity;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Tool") {
			GameObject.FindGameObjectWithTag("Respawn").GetComponent<Q_Alpha_Spawner> ().addScore ();
			source.PlayOneShot (explosion, 0.4f);
			if (coll.gameObject.name == "missil") {
				m_Rigidbody = GetComponent<Rigidbody2D> ();
				pos = RigidbodyConstraints2D.FreezePosition;
				Destroy (this.GetComponent<Collider2D>());
				m_Rigidbody.constraints = pos;
				animator.SetBool ("die_anim", true);
				StartCoroutine (Die ());
				GameObject newEnemy = Instantiate (alien, this.GetComponent<Rigidbody2D> ().position, this.transform.rotation);
				GameObject newEnemy2 = Instantiate (alien, this.GetComponent<Rigidbody2D> ().position, this.transform.rotation);
				newEnemy.SetActive (true);
				newEnemy.GetComponent<Rigidbody2D> ().velocity = new Vector2 ((-initSpeed.y + initSpeed.x) / 2, (initSpeed.x + initSpeed.y) / 2);

				newEnemy2.SetActive (true);
				newEnemy2.GetComponent<Rigidbody2D> ().velocity = new Vector2 ((initSpeed.y + initSpeed.x) / 2, (-initSpeed.x + initSpeed.y) / 2);
				Destroy (this.gameObject);
			}
		}
	}
}
