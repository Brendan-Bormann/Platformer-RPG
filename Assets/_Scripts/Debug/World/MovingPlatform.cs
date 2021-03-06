﻿using System.Collections;
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
    [SerializeField] private bool onlyMoveWithRider = false;
    private int childTotal = 0;


	void Start()
	{
		start.SetActive(false);
		end.SetActive(false);
		rider = null;
        childTotal = transform.childCount;
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
        if (onlyMoveWithRider)
        {
            if (transform.childCount > childTotal)
            {
                MovePlatform();
            }
        }

        else if (onlyMoveWithRider == false)
            MovePlatform();
    }

    private void MovePlatform()
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
        if (col.name == "Player")
        {
            rider = col.gameObject;
            rider.transform.parent = transform;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (rider != null)
        {
            rider.transform.parent = null;
            rider = null;
        }
    }

}
