using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour {

	[SerializeField] private string buffName;
	[SerializeField] private float duration;
	[SerializeField] private float speedMod;
	[SerializeField] private int jumpMod;
	[SerializeField] private float damageMod;

	private Player myPlayer;
	

	void Start ()
	{
		myPlayer = GetComponent<Player>();
	}
	

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			StartCoroutine(CastBuff());
		}
	}

	private IEnumerator CastBuff()
	{
		var baseSpeed = myPlayer.movementSpeed;
		var baseJump  = myPlayer.jumpPower;


		if (speedMod != 0)
		{
			myPlayer.movementSpeed += speedMod;
		}
		if (jumpMod != 0)
		{
			myPlayer.jumpPower += jumpMod;
		}
		
		yield return new WaitForSeconds(duration);

		myPlayer.movementSpeed = baseSpeed;
		myPlayer.jumpPower = baseJump;

	}
}
