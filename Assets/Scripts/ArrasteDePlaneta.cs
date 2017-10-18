using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrasteDePlaneta : ArrasteDeElemento {

	public float minimumRadius;
	
	public override void Update () {

		base.Update();

		//restringe o arraste do planeta a uma distancia minima dos limites da camera

		float distance = (transform.position - Camera.main.transform.position).z;

		float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).x;
		float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)).x;

		float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).y;
		float upperBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance)).y;

		if(transform.position.x < leftBorder + minimumRadius)
			transform.position = new Vector3(leftBorder + minimumRadius, transform.position.y, transform.position.z);
		else if(transform.position.x > rightBorder - minimumRadius)
			transform.position = new Vector3(rightBorder - minimumRadius, transform.position.y, transform.position.z);

		if(transform.position.y < bottomBorder + minimumRadius)
			transform.position = new Vector3(transform.position.x, bottomBorder + minimumRadius, transform.position.z);
		else if(transform.position.y > upperBorder - minimumRadius)
			transform.position = new Vector3(transform.position.x, upperBorder - minimumRadius, transform.position.z);
	}
}
