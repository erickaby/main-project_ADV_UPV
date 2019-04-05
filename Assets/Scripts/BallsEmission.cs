using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsEmission : MonoBehaviour
{
	public GameObject Bola;
	public int EmitFromX = -2;
	public int EmitToX = 2;
	public float secondsTillNextBall = 1;
	private bool on = true;

	public bool On
	{
		get
		{
			return on;
		}

		set
		{
			on = value;
			if (value)
			{
				StopAllCoroutines();
				StartCoroutine(MakeBall());
			}
			else StopAllCoroutines();
		}
	}

	private IEnumerator MakeBall()
	{
		float randomPosX = Random.Range(EmitFromX, EmitToX);
		GameObject ball = Instantiate(Bola, transform.position, transform.rotation, this.transform);
		ball.transform.localPosition = new Vector3(randomPosX + 0.5f, 0, 0);
		//new WaitForSeconds(secondsTillNextBall); 
		yield return new WaitForSeconds(secondsTillNextBall);
		if (On) StartCoroutine(MakeBall());
	}

	// Start is called before the first frame update 
	void Start()
	{
		StartCoroutine(MakeBall());
	}
}