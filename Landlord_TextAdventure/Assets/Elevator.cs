using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elevator : MonoBehaviour {

    //elevator man is special
    //he knows not of mortal bounds
    //he does not follow the rules i have for other characters.
    
    int choice1;
    int choice2;
    public GameObject player;
    public GameObject camera;
    public GameObject hider;
    public Text dots;
    string message = "ayup";
    ArrayList posmessage = new ArrayList();
    public System.Random rnd = new System.Random();

    // Use this for initialization
    void Start () {
        dots.text = "";
        //fill the message list
        posmessage.Add("Where ya headed boss man?");
        posmessage.Add("They say life's like an elevator *lip smack* i don't know why but someone told me that once.");
        posmessage.Add("Another day, another lift.");
        posmessage.Add("Ya need a pick me up, or a pick me down? I can take ya there.");
        posmessage.Add("Sometimes I go from the top, and I make it drop.");
        posmessage.Add("Sometimes I wonder if I'm workin hard or hardly workin' either way i'm being underpaid.");
        posmessage.Add("I'm just not a fan of elevator jokes, they drive me up the wall.");
        posmessage.Add("I can't stand elevator puns, they are just bad on so many levels");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        //variables with coords of each floor
        //floor selected variable, store what i made the choices
        //compare the static int choice and what i stored :)
        //when the collider this script is attached to hits the player
        //determine what floor collider it is
        //pick random idle line out of 10 or so
        //if floor 1, prompt floor 2 and 3
        //else if floor 2, promt floor 1 and 3
        //else if floor 3, prompt floor 1 and 2
        //else things have gone horribly wrong
        if(col.collider.tag == "Player" && !PlayerController.elevatorActive) //making sure this is the player
        {
            //determine the message

            //if have NEVER used the elevator,
            //describe my GUY the elevator man
            if(PlayerController.elevatorUses == 0)
            {
                message = "You see an older man standing next to the elevator, " +
                    "he has a graying beard with a lit cigarette in his right hand. " +
                    " He looks you in the eyes gives you a small nod and asks you \"What Floor\"";
               
            }
            else
            {
                Random rnd = new Random();
                int randomNumber = Random.Range(0, (posmessage.Count-1));
                message = (string)posmessage[randomNumber];
            }


            if (this.name == "elevator1")
            {
                print("on floor 1");
                choice1 = 2; choice2 = 3;
                player.GetComponent<PlayerController>().showUI("Floor 2", "Floor 3", message, "Tom Elevator");
                
            }
            else if (this.name == "elevator2")
            {
                print("on floor 2");
                choice1 = 1; choice2 = 3;
                player.GetComponent<PlayerController>().showUI("Floor 1", "Floor 3", message, "Tom Elevator");
               
            }
            else if (this.name == "elevator3")
            {
                print("on floor 3");
                choice1 = 1; choice2 = 2;
                player.GetComponent<PlayerController>().showUI("Floor 1", "Floor 2", message, "Tom Elevator");
                
            }


            PlayerController.elevatorUses++;
            //wait till floor is selected
            StartCoroutine(Selection());
        }
    }
    

    //coroutine for when the player needs to make a choice
    IEnumerator Selection()
    {
        PlayerController.elevatorActive = true;
        //wait for mouse click
        yield return new WaitUntil(() =>
            Input.GetMouseButtonDown(0));
        StartCoroutine(load());
        yield return new WaitForSeconds(0.5f);
        //if choice = 1
        if (PlayerController.choice == 1)
        {
            print("Selection 1");
            if(choice1 == 1)
            {
                print("Flor 1");
                //tp cam and player to floor 1
                player.transform.position = (new Vector3(-3, 0, 0));

                camera.transform.position = (new Vector3(0, 0, -10));
            }
            else if(choice1 == 2)
            {
                print("Flor 2");
                //tp cam and player to floor 2
                player.transform.position = (new Vector3(-18f, 0, 0));
                camera.transform.position = (new Vector3(-15f, 0, -10));
            }
        }
        else if(PlayerController.choice == 2)
        {
            print("Selection 2");
            if (choice2 == 2)
            {
                print("Flor 2");
                //tp cam and player to floor 2
                player.transform.position = (new Vector3(-18f, 0, 0));
                camera.transform.position = (new Vector3(-15f, 0, -10));
            }
            else if (choice2 == 3)
            {
                print("Flor 3");
                //tp cam and player to floor 3
                player.transform.position = (new Vector3(-33f, 0, 0));
                camera.transform.position = (new Vector3(-30f, 0, -10));
            }
        }
        //reset 
        choice1 = 0; choice2 = 0; PlayerController.choice = 0;
        yield return new WaitForSeconds(1f);
        PlayerController.elevatorActive = false;
    }
    
    IEnumerator load()
    {
        //black screen dots and a ding :)
        PlayerController.canMoving = false;
        hider.transform.position = new Vector3(-15, 0, -3);
        for (int i = 0; i < 3; i++)
        {
            PlayerController.canMoving = false;
            dots.text = "";
            yield return new WaitForSeconds(0.2f);
            dots.text = ".";
            yield return new WaitForSeconds(0.2f);
            dots.text = "..";
            yield return new WaitForSeconds(0.2f);
            dots.text = "...";
            yield return new WaitForSeconds(0.2f);
        }

        //reset screen
        PlayerController.canMoving = true; 
        dots.text = "";
        hider.transform.position = new Vector3(-15, 30, -3);
    }

}
