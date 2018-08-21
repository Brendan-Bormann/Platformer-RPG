using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] private GameObject start;
    [SerializeField] private GameObject end;
    private bool goingEnd = true;
    [SerializeField] private float speed = 1.0f;

    [Header("Rider Info")]
    [SerializeField] private GameObject rider;
    [SerializeField] private Vector3 difference;


	void Start()
	{
		start.SetActive(false);
		end.SetActive(false);
		rider = null;
	}

    void Update()
    {
        if (Vector2.Distance(transform.position, end.transform.position) < 0.01f)
        {
            goingEnd = false;
        }
        else if (Vector2.Distance(transform.position, start.transform.position) < 0.01f)
        {
            goingEnd = true;
        }
    }

    void FixedUpdate()
    {
        if (goingEnd)
        {
            transform.position = Vector2.MoveTowards(transform.position, end.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, start.transform.position, speed * Time.deltaTime);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        rider = col.gameObject;
        if (rider.name == "Player")
        {
            rider.transform.parent = transform;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
		rider.transform.parent = null;
        rider = null;
    }

}
