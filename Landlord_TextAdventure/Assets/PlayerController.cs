using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for UI elements
//File libraries
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerController : MonoBehaviour {

    public static bool elevatorActive = false, blinks = true, canStop = false;
    public static int elevatorUses = 0;
   // public Text myText;
  //  public Slider mySlider;
    public float speed = 1f;
    Vector3 previousPosition;
    Vector3 lastMoveDirection;
   public static bool canMoving = false, isPrinting = false, hit = false, ui = false;
    float moveDistanceX = 1f, moveDistanceY = 1f;
    public GameObject option1button, option2button, player, manager;
    Vector3 dest; //spot to move towards
    public  Text descriptionText, b1text, b2text, statusText, charname;
    public Image background, nameback;
    Animator anim;
    Rigidbody2D rb;
    public static new string name;
        public static  string items;
    public static int balance = 0;
    public static int choice = 0; //which button the user pressed
    public InputField iField;

	// Use this for initialization
	void Start () {

        
        hideUI();
        StartCoroutine(GetName());
        rb = GetComponent<Rigidbody2D>(); //hook up rb
        print("Test");
        anim = GetComponent<Animator>(); //hook up Animator

        dest = transform.position;
        descriptionText.text = "";
        statusText.text = "";

        //deactive option buttons
        option1button.SetActive(false);
        option2button.SetActive(false);

        //set position checkers
        previousPosition = transform.position;
        lastMoveDirection = Vector3.zero;
        balance = 0;

    }
	
	// Update is called once per frame
	void Update () {

       
        if(Input.GetKeyDown("[7]"))
            {
            hideUI();
            Destroy(GameObject.Find("Walls"));
            }

        //move player towards the mouse
        if (canMoving) { 
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos .z = 0; 
        transform.position = Vector3.Lerp(transform.position,
            mousePos, speed * Time.deltaTime);
            
    }
        //check position
        if (transform.position != previousPosition)
        {
            lastMoveDirection = (transform.position - previousPosition).normalized;
            previousPosition = transform.position;
        }
        if(!hit)
        { 
        //set animator to the directon of the player
        if(lastMoveDirection.y < 0.5 &&
            lastMoveDirection.y > -0.5)
        {
            if (lastMoveDirection.x > 0)
            {
                anim.SetTrigger("Right");
            }
            else if (lastMoveDirection.x < 0)
            {
                anim.SetTrigger("Left");
            }

        }
        else
        {
            if (lastMoveDirection.y > 0.5f)
            {
                anim.SetTrigger("Up");
            }
            else if (lastMoveDirection.y < -0.5)
            {
                anim.SetTrigger("Down");
            }
        }
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

        

     

    //coroutine for when the player needs to make a choice
    IEnumerator Selection()
    {
        //wait for mouse click
        yield return new WaitUntil(() =>
            Input.GetMouseButtonDown(0));

      
    }
    
    //methods connected to option buttons
    public void Option1()
    {
        choice = 1;
        blinks = false;
        hideUI();
    }
    public void Option2()
    {
        choice = 2;
        blinks = false;
        hideUI();
    }

    public void hideUI()
    {
        /*
         *   public GameObject option1button, option2button;
    public Text descriptionText, b1text, b2text, statusText;
    public Image background;
    *///get player's name before playing, if needed
        print("hiding ui");
       iField.gameObject.SetActive(false);
        ui = false;
       option1button.SetActive(false);
        option2button.SetActive(false);
        background.enabled = false;
        nameback.enabled = false;
        charname.text = "";
        descriptionText.text = "";
        b1text.text = "";
        b2text.text = "";
        StartCoroutine(moveDelay());
        blinks = false;
        statusText.text = name + "\n" + "$" + balance + items;
      //  myText.text = "";
       // mySlider.enabled = false;
        StopCoroutine(printMessage(""));
        StopCoroutine(printMessage(""));
        //statusText.text = "";


    }
    //showUI overloads
    //one string -> just the message
    //two strings -> message + name
    //three strings -> message + options
    //four strings -> message + options + name
    public void showUI(string b1, string b2, string desc)
    {
        statusText.text = name + "\n" + "$" + balance + items;
        
        ui = true;
        print("Showing ui 3");
        option1button.SetActive(true);
        option2button.SetActive(true);
        background.enabled = true;
            //kill what IS runnin
            blinks = false;
        canStop = false;
        StartCoroutine(printMessage(desc));
        b1text.text = b1;
        b2text.text = b2;
        canMoving = false;
    }

    public void showUI(string b1, string b2, string desc, string character)
    {
        statusText.text = name + "\n" + "$" + balance +items;

        ui = true;
        print("Showing ui 4 ");
        option1button.SetActive(true);
        option2button.SetActive(true);
        background.enabled = true;
        nameback.enabled = true;
        charname.text = character;
        //kill what IS runnin
        blinks = false;
        canStop = false;
        StartCoroutine(printMessage(desc));
        b1text.text = b1;
        b2text.text = b2;
        canMoving = false;
    }

    public void showUI(string desc, string character)
    {
        statusText.text = name + "\n" + "$" + balance + items;

        ui = true;
        print("Showing ui 2");
        background.enabled = true;
        nameback.enabled = true;
        charname.text = character;
        //kill what IS runnin
        blinks = false;
        canStop = true;
        StartCoroutine(printMessage(desc));
        canMoving = false;
    }

    public void showUI(string desc)
    {
        statusText.text = name + "\n" + "$" + balance + items;

        ui = true;
        print("Showing ui 1");
        background.enabled = true;
            //kill what IS running
            blinks = false;
        canStop = true;
        print("sending" + desc);
            StartCoroutine(printMessage(desc));
        canMoving = false;
        
    }

  
    void OnCollisionEnter2D(Collision2D col)
    {
        hit = true;
        if(col.collider.tag == "Unit")
        {
            if(col.collider.name == "unit1")
            {
                manager.GetComponent<UnitManager>().startTalk(1);
            }
            else if (col.collider.name == "unit2")
            {
                manager.GetComponent<UnitManager>().startTalk(2);
            }
            else if (col.collider.name == "unit3")
            {
                manager.GetComponent<UnitManager>().startTalk(3);
            }
            else if (col.collider.name == "unit4")
            {
                manager.GetComponent<UnitManager>().startTalk(4);
            }
            else if (col.collider.name == "unit5")
            {
                manager.GetComponent<UnitManager>().startTalk(5);
            }
            else if (col.collider.name == "unit6")
            {
                manager.GetComponent<UnitManager>().startTalk(6);
            }
            else if (col.collider.name == "unit7")
            {
                manager.GetComponent<UnitManager>().startTalk(7);
            }
            else if (col.collider.name == "unit8")
            {
                manager.GetComponent<UnitManager>().startTalk(8);
            }
            else if (col.collider.name == "unit9")
            {
                manager.GetComponent<UnitManager>().startTalk(9);
            }
            else if (col.collider.name == "unit10")
            {
                manager.GetComponent<UnitManager>().startTalk(10);
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        StartCoroutine(hitWait());
    }

    IEnumerator hitWait()
    {
        yield return new WaitForSeconds(0.1f);
        hit = false;
    }

    IEnumerator moveDelay()
    {
        yield return new WaitForSeconds(0.75f);
        if(ui == false)
        { 
        canMoving = true;
        }
    }
    IEnumerator printMessage(string message)
    {
        print(message + "started");
        if (ui && !isPrinting)
            {
            print("printing" + message);
            //reset
             isPrinting = true;
             descriptionText.text = "";
            blinks = true;
            for (int i = 0; i < message.Length; i++)
             {//make sure ui still there
                if (ui)
                {
                    //puncuation pause
                    if (message[i].Equals((char)44) || message[i].Equals((char)46)
                            || message[i].Equals((char)33) || message[i].Equals((char)63))
                    {
                        descriptionText.text += message[i];
                        yield return new WaitForSeconds(0.75f);
                        
                    }
                    else
                    {
                        yield return new WaitForSeconds(0.03f);
                        descriptionText.text += message[i];
                        

                    }
                }
            
        }
            //blinkys
            int count = 0;
            while (blinks)
            {
                canMoving = false;
                print("blinks");
                count++;
                descriptionText.text += "|";
                yield return new WaitForSeconds(0.3f);
                descriptionText.text = message;
                yield return new WaitForSeconds(0.3f);

                if (count == 3 && canStop)
                {
                    print("FAIL");
                    blinks = false;
                }
            }
            print("END");
            isPrinting = false;
            hideUI();
        }
        
    }

   
    //coroutine for getting player name
    IEnumerator GetName()
    {
        iField.gameObject.SetActive(true);
        canStop = false;
        //activate input
        showUI("", "", "What is your name?");
        option1button.SetActive(false);
        option2button.SetActive(false);
        //deactivate game until player enters name
        //wait until something is entered with the Enter key
        yield return new WaitUntil(() =>
       iField.text != "" && Input.GetKeyDown(KeyCode.Return));
        descriptionText.text = "";
        //store name
        name = iField.text;
        print(name);
        //deactivate input field
        hideUI();
        //allow game to continue
        canMoving = false;
        player.GetComponent<introduction>().begin();
    }
}
