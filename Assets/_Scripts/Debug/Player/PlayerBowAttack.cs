using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBowAttack : MonoBehaviour
{
	[SerializeField] private GameObject ExitPointRight;
	[SerializeField] private GameObject ExitPointLeft;
	[SerializeField] private GameObject projectile;

	[Header("Attack Stats")]
	[SerializeField] private Vector3 force;

	[SerializeField] private float coolDownTime = 1.0f;
	public bool onCD = false;
	public float coolDownTimer;

	private int direction = 1;

	private PlayerMovement PlayerMovement;



    // Use this for initialization
    void Start()
    {
		PlayerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
		if (PlayerMovement.direction > 0)
		{
			direction = 1;
		}
		else if (PlayerMovement.direction < 0)
		{
			direction = -1;
		}

		if (onCD)
		{
			coolDownTimer += Time.deltaTime;
			if (coolDownTimer >= coolDownTime)
			{
				onCD = false;
				coolDownTimer = 0;
			}
			
		}

		if (Input.GetKeyDown(KeyCode.R) && !onCD)
		{
			GameObject myArrow = projectile;
			
			if (direction > 0)
			{
				myArrow = Instantiate(projectile, ExitPointRight.transform.position, projectile.transform.rotation);
			}
			else
			{
				myArrow = Instantiate(projectile, ExitPointLeft.transform.position, new Quaternion(projectile.transform.rotation.x, projectile.transform.rotation.y, -0.7f, projectile.transform.rotation.w));
				myArrow.GetComponent<SpriteRenderer>().flipX = true;
			}
			
			myArrow.GetComponent<ArrowTravel>().Init(new Vector3(force.x * direction, force.y, force.z));
			
			onCD = true;
		}
    }
}
