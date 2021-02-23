using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCondition : Condition
{
	public float parameter { get; set; }
	public bool value { get; set; }

	float timer;

	public override bool IsTrue()
	{
		timer -= Time.deltaTime;
		if (timer <= 0)
		{
			timer = Random.Range(0, parameter);
			value = (Random.Range(0, 2) == 0);
		}

		return value;
	}

}
