﻿using System.Collections;
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
        amin.SetBool("hitWater", hitWater);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("water4crate"))
        {
 
            hitWater = true;
            //crate.SetActive(false);
            Invoke("set_false", .5f);
        }
    }

    void set_false()
    {
        CancelInvoke();
        crate.SetActive(false);
    }

}
