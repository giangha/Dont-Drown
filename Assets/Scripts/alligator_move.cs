using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alligator_move : MonoBehaviour
{
    public GameObject aligator;
    public Transform target;//set target from inspector instead of looking in Update
    public float speed;
    private GameController gameController;
    // Use this for initialization
    private Animator amin;
    public bool caught;
    public bool angry;
    public bool sleep;
    public float TimeInNet;
    private Rigidbody2D rb2d;
    private float pushforce = 250f;
    public bool bite = false;
   

    void Start()
    {
        gameObject.SetActive(false);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
       
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        amin = gameObject.GetComponent<Animator>();
        Invoke("Reappear", 20);
    }

    // Update is called once per frame
    void Update()
    {
        amin.SetBool("angry", angry);
        amin.SetBool("sleep", sleep);
        amin.SetBool("caught", caught);
        amin.SetBool("bite", bite);
        target = GameObject.FindWithTag("Boat").transform;

         float step = speed * Time.deltaTime;
         Vector3 offset = new Vector3(0, 0f, 0);
         Vector3 targetHeading = target.position + offset;
         Vector3 targetDirection = targetHeading.normalized;
         float old_x_location = transform.position.x;
         transform.position = Vector3.MoveTowards(transform.position, targetHeading, step);
         float new_x_location = targetHeading.x;


         float difference_between_locations = old_x_location - new_x_location;
         if (difference_between_locations < 0) difference_between_locations = difference_between_locations * -1;
        if (difference_between_locations < 2.7 && !caught)
        {
            bite = true;
            //  Invoke("Alligator_Attack", 0);

            gameController.Alligator_Damage();

            //aligator.gameObject.SetActive(false);
            //Invoke("Reappear", 15);

        }
        else
            bite = false;
        


    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.CompareTag("Net"))
       {
            //Invoke("Reappear", 15);
           // aligator.gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            caught = true;
            speed = 0;
            Invoke("unCaught", 10);
          //  Invoke("Reappear", 15);
        }
      //  if (other.gameObject.CompareTag("Boat")) {
       //     angry = true; }
       
      //  if (other.gameObject.CompareTag("boat_area"))
      //  {
            
           // other.gameObject.SetActive(false);
       // }
       
    }


    void unCaught()
    {
        CancelInvoke();
        caught = false;
        speed = 1f;
       // target.position = new Vector3(12, -4.8f, 0);
    }

   /* void pushBack()
    {
        
       
        rb2d.AddForce(Vector2.right * pushforce);
        Invoke("Reappear", 15);
        
    }

    */
    void Reappear()
        {
        CancelInvoke();
        gameObject.SetActive(true); 
        rb2d.Sleep();
       
        
        Vector3 position = new Vector3(10.73f,-4.6f,0);
        transform.position = position;
        
        }

    void Alligator_Attack()
    {
        CancelInvoke();
      
        target = GameObject.FindWithTag("Boat").transform;

        float step = speed * Time.deltaTime;
        Vector3 offset = new Vector3(0, .2f, 0);
        Vector3 targetHeading = target.position + offset;
        Vector3 targetDirection = targetHeading.normalized;
        float old_x_location = transform.position.x;
        transform.position = Vector3.MoveTowards(transform.position, targetHeading, step);
        float new_x_location = targetHeading.x;


        float difference_between_locations = old_x_location - new_x_location;
        if (difference_between_locations < 0) difference_between_locations = difference_between_locations * -1;
        if (difference_between_locations < 1)
        {
            // pushBack();
           
            gameController.Alligator_Damage();
            
        }

    }

}
