using UnityEngine;
using System.Collections;

public class YZRotator : MonoBehaviour
{

	// Before rendering each frame..
	void Update()
	{
		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
