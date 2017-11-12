using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class net_controller : MonoBehaviour {
    public float thrust;
    public Rigidbody2D rb;

    private GameController gameController;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

        // Make GameController and NetConller work together
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}


