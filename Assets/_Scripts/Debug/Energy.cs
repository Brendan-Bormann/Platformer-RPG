using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{

	public int total = 100;
	public int barAmount = 10;
	public int totalBars = 10;
	public int currentBars = 10;
	public float currentAmount = 100;


    // Use this for initialization
    void Start()
    {
		totalBars = total / barAmount;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
