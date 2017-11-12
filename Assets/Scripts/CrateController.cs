using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour
{

    public float thrust;
    public Rigidbody2D rb;
    public int scoreValue;
    private GameController gameController;
    public GameObject windZone;
    public bool isWindZone = false;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Make GameController and CrateConller wort together
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

    // Nothing here yet
    void Update()
    {

    }

}
