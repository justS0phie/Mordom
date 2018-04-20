using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q_Alpha_AlienB : MonoBehaviour {

	float distance;
	float proportion;
	Vector2 initSpeed;
	Vector2 perpendicular;
	float initMagnitude;
	int side;
	float Timer;
	float TimerChange;
	public AudioSource source;
	public AudioClip explosion;

	public GameObject planet;
	private Q_Alpha_Spawner parent;
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
		initMagnitude = initSpeed.magnitude;
		initSpeed.Normalize();
		perpendicular.x = (GetComponent<Rigidbody2D>().velocity.y)*(-1);
		perpendicular.y = (GetComponent<Rigidbody2D>().velocity.x);
		perpendicular.Normalize();
		Timer = 0.0f;
		TimerChange = 0.25f;
		if (Random.Range (1, 3)==1)
			perpendicular *= -1;
	}

	void Update () {
		Timer = Timer + Time.deltaTime;
		if (Timer > TimerChange) {
			GetComponent<Rigidbody2D> ().velocity = (initSpeed+perpendicular) * initMagnitude;
			perpendicular = (perpendicular * (-1));
			Timer = 0.0f;
			TimerChange *= 2;
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Tool") {

            m_Rigidbody = GetComponent<Rigidbody2D>();
			source.PlayOneShot (explosion, 0.4f);
            pos = RigidbodyConstraints2D.FreezePosition;
			Destroy (this.GetComponent<Collider2D>());
            m_Rigidbody.constraints = pos;
            animator.SetBool("die_anim", true);
            StartCoroutine(Die());
            GameObject.FindGameObjectWithTag("Respawn").GetComponent<Q_Alpha_Spawner> ().addScore ();
			if (coll.gameObject.name == "missil")
				Destroy (coll.transform.parent.gameObject);
		}
	}
}
