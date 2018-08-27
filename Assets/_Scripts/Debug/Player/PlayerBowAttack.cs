using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBowAttack : MonoBehaviour
{
	[SerializeField] private GameObject ExitPoint;
	[SerializeField] private GameObject projectile;

	[Header("Attack Stats")]
	[SerializeField] private int damage;
	[SerializeField] private float speed;
	[SerializeField] private float maxDistance;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.R))
		{
			Instantiate(projectile, ExitPoint.transform.position, projectile.transform.rotation);
		}
    }
}
