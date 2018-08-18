using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour {

	[SerializeField] public float time = 4f;
	[SerializeField] public float lerpSpeed = 0.2f;
	[SerializeField] public float direction = -1;

	[SerializeField] public float attackDistance = 1f;


	private Quaternion startPosition;



	private Transform from;
    [SerializeField] private Transform to;

    private float timeCount = 0.0f;

	void Start ()
	{
		startPosition = transform.rotation;
		
		from = transform;
	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			StartCoroutine(Swing());
		}
	}

	private IEnumerator Swing()
	{
		// turn on sword
		var array = GetComponentsInChildren<SpriteRenderer>();
		array[0].enabled = true;
		array[1].enabled = true;
		GetComponent<BoxCollider2D>().enabled = true;
		// --------

		for (int i = 0; i < 25; i++)
		{
			transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, lerpSpeed);
			yield return null;
			timeCount = timeCount + Time.deltaTime;
		}

		// turn off sword
		GetComponent<BoxCollider2D>().enabled = false;
		array[0].enabled = false;
		array[1].enabled = false;
		// ----------

		// reset swing
		transform.rotation = startPosition;
		timeCount = 0;
	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.tag == "Enemy")
		{
			hit.GetComponent<Enemy>().health -= 10;
			hit.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 500));
		}
	}
}
