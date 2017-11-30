using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_control_test : MonoBehaviour {
    public Rigidbody2D rb;
    public float speed;
    public bool scare;
    private Animator amin;
    //private float throwcd = 3f;

	public int syringeTotal;
	public GameObject syringe;

	public int netTotal;
	public GameObject net;
	public Transform netDropPoint;
    public bool throws;
	private bool toTheRight;
	private GameController gameController;

    // Use this for initialization
    void Start () {
		
        rb = GetComponent<Rigidbody2D>();
        amin = gameObject.GetComponent<Animator>();

		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
			
    }
	
	// Update is called once per frame
	void Update () {


        if (transform.rotation.z > 27 || transform.rotation.z < -27)
        {
            SceneManager.LoadScene(3);
        }
            amin.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        amin.SetBool("scare", scare);
        amin.SetBool("throw", throws);
        float moveHorizontal = Input.GetAxis("Horizontal");
		if(Input.GetKey("right")) {
			transform.localScale = new Vector3(-1,1,1);
			toTheRight = true;
		}
		else if(Input.GetKey("left")){
			transform.localScale = new Vector3(1,1,1);	
			toTheRight = false;
		}

        Vector2 move = new Vector2(moveHorizontal, 0.0f);
        rb.velocity = move * speed;
        if (transform.rotation.z > 27 || transform.rotation.z < -27)
        {
            SceneManager.LoadScene(3);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Alligator"))
        {
            scare = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Alligator"))
        {
            scare = true;
        }
    }

	private float shootTime = 0;
	private float shootRate = 0.5f;

	private float buyTime = 0;
	private float buyRate = 1.0f;

	void FixedUpdate(){
		if (Input.GetKey("up") && netTotal > 0)
		{
            throws = true;
            
            if (Time.time > shootTime)
			{
				shootTime = Time.time + shootRate;
				Rigidbody2D netRid;
				var Clone = Instantiate(net, netDropPoint.position, netDropPoint.rotation);
				netRid = Clone.GetComponent<Rigidbody2D> ();
				if (toTheRight == true || Input.GetKey("right")) {
					netRid.AddForce (transform.right * 150);
				} else {
					netRid.AddForce (transform.right * -150);
				}
				netRid.AddForce (transform.up * 300);
				//net_drop = true;
				netTotal-- ;

				gameController.nets = netTotal;
				gameController.netUpdate ();
				return;
			}
		}

		if (Input.GetKey ("down") && syringeTotal > 0) {
            throws = true;
			if (Time.time > shootTime)
			{
				shootTime = Time.time + shootRate;
				Rigidbody2D syringeRid;
				var Clone = Instantiate(syringe, netDropPoint.position, netDropPoint.rotation);
				syringeRid = Clone.GetComponent<Rigidbody2D> ();
				if (toTheRight == true) {
					syringeRid.AddForce (transform.right * 700);
				} else {
					syringeRid.AddForce (transform.right * -700);
				}
				//syringeRid.AddForce (transform.up * 300);
				//net_drop = true;
				syringeTotal-- ;

				//gameController.nets = netTotal;
				//gameController.netUpdate ();
				return;
			}

		}

		// Buying net
		if (transform.position.x < -5.5 && Input.GetKey(KeyCode.B) && gameController.score >= 20) {
			if (Time.time > buyTime) {
				buyTime = Time.time + buyRate;
				netTotal += 2;
				gameController.nets = netTotal;
				gameController.netUpdate ();

				gameController.score -= 20;
				gameController.scoreUpdate ();
				return;
			}
           
        }
        if (throws)
        {
            throws = false;

        }

       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Alligator"))
        {
            scare = true;
        }
    }


}
