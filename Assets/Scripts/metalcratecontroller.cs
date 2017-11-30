using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metalcratecontroller : MonoBehaviour
{

    public float thrust;
    public Rigidbody2D rb;
    public int scoreValue;
    private GameController gameController;
    public GameObject windZone;
    public bool isWindZone = false;
    private Animator amin;
    public bool hitWater = false;
    public GameObject crate;




    void Start()
    {
        amin = gameObject.GetComponent<Animator>();
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




    // crate hit water
    void Update()
    {


        if (crate.transform.position.y < -5.4)
        {
            crate.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            gameController.Metalcrate_Damage();
            crate.SetActive(false);
        }
       
    }
}
