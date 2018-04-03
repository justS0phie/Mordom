using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase_Survival : MonoBehaviour {

    public Animator animator;
    public Rigidbody2D m_Rigidbody;
    public RigidbodyConstraints2D pos;
	public AudioSource source;
	public AudioClip explosion;

    private IEnumerator Die()
    {

        yield return new WaitForSeconds(0.8F);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Planet") {
			Destroy(this.gameObject);
			GameObject.Find("Alien").GetComponent<AlienSpawner>().loseLife ();
		}
		if (coll.tag == "Tool") {
            m_Rigidbody = GetComponent<Rigidbody2D>();
			source.PlayOneShot (explosion, 0.4f);
            pos = RigidbodyConstraints2D.FreezePosition;
            m_Rigidbody.constraints = pos;
            animator.SetBool("die_anim", true);
            StartCoroutine(Die());
            GameObject.FindGameObjectWithTag("Respawn").GetComponent<AlienSpawner> ().addScore ();
			if (coll.gameObject.name=="missil")
				Destroy (coll.transform.parent.gameObject);
		}
	}

}
