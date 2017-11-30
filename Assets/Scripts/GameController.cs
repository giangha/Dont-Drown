using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Crates
    public GameObject crate;
    public GameObject metal_crate;
    public GameObject boat;
    //public GameObject net;
    public Transform droppingPoint;

	public Transform netDropPoint;

    public int crateCount;
    public float dropRate;
    bool net_drop;
    public AudioSource scoresound;
    public AudioSource dropcrate;
    AudioSource audioSource;

    private player_control_test player;
    // Time
    public float startingTime;
    public GUIText theText;

    // Score
    public GUIText scoreText;
    public int score;

    public GUIText netText;
    public int nets;

	public GUIText syringeText;
	public int syringes;

    // Hint
    public GUIText hintText;
    int current_level;
    // Total crates on boat
    GameObject[] totalCrates;

    public int boat_health = 5;
    public Slider playerHealthSlider;


    void Start()
    {
        startingTime = 90;
        score = 0;
        StartCoroutine(SpawnWave());
        net_drop = false;
        scoreUpdate();
        audioSource = GetComponent<AudioSource>();
        nets = 5;
        netUpdate();
        boat_health = 1000;
        playerHealthSlider.maxValue = boat_health;
        playerHealthSlider.value = boat_health;
        current_level = 2;


    }

    // Create crates from above
    IEnumerator SpawnWave()
    {
        // Wait for few second before start dropping crates
        yield return new WaitForSeconds(dropRate);

        // Thuan, you can add sound of dropping crate here
        for (int i = 0; i < crateCount; i++)
        {
            // Create crate and drop it
            dropcrate.Play();
            float x = Random.Range(-3, 3);
            float y = 4.96f;
            float z = 0;
            Vector3 pos = new Vector3(x, y, z);
            droppingPoint.position = pos;
            if (Random.Range(0, 10) < current_level) Instantiate(metal_crate, droppingPoint.position, droppingPoint.rotation);
            else Instantiate(crate, droppingPoint.position, droppingPoint.rotation);
            yield return new WaitForSeconds(dropRate);
        }
    }

    // Add score to every catched crate
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        scoreUpdate();
        
    }

    // Add crates to the list to destroy later when unload them at shelter station
    /*public void AddCrate(GameObject newCrate){
		totalCrates.Add (newCrate);
	}*/
    public void Alligator_Damage()
    {
             
        boat_health = boat_health - 10;
        if(boat_health<=0)
        {
            SceneManager.LoadScene(3);
            //end game
        }
        playerHealthSlider.value=boat_health;
       // playerHealthSlider.
    }

    public void alligator_deal_little_dmg()
    {
        boat_health = boat_health - 1;
        if (boat_health <= 0)
        {
            SceneManager.LoadScene(3);
            //end game
        }
        playerHealthSlider.value = boat_health;
    }

    public void Metalcrate_Damage()
    {
             
        boat_health = boat_health - 10;
        if(boat_health<=0)
        {
            SceneManager.LoadScene(3);
            //end game
        }
        playerHealthSlider.value=boat_health;
       // playerHealthSlider.
    }
    public void scoreUpdate()
    {
        scoreText.text = "Coins:" + score;
        scoresound.Play();
    }

    public void netUpdate()
    {
        netText.text = "Nets:" + nets;
        
    }

	public void syringesUpdate()
	{
		syringeText.text = "Nets:" + nets;

	}

    void Update()
    {
        // Time counting
        startingTime -= Time.deltaTime;
        theText.text = Mathf.Round(startingTime).ToString();
        if (boat.transform.rotation.z > 27)
        {
            SceneManager.LoadScene(3);
        }
        
        // Unload crates
        if (Input.GetKey(KeyCode.Z))
        {
            if (boat.transform.position.x < -7.5)
            {
                totalCrates = GameObject.FindGameObjectsWithTag("Crate");
                for (int i = 0; i < totalCrates.Length; i++)
                {
					if (totalCrates [i].transform.position.x < -7.5) {
						AddScore (10);				
						Destroy (totalCrates [i]);
					}
                }
                //hintText.text = "Thank you very muchhhhhhhhhhhhh";
               
              //  netUpdate();
            }
            else
            {
                hintText.text = "please go to shelter to unload crates";
            }
            return;
        }
		
        if (Input.GetKeyDown("up"))
        {


            if (nets > 0)
            
              //  nets--;

                netUpdate();
            
                return;
            
        }
		
        if (startingTime <= 0)
        {
            
                SceneManager.LoadScene(4);
           
            // Detroy crate when go out boundary
        }
    }
		
}
