using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introduction : MonoBehaviour
{
    public GameObject player, bed, desk, carpet, doorlock, death;
    bool gettingName = false;
    //public System.Random rnd = new System.Random();
    int bedCount, deskCount, carpetCount, lockCount;
    bool bedCool = true, queue = false, motivatable = true;
    int queuelength = 0;

    // Use this for initialization
    void Start()
    {
        bedCount = 0; deskCount = 0; carpetCount = 0; lockCount = 0;
        //VERY FIRST THING - get name
        //on start you are in da bed
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void begin()
    {
        StartCoroutine(intro());
    }
    IEnumerator intro()
    {
        PlayerController.canMoving = false;
        print("RUNNING INTRO");
        //on start you are in da bed
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<PlayerController>().hideUI();
        PlayerController.canMoving = false;
        player.GetComponent<PlayerController>().showUI("ZZZ-Zzzz-ZZzzz-hngGGggh-Ppbhww.");
        yield return new WaitForSeconds(1);
        print(PlayerController.isPrinting);
        yield return new WaitWhile(() => PlayerController.isPrinting == true);
        string message = "You awake from your slumber ecstatic and content for the upcoming day."
            + " Rent is due and you " + PlayerController.name + " are a leech, sorry I mean, a landlord. You must fulfil your obligation and collect what"
       + " is \"rightfully\" owed to you. ";
        player.GetComponent<PlayerController>().showUI(message);
        yield return new WaitWhile(() => PlayerController.isPrinting == true);
        message = "Use the mouse to navigate!";
        player.GetComponent<PlayerController>().showUI(message);
        yield return new WaitForSeconds(2.5f);
        bedCool = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //hits the bed
        if (col.name == "bed" && !bedCool)
        {//first hit message
            if (bedCount == 0)
            {
                string message = "You look at your bed, you know that now is not the time to sleep, you must grind.";
                StartCoroutine(sendMessage(message));
            }
            else
            {
                //all other (3 idles?)
                if (bedCount % 3 == 0)
                {
                    string message = "You drank too much gamer juice and could'nt even dream of sleeping";
                    StartCoroutine(sendMessage(message));
                }
                else if(bedCount % 2 == 0)
                {
                    string message = "You stare at the pillows longingly but know there is work to be done.";
                    StartCoroutine(sendMessage(message));
                }
                else
                {
                    string message = "You dream of money and know that to make money means to not sleep. Rise and Grind.";
                    StartCoroutine(sendMessage(message));
                }
            }
            bedCount++;
        }



        //hits the desk
        if(col.name == "desk")
        {
            if(deskCount == 0)
            {
                //fun shuff
                StartCoroutine(deskRun());
            }
            else
            {
                string message = "You have already submitted your taxes to the IRS for review.";
                StartCoroutine(sendMessage(message));
            }
            deskCount++;
        }

        
        //hits the motivational carpet
        if(col.name == "carpet" && motivatable)
        {
            motivatable = false;
            {//first hit message
                if (carpetCount == 0)
                {
                    string message = "This is your motivational carpet, with out it you would fail to function.";
                    StartCoroutine(sendMessage(message));
                }
                else
                {
                    //all other (3 idles?)
                    if (carpetCount % 3 == 0)
                    {
                        string message = "You are thinking of your finacial future and not noticing the shutterstock logo";
                        StartCoroutine(sendMessage(message));
                    }
                    else if (carpetCount % 2 == 0)
                    {
                        string message = "All you see are dollar bills and oportunity.";
                        StartCoroutine(sendMessage(message));
                    }
                    else
                    {
                        string message = "OOOHHHH YYYEEEEAAAAAHHHH, you are feeling motivated";
                        StartCoroutine(sendMessage(message));
                    }
                }
                carpetCount++;
                StartCoroutine(motCooldown());
            }
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // should only happen if door lock EXISTS
        //hits the door lock
        if (col.collider.name == "room lock")
        {
            if(lockCount == 0)
            {
                string message = "Oh darn! you left your keys on the desk. You should probably go back and grab them!";
                StartCoroutine(sendMessage(message));   
            }
            else if(lockCount == 1)
            {
                string message = "Your keys are on your desk, you know, the one behind you.";
                StartCoroutine(sendMessage(message));
            }
            else if (lockCount == 2)
            {
                string message = "You aren't getting this, are you? Go. To. Your. Desk.";
                StartCoroutine(sendMessage(message));
            }
            else if (lockCount == 3)
            {
                string message = "Ughhh, you don't question why you need a key to leave your own room and just go to your desk as your subconscious suggests.";
                StartCoroutine(sendMessage(message));
            }
            else
            {
                string message = "Fine. Be that way, you can leave but you are missing something VITAL.";
                StartCoroutine(sendMessage(message));
                Destroy(doorlock);
            }
            lockCount++;
        }
        
        

            
    }
    IEnumerator motCooldown()
    {
        //motivation is far too powerful
        yield return new WaitForSeconds(7f);
        motivatable = true;
    }

    IEnumerator sendMessage(string message)
    {
        yield return new WaitWhile(() => PlayerController.isPrinting == true);
        player.GetComponent<PlayerController>().showUI(message);
    }

    IEnumerator deskRun()
    {
        yield return new WaitWhile(() => PlayerController.isPrinting == true);
        player.GetComponent<PlayerController>().showUI("You look at your desk and notice that you have not filed your taxes, you need to login to your tax account to get your money. You think longingly trying to remember your username and password.");
        yield return new WaitWhile(() => PlayerController.isPrinting == true);
        string user2 = PlayerController.name + "thelandlord";
        player.GetComponent<PlayerController>().showUI("jeffyBebos421", user2 ,"You have narrowed your tax Username down to two possible choices.");
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return new WaitForSeconds(0.5f);
        if (PlayerController.choice == 1) //jeffyBebos421
        {
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            player.GetComponent<PlayerController>().showUI("Amaz0ink3r@1956", "sp@ceC0WBOY", "You got it! Or at least got something, anyways, you are prompted for \"your\" password.");
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return new WaitForSeconds(0.5f);
            if(PlayerController.choice == 1)
            {
                int prebal = UnityEngine.Random.Range(75, 100);
                
                string message = "A successful login! Somehow. You click withdraw on your tax refund becuase you understand "
                    + "how taxes work and have done them many times before. $" + (prebal * 100) + " is added to your account!";
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                player.GetComponent<PlayerController>().showUI(message);
                PlayerController.balance = prebal * 100;
            }
            else
            {
                int prebal = UnityEngine.Random.Range(0, 25);
                
                string message = "The login fails, you smack your computer in rage and then suddenly it explodes! "
                    + "as the narrator, I feel bad for you so i'm going to give you $" + (prebal * 100) 
                   + " don't spend it all in one place!";
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                player.GetComponent<PlayerController>().showUI(message);
                Instantiate(death);
                Destroy(desk);
                PlayerController.balance = prebal * 100;
            }
        }
        else
        {
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            player.GetComponent<PlayerController>().showUI("notaleech07", "F3xB:dM_%HxRyoga", "You ask yourself how foolish you could be to forget such an easy username, if the username is easy the password must be too, right?");
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return new WaitForSeconds(0.5f);
            if (PlayerController.choice == 1)
            {
                int prebal = UnityEngine.Random.Range(50, 75);
                string message = "Wow you did it! Look how exciting taxes are, this is such a fun time for you, ok you're done "
                    + "here is your $" + (prebal * 100) + " from taxes that you did correctly and did not fraud";
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                player.GetComponent<PlayerController>().showUI(message);
                PlayerController.balance = prebal * 100;
            }
            else
            {
                int prebal = UnityEngine.Random.Range(25, 50);
                string message = "Password correct! You have such a great memory, like a bumble bee. After logging in you file your forms "
                    + "and claim $" + (prebal * 100) + " because that is how taxes work (trust me i am in your head so i know more than you)";
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                
                player.GetComponent<PlayerController>().showUI(message);
                PlayerController.balance = prebal * 100;
            }
        }

        Destroy(doorlock);
    }


}
