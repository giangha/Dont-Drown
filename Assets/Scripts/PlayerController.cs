using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{
	public float xMin, Xmax;
}

public class PlayerController : MonoBehaviour {
	public Rigidbody2D rb;
	public float speed;
	public Boundary boundary;
    private GameController gameController;

    void Start()
	{
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        rb = GetComponent<Rigidbody2D>();
		// Thuan, you can add boat engine sound here

	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector2 move = new Vector2 (moveHorizontal, 0.0f);
		rb.velocity = move*speed;

		rb.position = new Vector2 (
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.Xmax), 
			-3f
		);
	}
   

}
