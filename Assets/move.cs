using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class move : MonoBehaviour
{
	public float speed;

	// Start is called before the first frame update
	void Start()
    {
        
		Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log("Moving");
		// Handles Keyboard input
		Vector3 position = new Vector3();
		if (Input.GetKey(KeyCode.D))
		{
			Debug.Log("Moving111");
			position.x += 1.0f;
			this.GetComponent<Actions>().Run();
		}
		if (Input.GetKey(KeyCode.A))
		{
			position.x -= 1.0f;
			this.GetComponent<Actions>().Run();
		}

		if (Input.GetKey(KeyCode.W))
		{
			position.z += 1.0f;
			this.GetComponent<Actions>().Run();
		}

		if (Input.GetKey(KeyCode.S))
		{
			position.z -= 1.0f;
			this.GetComponent<Actions>().Run();
		}

		position *= speed * Time.deltaTime;
		transform.Translate(position);

		//this.GetComponent<Actions>().Stay();
	}
}
