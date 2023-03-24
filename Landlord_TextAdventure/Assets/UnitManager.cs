using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitManager : MonoBehaviour
{
    public GameObject hider;
    public GameObject player;
    bool[] interacted = new bool[10];
    bool[] idle = new bool[10]; //false is "bad idle" true is "good idle"
    string[] names = new string[10];

    void Start()
    {
        Screen.SetResolution(1024, 768, false);
        for (int i = 0; i < 10; i++)
        {
            interacted[i] = false;
        }
        names[9] = "Dave";
        names[8] = "Avril";
        names[7] = "Mary-Bell";
        names[6] = "Becky";
        names[5] = "Carol";
        names[4] = "Ann";
        names[3] = "Arthur";
        names[2] = "Clayton";
        names[1] = "Vlad";
        names[0] = "Karl";
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //calls to interactions
    public void startTalk(int unitNum)
    {
        StartCoroutine(checkIfDone());
        if (unitNum == 1)
        {
            StartCoroutine(unit1());
        }
        else if (unitNum == 2)
        {

            StartCoroutine(unit2());
        }
        else if (unitNum == 3)
        {
            StartCoroutine(unit3());
        }
        else if (unitNum == 4)
        {

            StartCoroutine(unit4());
        }
        else if (unitNum == 5)
        {
            StartCoroutine(unit5());
        }
        else if (unitNum == 6)
        {

            StartCoroutine(unit6());
        }
        else if (unitNum == 7)
        {
            StartCoroutine(unit7());
        }
        else if (unitNum == 8)
        {

            StartCoroutine(unit8());
        }
        else if (unitNum == 9)
        {
            StartCoroutine(unit9());
        }
        else if (unitNum == 10)
        {

            StartCoroutine(unit10());
        }
    }

    IEnumerator unit10()
    {
        if (!interacted[9])
        {
            //intro (oi bruv its dave)
            string message = "Hey mate! Nice to see ya again, it was great golfin' the other day, i'm sure you will get better soon! You just gotta work on those long distance putts.";
            player.GetComponent<PlayerController>().showUI(message, names[9]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "What do you mean I'm \"acting out of character\" and that I would \"usually insult your skills, your intelligence, your outfit,\" actually forget about it, make fun of ya's? Your ol' pal Dave? Never";
            player.GetComponent<PlayerController>().showUI(message, names[9]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "Alright i'll quit beating around the bush, I know why you're here, rent's due and im gonna be frank, I a'int got it. "
                + "The people don't want to be accounted for by me, the master accountant.";
            player.GetComponent<PlayerController>().showUI(message, names[9]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "Is there anyway you can cut Good ol' dave a deal?";
            //ask for discount
            player.GetComponent<PlayerController>().showUI("ok, a deal", "cough it up", message, names[9]);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return new WaitForSeconds(0.5f);
            if (PlayerController.choice == 1) //if yes discount
            {
                //send to discount method
                message = "Thanks mate! I knew you'd come around! $400 is good right? I'll get that transfered over!";
                player.GetComponent<PlayerController>().showUI(message, names[9]);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                PlayerController.balance += 400;
                idle[9] = true;
            }
            else//if no discount
            {
                //repromt to be sure
                message = "Please? It's me, your pal, your buddy, grant me a solid just this once please?";
                //ask for discount
                player.GetComponent<PlayerController>().showUI("fine, once", "you pay now", message, names[9]);
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                yield return new WaitForSeconds(0.5f);
                if (PlayerController.choice == 1)//if yes
                {
                    //send to discount method
                    message = "Thanks mate! I knew you'd come around! $400 is good right? I'll get that transfered over!";
                    player.GetComponent<PlayerController>().showUI(message, names[9]);
                    PlayerController.balance += 400;
                    idle[9] = true;
                }
                else//if no
                {
                    //offer half pay and "a good time"
                    message = "I'm telling you i don't got it, how about half and, \"a good time.\"";
                    //ask for discount
                    player.GetComponent<PlayerController>().showUI("take good time", "cash only", message, names[9]);
                    yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                    yield return new WaitForSeconds(0.5f);
                    if (PlayerController.choice == 1)//if yes
                    {
                        message = "Thanks mate! I knew you'd come around!";
                        player.GetComponent<PlayerController>().showUI(message, names[9]);
                        //give $300 and an IOU
                        PlayerController.balance += 300;
                        PlayerController.items += "\nGood Times";
                        idle[9] = true;
                    }
                    else//if no 
                    {
                        //dave is UPSET but wires the money anyway
                        message = "You bloody prick, you greedy little -. After all this time " + PlayerController.name + " really? "
                            + " after all these years? I ask for one favour and you can't do me that? Who was there for you to helped you find this place "
                            + " who helped you move yourself in, that rug wasn't light ya know.";
                        player.GetComponent<PlayerController>().showUI(message, names[9]);
                        yield return new WaitWhile(() => PlayerController.isPrinting == true);
                        message = "It's fine money is all you ever care about anyway, I hope you are happy with your $600, check your account i'll transfer it "
                            + " just know that your, FORMER, friend dave won't be eating this week. *The door slams*";
                        player.GetComponent<PlayerController>().showUI(message, names[9]);
                        PlayerController.balance += 600;
                        idle[9] = false;
                    }

                }
            }
            interacted[9] = true;
        }
        else
        {
            if (idle[9])
            {
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                string message = "You knock on Dave's door but get no response, you suspect he has gone to bed for an afternoon nap";
                player.GetComponent<PlayerController>().showUI(message);
            }
            else
            {
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                string message = "You knock on Dave's door but get no response, either he isn't home or he is ignoring you, and you cant decide which is worse";
                player.GetComponent<PlayerController>().showUI(message);
            }

        }

    }

    IEnumerator unit9()
    {
        if (!interacted[8])
        {
            //intro
            //hi i pay da rent
            string message = "hey! rent day i presume? i had to pick up a few extra shifts this week but i've got it";
            player.GetComponent<PlayerController>().showUI(message, names[8]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "You are handed a wad of crumpled bills and spend an embarrasing amount of time counting them, it comes out to $600, which is exactly what is due.";
            player.GetComponent<PlayerController>().showUI(message);
            PlayerController.balance += 600;
            //offer to show da art
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "All good then? The art fair is tonight and i'm hoping I can sell a few of the peices that I did for class to make some extra money.";
            player.GetComponent<PlayerController>().showUI(message, names[8]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "Oh would you like to come in and see a few?";
            player.GetComponent<PlayerController>().showUI("Sure!", "No, I'm busy", message, names[8]);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return new WaitForSeconds(0.5f);
            if (PlayerController.choice == 1)//if yes
            {
                //yes - show it 
                message = "Come in! Check it out, it's a bit messy but, ya know";
                player.GetComponent<PlayerController>().showUI(message, names[8]);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                message = "you enter the unit, on the floor you see many paintings with riveting colours, complex forms, and meticulous craftmanship";
                player.GetComponent<PlayerController>().showUI(message);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                message = "Maybe you want to buy one? I'm trying to sell them for $100 a piece to make a little profit for my time.";
                player.GetComponent<PlayerController>().showUI("I'll bite", "No thanks", message, names[8]);
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                yield return new WaitForSeconds(0.5f);
                if (PlayerController.choice == 1) //ask if want to buy
                {
                    //yes offer two arts, both give "art"
                    message = "Oh my goody goodness! Thank you so so much! Which one do you want?";
                    player.GetComponent<PlayerController>().showUI(message, names[8]);
                    yield return new WaitWhile(() => PlayerController.isPrinting == true);
                    message = "Your eye is caught to a stunning portait of your favourite celebrity and a photo realistic image of a city scape. Which do you choose";
                    player.GetComponent<PlayerController>().showUI("Celeb", "City", message);
                    yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                    yield return new WaitForSeconds(0.5f);
                    message = "One of my favourite pieces i've done! You have amazing taste! Thank you so much for your business";
                    player.GetComponent<PlayerController>().showUI(message, names[8]);
                    PlayerController.balance -= 100;
                    
                    
                    PlayerController.items += "\nPretty Art";
                    idle[8] = true;
                }
                else
                {
                    //no - ya leave
                    message = "Alright then! Thanks for looking, see you next month for rent again.";
                    player.GetComponent<PlayerController>().showUI(message, names[8]);
                    idle[8] = true;
                }
            }
            else
            {
                //no - don't show it
                message = "Okie dookie then, see you next month when rent is due again.";
                player.GetComponent<PlayerController>().showUI(message, names[8]);
                idle[8] = false;
            }
            interacted[8] = true;
        }
        else
        {
            if (idle[8])
            {
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                string message = "Avril isn't home right now, she is at the Art Fair that she was talking to you about earlier";
                player.GetComponent<PlayerController>().showUI(message);
            }
            else
            {
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                string message = "Avril is'nt home right now, you suspect she is painting ore something else useless and artsy fartsy";
                player.GetComponent<PlayerController>().showUI(message);
            }

        }


    }

    IEnumerator unit8()
    {  
        //Libraian
        if (!interacted[7])
        {
            //intro
            string message = "hey uhh, give me a second here i'm, uhh, sorting the oo--";
            player.GetComponent<PlayerController>().showUI(message, names[7]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "You hear a loud crash followed by a string of curses and a yelp.";
            player.GetComponent<PlayerController>().showUI(message);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "Ah forget about it, how can i help ya today Mister " + PlayerController.name + "!" +
                " ah, " + PlayerController.name + ", I always liked that name, ya know if I had a kid i might name them that.";
            player.GetComponent<PlayerController>().showUI(message, names[7]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            //pay rent 
            message = "oh yeah! rent time, time for rent. let me find it uhhh.";
            player.GetComponent<PlayerController>().showUI(message, names[7]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = names[7] + " Looks around for a minute throwing things left and right hoping to find her cash";
            player.GetComponent<PlayerController>().showUI(message);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "Here it is! It was in my pocket, can you beleive that? All that looking and mess making and it was in my pocket the whole time, wow, well here you go!";
            PlayerController.balance += 600;
            player.GetComponent<PlayerController>().showUI(message, names[7]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
               
            //talk about lib
            message = "Oh i've been working on opening this new Library for the city, that's why i've got all these books here, trying to get them all deweyed up so we can get them on the shelves"
                + " but as you just heard my shelf fell over, that'll make it take a bit longer won't it now?";
            player.GetComponent<PlayerController>().showUI(message, names[7]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "We were hoping to get more books that would be good for the kids but money is running tight you know how it is. If only we had a bit more.";
            player.GetComponent<PlayerController>().showUI("I can donate", "Yup, if only", message, names[7]);
            //ask about dono
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return new WaitForSeconds(0.5f);
            if (PlayerController.choice == 1) //yes dono
            {
                int dono = 0;
                int hold = PlayerController.balance;
                hold /= 500; //takes a fifth of bal (rounded)
                dono = (hold * 100);
                //thanks you very much
                message = "You hand " + names[7] + " $" + dono + " as a donation and she is exstatic";
                PlayerController.balance -= dono;
                player.GetComponent<PlayerController>().showUI(message);
               
                //ask what kind of book ya want
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                message = "Oh my gosh really? The kids really love books, what kind of books do you think we should get more of for these children?";
                player.GetComponent<PlayerController>().showUI("Historical Novels", "Fictious Stories",message, names[7]);
                         //historical or fantasy
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                yield return new WaitForSeconds(0.5f);
                //decision does not matter
                message = "I couldn't agree more, I don't think there is a better way to get them thinking about our world and grow their imagination and knowledge!";
                player.GetComponent<PlayerController>().showUI(message, names[7]);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                message = "Again, thanks so much! See ya soon, you should stop by the library when it opens sometime, get some finace books or something!";
                player.GetComponent<PlayerController>().showUI(message, names[7]);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                idle[7] = true;

            }
            else //no dono
            {
                //alright reading is cool though 
                message = "Alright then! See ya soon, you should stop by the library when it opens sometime, get some finace books or something!";
                player.GetComponent<PlayerController>().showUI(message, names[7]);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                idle[7] = false;
            }

                interacted[7] = true;
        }
        else
        {
            if (idle[7])
            {
                //excitement for upcoming library
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                string message = "you can hear " + names[7] + " joyusly working on organizing and cataloging the selection of titles for the library!"; 
                player.GetComponent<PlayerController>().showUI(message);
            }
            else
            {
                //books outta be banned
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                string message = "You hear grunting and struggling, sounds like " + names[7] + " is trying to get that shelf back up.";
                player.GetComponent<PlayerController>().showUI(message);
            }
        }

    }

    IEnumerator unit7()
    {
        //fashion designer
        if (!interacted[6])
        {
            interacted[6] = true;
            //intro - just on a call
            //yield return new WaitWhile(() => PlayerController.isPrinting == true);
            string message = "You hear hear mummering through the door and wonder if now is a good time, what a silly question, there is no "
                + "\"bad time\" for rent, it's due when it's due.";
            player.GetComponent<PlayerController>().showUI(message);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "You decide to loudly knock on the door, after a minute a young woman emerges with the latest iPhone up to her ear.";
            player.GetComponent<PlayerController>().showUI(message);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "-- Well i don't care about the supply chain, i want it and lord so help me if even a single hemline stich is off you will pay.";
            player.GetComponent<PlayerController>().showUI(message, names[6]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "you ask yourself if you should interupt this important conversation";
            player.GetComponent<PlayerController>().showUI("interupt her", "let the woman speak", message, names[6]);
            //option to interupt
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return new WaitForSeconds(0.5f);
            if (PlayerController.choice == 1) //yes int
            {
                //bitchy response
                message = "you interupt the converstation firmly asking Becky if she is busy.";
                player.GetComponent<PlayerController>().showUI(message);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                message = "Am I busy? Yeah kinda, what do you want?";
                player.GetComponent<PlayerController>().showUI(message, names[6]);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                //daddy will pay later
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                message = "Rent? pffff, Daddy will pay like he always does, is that fine with you?";
                player.GetComponent<PlayerController>().showUI("Indeed", "Actually no",message, names[6]);
                //is that fine
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                yield return new WaitForSeconds(0.5f);
                //decision does not matter
                message = "Well either way it doesn't matter, that's the deal, good bye now.";
                player.GetComponent<PlayerController>().showUI(message, names[6]);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                idle[6] = true;

            }
            else //no dono
            {
                int run = 0;            
                //just, keep talking
                while(PlayerController.choice == 2)
                {
                    //one of three blah blah blah
                    if (run % 3 == 0)
                    {
                        message = "This embelishment is crucial don't you understand? you don't get how important this is, YES IT WILL BE THE END OF THE WORLD! the end of my world";
                        player.GetComponent<PlayerController>().showUI(message, names[6]);
                        yield return new WaitWhile(() => PlayerController.isPrinting == true);
                        message = "you ask yourself if you should interupt this important conversation";
                        player.GetComponent<PlayerController>().showUI("interupt her", "let the woman speak", message);
                    }
                    else if (run % 2 == 0)
                    {
                        message = "The haute couture must be on fleek, i don't care if this isn't vogue, this is my birthday which is arguablly more important"; ;
                        player.GetComponent<PlayerController>().showUI(message, names[6]);
                        yield return new WaitWhile(() => PlayerController.isPrinting == true);
                        message = "you ask yourself if you should interupt this important conversation";
                        player.GetComponent<PlayerController>().showUI("interupt her", "let the woman speak", message);
                    }
                    else
                    {
                        message = "No I already told you I don't want it Ready-To-Wear i Need it custom fitted and I need it perfect";
                        player.GetComponent<PlayerController>().showUI(message, names[6]);
                        yield return new WaitWhile(() => PlayerController.isPrinting == true);
                        message = "you ask yourself if you should interupt this important conversation";
                        player.GetComponent<PlayerController>().showUI("interupt her", "let the woman speak", message);


                    }
                    //choice to interupt counted
                    yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                    yield return new WaitForSeconds(0.5f);
                    run++;
                }
                //you HAD to interupt
                message = "you interupt the converstation timidly asking Becky if she is busy.";
                player.GetComponent<PlayerController>().showUI(message);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                message = "Am I busy? what do you think, god can you not look around you for three seconds? you imbecile.";
                player.GetComponent<PlayerController>().showUI(message, names[6]);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                //god damn daddy will pay like he always does
                message = "Daddy will pay you like he always does, now scram! go! get out off here and quit ruining my conversations.";
                player.GetComponent<PlayerController>().showUI(message, names[6]);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                idle[6] = false;
            }

        }
        else
        {
            if (idle[6])
            {
                //daddy pays
                //oh, daddy paid
                int run = 0;
                if (run == 0)
                {
                    PlayerController.balance += 600;
                    run++;
                }
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                string message = "You check your bank account and notice that \"Daddy\" has paid you for the rent.";
                player.GetComponent<PlayerController>().showUI(message);
            }
            else
            {
                //rent not paid
                //you dare not interupt
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                string message = "You hear screaming through the walls, but know better than to disturb the girl again, assuming you would like to live another day.";
                player.GetComponent<PlayerController>().showUI(message);
            }
        }

    }

    IEnumerator unit6()
    {
        //cat lady
        yield return new WaitForEndOfFrame();
        if (!interacted[5])
        {
            //intro
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            string message = "Hey there sunny boy how can i help ya today, rents due, WHAT, already, ok then, $600 right? ok. ok.";
            player.GetComponent<PlayerController>().showUI(message, names[5]);
            //shuffling out rent
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = names[5] + " slowly counts out $20 bills from her wallet, very slowly, one, by, one, by, one, by, one, by, one, until she has 15 of them crumpled up in her hand";
            player.GetComponent<PlayerController>().showUI(message);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "here ya go whipper snapper will that be --";
            player.GetComponent<PlayerController>().showUI(message, names[5]);
            //you hear a meow
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "MROW...";
            player.GetComponent<PlayerController>().showUI(message, "?");
            //investigate?
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "uhh i have to go now, bye";
            player.GetComponent<PlayerController>().showUI("decide to investigate","assume you are hearing things", message, names[5]);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return new WaitForSeconds(0.5f);
            if (PlayerController.choice == 1) //yes invest
            {
                //you find the cat
                message = "you spot a shape in the corner of the room, you notice it resembles that of a loaf of bread.";
                player.GetComponent<PlayerController>().showUI(message);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                message = "apon further investigation you realize, it's a cat! cats are strictly prohibited in your complex.";
                player.GetComponent<PlayerController>().showUI(message);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                //pleading
                message = "please don't evict me i'm so sorry, i just saw her, merideth, at the shelter and just couldn't leave her";
                player.GetComponent<PlayerController>().showUI(message, names[5]);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                message = "I know the rules but I had no choice please, if not for me, than for her";
                player.GetComponent<PlayerController>().showUI(message, names[5]);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                message = "Mrow?";
                player.GetComponent<PlayerController>().showUI("evict them", "allow the pet",message, "Merideth");
                //evict or allow
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                yield return new WaitForSeconds(0.5f);
                if (PlayerController.choice == 1) // evict 
                {
                    //evicted :(
                    message = "You know that rules are rules are rules no matter the circumstances, you decide to evict the woman and her cat";
                        player.GetComponent<PlayerController>().showUI(message);
                    yield return new WaitWhile(() => PlayerController.isPrinting == true);
                    message = "I understand I’ll start packing my things";
                    player.GetComponent<PlayerController>().showUI(message, names[5]);
                    yield return new WaitWhile(() => PlayerController.isPrinting == true);
                    message = "meow :(";
                    player.GetComponent<PlayerController>().showUI(message, "Merideth");
                    yield return new WaitWhile(() => PlayerController.isPrinting == true);
                    //merideth and carol on the streets
                    idle[5] = false;
                }
                else
                {
                    //many thanks
                    message = "Oh my goodness thank you, we would’ve had no where else to go";
                    player.GetComponent<PlayerController>().showUI(message, names[5]);
                    yield return new WaitWhile(() => PlayerController.isPrinting == true);
                    message = "Meow :D";
                    player.GetComponent<PlayerController>().showUI(message, "Merideth");
                    yield return new WaitWhile(() => PlayerController.isPrinting == true);
                    message = "here let me get you your money, and add a little something extra to thank you for your generosity";
                    player.GetComponent<PlayerController>().showUI(message, names[5]);
                    yield return new WaitWhile(() => PlayerController.isPrinting == true);
                    //rent is paid (With TIP)
                    message = names[5] + " hands you the original $600 along with 5 more $20 bills to total $700";
                    PlayerController.balance += 700;
                    player.GetComponent<PlayerController>().showUI(message, names[5]);
                    yield return new WaitWhile(() => PlayerController.isPrinting == true);
                    
                    idle[5] = true;
                }


            }
            else
            {
                //rent is paid but things seem sussy
                message = "oh wait, here is your money.";
                player.GetComponent<PlayerController>().showUI(message, names[5]);
                //walk away but still hear the mrows
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                message = names[5] + " hands you the money and then quickly shuts the door, you hear her shushing something but could never guess what.";
                player.GetComponent<PlayerController>().showUI(message);
                idle[5] = true;
            }
                interacted[5] = true;
        }
        else
        {
            if (idle[5])
            {
                //carol talking like she is talking to a baby
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                string message = "you hear a \"mrow\" and " + names[5] + " talking to what you assume to be it's source";
                player.GetComponent<PlayerController>().showUI(message);
            }
            else
            {
                //look to the street and see carol packing up her things
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                string message = "You look to the streets and see Carol and Merideth, Carol is trying to carry her boxes out but her old and frail body isn’t that capable";

                player.GetComponent<PlayerController>().showUI(message);
            }
        }
    }

    IEnumerator unit5()
    {
        //single mum
        yield return new WaitForEndOfFrame();
        if (!interacted[4])
        {
            //sorry this is a bad time
            string message = "*through tears* I'm so so sorry this is a horrible time, I- I- I- just found out, little mikey- he has- has-";
            //just found out mikey has Foreign Accent Syndrome
            player.GetComponent<PlayerController>().showUI(message, names[4]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "Foreign Accent Syndrome, it will be terminal if left untreated...";
            player.GetComponent<PlayerController>().showUI(message, names[4]);
            //mikey starts speaking british
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "OI BRUV, FAncy a cuppa? i'm bloody chuffed to bits, blimey blimey innit?";
            player.GetComponent<PlayerController>().showUI(message, "Mikey");
            //treatmeat cost $600 (same as rent)
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "WAAAAAAAAH NO!!! Tr-Tr-Treatment is $600 but I have to use that money for rent...";
            player.GetComponent<PlayerController>().showUI(message, names[4]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "What are you going on about? The Queen died? NOOO GOD SAVE THE QUEEN, what a cock up she was a good egg innit? That’s manky.";
            player.GetComponent<PlayerController>().showUI(message, "Mikey");
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "Oh NO! It's getting so much worse and so quickly, he needs treatment and fast!";
            player.GetComponent<PlayerController>().showUI(message, names[4]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            //ask for extension
            message = "Is there anyway I can have an extension on rent, I need to get Mikey treatment! and fast!";
            player.GetComponent<PlayerController>().showUI("Allow an extension", "Rent is due", message, names[4]);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return new WaitForSeconds(0.5f);
            if (PlayerController.choice == 1) //yes extension
            {
                //thanks mikey will be american again
                message = "thank you so much! I can go and get him treatment, he will be an american again! God bless the USA!";
                player.GetComponent<PlayerController>().showUI(message, names[4]);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                //no pay rent
                idle[4] = true;
            }
            else //no extension
                {
                //this is life threating but i understand
                message = "This is very life threating but i understand.";
                player.GetComponent<PlayerController>().showUI(message, names[4]);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                //rent is paid
                message = "I'll transfer over the rent";
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                message = "Are you trying to bodge it up? Oh, what a load of codswallop! I'm bloody knackered innit!";
                PlayerController.balance += 600;
                player.GetComponent<PlayerController>().showUI(message, "Mikey");
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                

                idle[4] = false;
                }
            interacted[4] = true;
        }
                
        
        else
        {
            if (idle[4])
            {
                //mikey speaking american
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
               string message = "HAMBORGER.";
                player.GetComponent<PlayerController>().showUI(message, "Mikey");
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "Praise the lord he is cured!";
             player.GetComponent<PlayerController>().showUI(message, names[4]);
}
            else
            { //mikey speaking british and mom is crying
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
               string message = "GOD SAVE THE QUEEN, OH I MISS THE QUEEN";
                player.GetComponent<PlayerController>().showUI(message, "Mikey");
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
               message = "NOOOO FORGET ABOUT ELIZABETH PLEASE";
             player.GetComponent<PlayerController>().showUI(message, names[4]);
}
        }
    }

    IEnumerator unit4()
    {
        //art collector
        yield return new WaitForEndOfFrame();
        if (!interacted[3])
        {
            //rent is simply paid
            string message = "bonjour! if you are here for ze rent i already paid it in advance i belive";
            player.GetComponent<PlayerController>().showUI(message, names[3]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            PlayerController.balance += 600;
            message = "see I have ze transaction recipt on my mobile device";
            player.GetComponent<PlayerController>().showUI(message, names[3]);
            //monologue about the search for art
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "perhaps now that you have found your moneys, you can assist me in the search for something much greater.";
            player.GetComponent<PlayerController>().showUI(message, names[3]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "Alas this world can be so ugly and horrific, but i search for something with much more beaute";
            player.GetComponent<PlayerController>().showUI(message, names[3]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "Oh art how Je t’aime, alas my search for you draws no closer to it's conclusion";
            player.GetComponent<PlayerController>().showUI(message, names[3]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            if ((PlayerController.items.Contains("Pretty Art")))// has art in iventory
            {
                //do you have any art
                message = "Have you seen anything magnifique?";
                player.GetComponent<PlayerController>().showUI(message, names[3]);
                //yes or no
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                yield return new WaitForSeconds(0.5f);
                if (PlayerController.choice == 1) //yes have art
                {
                    //is amaze balls
                    message = "oh my goodness, you must let me view this peice you speak of!";
                    player.GetComponent<PlayerController>().showUI(message, names[3]);
                    yield return new WaitWhile(() => PlayerController.isPrinting == true);
                    message = "You pull out the piece of art you recived from Avril earlier today, and show it to the ecstatic french man";
                    player.GetComponent<PlayerController>().showUI(message);
                    yield return new WaitWhile(() => PlayerController.isPrinting == true);
                    message = "that piece is simply superbe! I must have it!";
                    player.GetComponent<PlayerController>().showUI(message, names[3]);
                    yield return new WaitWhile(() => PlayerController.isPrinting == true);
                    //offers to buy for $500'
                    message = "I particularly agree with it's subject matter so I am willing to offer you $500, will you accept my offer?";
                    player.GetComponent<PlayerController>().showUI("Of Course", "No Thanks", message, names[3]);
                    //accept or decline
                    yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                    yield return new WaitForSeconds(0.5f);
                    if (PlayerController.choice == 1) //yes have art
                    {
                        //accept offer
                        message = "O Merci beaucoup! This is merveilleuse! I will worship this piece with great gradeur, Merci! Merci!";
                        player.GetComponent<PlayerController>().showUI(message, names[3]);
                        //player - art
                        PlayerController.items = PlayerController.items.Replace("\nPretty Art", "");
                        //player bal += 500
                        PlayerController.balance += 500;
                        message = "O Merci beaucoup! This is merveilleuse! I will worship this piece with great gradeur, Merci! Merci!";
                        player.GetComponent<PlayerController>().showUI(message, names[3]);
                        idle[3] = true;

                    }
                    else
                    {
                        //oh darn must continue search else where
                        message = "I understand! Personally I could never part with such a magnifficent piece!";
                        player.GetComponent<PlayerController>().showUI(message, names[3]);
                        yield return new WaitWhile(() => PlayerController.isPrinting == true);
                        message = "Do come back if you change your mind!";
                        player.GetComponent<PlayerController>().showUI(message, names[3]);
                        idle[3] = false;
                    }
                }
                else //no have art
                {
                    //have no art
                    message = "Let me know if you spot something truly eye catching!";
                    player.GetComponent<PlayerController>().showUI(message, names[3]);
                    yield return new WaitWhile(() => PlayerController.isPrinting == true);
                    message = "Until then my search continues!";
                    player.GetComponent<PlayerController>().showUI(message, names[3]);
                    //lmk if you find any
                    idle[3] = false;
                }

            }
            else
            {
                //have no art
                message = "Let me know if you spot something truly eye catching!";
                player.GetComponent<PlayerController>().showUI(message, names[3]);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                message = "Until then my search continues!";
                player.GetComponent<PlayerController>().showUI(message, names[3]);
                //lmk if you find any
                idle[3] = false;
            }
            interacted[3] = true;
        }
        else
        {
            if (idle[3])
            {
                //searching for more arts
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                string message = "The french man has left in search of more stunning masterpieces!";
                player.GetComponent<PlayerController>().showUI(message);
            }
            else
            {
                //ask if found any art
                string message = "Alas my search for true beauty continues!";
                player.GetComponent<PlayerController>().showUI(message, names[3]);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                //if player did (contians art)

                //copy yes code from earlier
                if ((PlayerController.items.Contains("Pretty Art")))// has art in iventory
                {
                    //do you have any art
                    message = "Have you seen anything magnifique?";
                    player.GetComponent<PlayerController>().showUI(message, names[3]);
                    //yes or no
                    yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                    yield return new WaitForSeconds(0.5f);
                    if (PlayerController.choice == 1) //yes have art
                    {
                        //is amaze balls
                        message = "oh my goodness, you must let me view this peice you speak of!";
                        player.GetComponent<PlayerController>().showUI(message, names[3]);
                        yield return new WaitWhile(() => PlayerController.isPrinting == true);
                        message = "You pull out the piece of art you recived from Avril earlier today, and show it to the ecstatic french man";
                        player.GetComponent<PlayerController>().showUI(message);
                        yield return new WaitWhile(() => PlayerController.isPrinting == true);
                        message = "that piece is simply superbe! I must have it!";
                        player.GetComponent<PlayerController>().showUI(message, names[3]);
                        yield return new WaitWhile(() => PlayerController.isPrinting == true);
                        //offers to buy for $500'
                        message = "I particularly agree with it's subject matter so I am willing to offer you $500, will you accept my offer?";
                        player.GetComponent<PlayerController>().showUI("Of Course", "No Thanks", message, names[3]);
                        //accept or decline
                        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                        yield return new WaitForSeconds(0.5f);
                        if (PlayerController.choice == 1) //yes have art
                        {
                            //accept offer
                            message = "O Merci beaucoup! This is merveilleuse! I will worship this piece with great gradeur, Merci! Merci!";
                            player.GetComponent<PlayerController>().showUI(message, names[3]);
                            //player - art
                            PlayerController.items = PlayerController.items.Replace("\nPretty Art", "");
                            //player bal += 500
                            PlayerController.balance += 500;
                            message = "O Merci beaucoup! This is merveilleuse! I will worship this piece with great gradeur, Merci! Merci!";
                            player.GetComponent<PlayerController>().showUI(message, names[3]);
                            idle[3] = true;

                        }
                        else
                        {
                            //oh darn must continue search else where
                            message = "I understand! Personally I could never part with such a magnifficent piece!";
                            player.GetComponent<PlayerController>().showUI(message, names[3]);
                            yield return new WaitWhile(() => PlayerController.isPrinting == true);
                            message = "Do come back if you change your mind!";
                            player.GetComponent<PlayerController>().showUI(message, names[3]);
                            idle[3] = false;
                        }
                    }
                }
            }
        }
    }

    IEnumerator unit3()
    {
        //geneticist
        yield return new WaitForEndOfFrame();
        if (!interacted[2])
        {
            //context that is way late on rent
            string message = "Hey! I know that I asked for an extension last month, but can I PLEASE just have one more month?";
            player.GetComponent<PlayerController>().showUI(message, names[2]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            //big breakthough
            message = "This genetic motification project is in it's final stages! I swear to you, it's a billion dollar industry about to be made!";
            player.GetComponent<PlayerController>().showUI(message, names[2]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            //please one more month and ill double it
            message = "Please just give me one more month and I'll double it, no, triple it!";
            player.GetComponent<PlayerController>().showUI("ONE MORE MONTH", "Eviction",message, names[2]);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return new WaitForSeconds(0.5f);
            if (PlayerController.choice == 1) //yes wait
            {
                //thanks talk to you later
                message = "Thank you so much! You won't regret it! I promise!";
                player.GetComponent<PlayerController>().showUI(message, names[2]);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                idle[2] = true;
            }
            else
            {
                //eviction
                message = "You will not let this happen, no squater will stay in your complex.";
                player.GetComponent<PlayerController>().showUI(message);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                message = "You call the police on " + names[2] + ", surely they will finally remove him";
                player.GetComponent<PlayerController>().showUI(message);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                //police called - shot in after scene
                idle[2] = false;
            }
                interacted[2] = true;
        }
        else
        {
            if (idle[2])
            {
                //he is working hard on genome
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                string message = "you can tell " + names[2] + " is working tirelessly on his devolpments";
                player.GetComponent<PlayerController>().showUI(message);
            }
            else
            {
                //he is no longer here
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                string message = "The police are on their way, you just need to wait a little longer.";
                player.GetComponent<PlayerController>().showUI(message);
            }
        }
    }

    IEnumerator unit2()
    {
        //vampire
        yield return new WaitForEndOfFrame();
        if (!interacted[1])
        {
            //intro
            string message = "heh-loo there, nice to see you, ah, ah, ah, ah, I assume that you are here for tee rent";
            player.GetComponent<PlayerController>().showUI(message, names[1]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "ah, ah, ah,, off course I have it, here you go! ah, ah, ah, ah";
            player.GetComponent<PlayerController>().showUI(message, names[1]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            PlayerController.balance += 600;
            //rent paid
            //notice something strange
            message = "Suddenly you notice something strange, you look behind " + names[1] + " and notice what appears to be a coffin";
            player.GetComponent<PlayerController>().showUI(message);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            //sunlight, fangs, mirror
            message = "The realization strikes you and you start picking up on the signs! The pale skin, The sharp teeth, the avoidance of sunlight";
            player.GetComponent<PlayerController>().showUI(message);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "and come to think of it you have never seen " + names[1] + " with a mirror";
            player.GetComponent<PlayerController>().showUI(message);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "Do you call it out?";
            player.GetComponent<PlayerController>().showUI("Expose him!", "None of my buisness",message);
            //call it out?
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return new WaitForSeconds(0.5f);
            if (PlayerController.choice == 1) //yes call out
            {
                //i know what you are, youre a
                message = "You tell vlad that know know what's going on! That he is a ";
                player.GetComponent<PlayerController>().showUI("Vampire","Zombie",message);
                
                //vampire

                //zombie
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                yield return new WaitForSeconds(0.5f);
                if (PlayerController.choice == 1) //yes call out
                {
                    //so xenophobic
                    message = "Vat? Oh this becuase I am a Romanian? This is a very harmful steryotype you know? I can not vee-leave this, you are the xenophobe you know? ";
                    player.GetComponent<PlayerController>().showUI(message, names[1]);
                    yield return new WaitWhile(() => PlayerController.isPrinting == true);
                    message = "A vampire really? Ridiculous!";
                    player.GetComponent<PlayerController>().showUI(message, names[1]);
                    yield return new WaitWhile(() => PlayerController.isPrinting == true);
                    idle[1] = false;
                }
                else
                {
                    //in what world?
                    message = "Vat? I know i am very tired but do i really look that bad?";
                    player.GetComponent<PlayerController>().showUI(message, names[1]);
                    yield return new WaitWhile(() => PlayerController.isPrinting == true);
                    message = "A zombie? how curious, people still vee-leave in those?";
                    player.GetComponent<PlayerController>().showUI(message, names[1]);
                    yield return new WaitWhile(() => PlayerController.isPrinting == true);
                    idle[1] = true;
                }
                }
            else
            {
                //thanks see you next month
                message = "Alright then, if that is all ve needed to do, I will be leaving, good-byes now";
                player.GetComponent<PlayerController>().showUI(message, names[1]);
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                idle[1] = true;
            }
                interacted[1] = true;
        }
        else
        {
            if (idle[1])
            {
                //you realize how harmful steryotypes are
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                string message = "You question if what you said to " + names[1] + " was really that harmful, hmmm";
                player.GetComponent<PlayerController>().showUI(message);
            }
            else
            {
                //you are sus
                yield return new WaitWhile(() => PlayerController.isPrinting == true);
                string message = "You still suspect " + names[1] + " but let him pass as human for another day";
                player.GetComponent<PlayerController>().showUI(message);
            }
        }
    }

    IEnumerator unit1()
    {
        //socialist
        yield return new WaitForEndOfFrame();
        if (!interacted[0])
        {
            //based comments
            string message = "ugh you again";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            //doesnt pay rent
            message = "how many times must I remind you that i prepaid my rent";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            //just dropping facts
            message = "who do you think you are? do you think you provide value by housing those unable to afford it themselves? no, " +
                " you are denying access to already existing shelter! Your renters are receiving nothing different and nothing" +
                " improved and no new service from when you first arrived and blocked access.";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "landlords do not create value. The act of landlording is just regular interval wealth extraction in which " +
                "the tenants must pay the landlord from a chunk of their work produced " +
                " during that interval, as an unending upkeep to simply have shelter/a home, shelter! a human right!";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "To create homeless people just so that you can have peopleless homes, is a sin, landlords are not the makers, they are on" +
                "ly the takers.";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "A Landlord's right has its origin in robbery. The landlords, like all other men, love to reap where they never sowed, " +
                "and demand a rent for even the natural produce of the earth. Disgusting.";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            message = "You need to rethink your choices...";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            //no choices
            interacted[0] = true;
        }
        else
        {
            //so disgusted can not bear to face you.
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
            string message = names[0] + "is to disgusted with your behaviour that he can not bear to face you.";
            player.GetComponent<PlayerController>().showUI(message);
           
        }
    }
    
    IEnumerator ending()
    {
        hider.transform.position = new Vector3(-15, 0, -3);
        //after every character has been spoken to
        //enable a different black backround (need to create) so hideUI doesn't kill it
        //new backround only accesable in this script
        string message = "So you finally did it, extorted every person in this building, and for " +
             "what? So that some number would go up? Does money really mean more to you " +
              "than human rights?  You don't need to answer that, I already knew. I might as well tell you what" +
            " happened to them post-extortion.";
        player.GetComponent<PlayerController>().showUI(message, names[0]);
        yield return new WaitWhile(() => PlayerController.isPrinting == true);
        //karl gives ending along with based facts!
        //use the idles to go through and give an "after credits" sequence
        //explain what happened to every character

        //unit 10
        if (idle[9])
        {
            message = "Dave is doing better now but money still has been tight for your friend." +
                " IS he really your friend if you are extorting him for money?";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
        }
        else
        {
            message = "YOu never saw Dave again after forcing him to pay rent, but you didn't care " +
            " enough to hold an investigation, sounds like Dave was right about you.";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
        }

        //unit 9
        if (idle[8])
        {
            message = "Avril started to get her art buisness off of the ground but student debt and rising" +
                " rent prices kept her down, she ended up as a secretary for a small lumber company" +
                " and is very unhappy, not being able to own the means of your own production will do that to a person.";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
        }
        else
        {
            message = "Avril was soon overcome by student debt, she had no more time to work on what she truly " +
                "loved and soon became burnt out, she spiraled downwards into a depression overcome with shift work.";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
        }

        //unit 8
        if (idle[7])
        {
            message = "When Mary-Bell's library finnally opened up it was " +
                "greeted with apathy, I wonder why in the 21st century reading and furthering your" +
                " education is discouraged? Really makes you think, actually don't thin" +
                "k that isn't what they want";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
        }
        else
        {
            message = "For Mary-Bell when she was trying to recover her shelf it feel" +
                " on her once more, she broke her arm and was slowed in her work, when" +
                " the library finally opened it did not have enough funding to hold " +
                "it's own. Soon later it was demolished and in it's place a mid-tier" +
                " KFC was built.";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
        }

        //unit 7
        if (idle[6])
        {
            message = "Becky's Birthday party was a smashing failure after she noticed" +
                " a singleloose thread on her dress and proceded to smash the cake, he" +
                "r new ferrari, and cuss out her father who organized the event, reall" +
                "y makes you think about how very different the lives of the upper class are to ours.";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
        }
        else
        {
            message = "Becky's Birthday party was a smashing failure after she was " +
                "inturpted while speaking and proceded to smash the cake, her new fe" +
                "rrari, and cuss out her father who organized the event, really make" +
                "s you think about how very different the lives of the upper class are to ours.";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);

        }

        //unit 6
        if (idle[5])
        {
            message = "Carol and Merideth lived a happy life together untill the bi" +
                "tter end, in which they stayed hand in paw until the very last second.";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);

        }
        else
        {
            message = "Carol was unable to make it out there on the streets, after e" +
                "viction she had no where else to go, Merideth ran off in the cold o" +
                "ne night and was never found by Carol. Carol only lasted 2 weeks on" +
                " the street before her encounter with a city bus.";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);

        }

        //unit 5
        if (idle[4])
        {
            message = "Ann worked hard as a single mother to provide for her child w" +
                "ho was still recovering from his syndrome, money has been tight for " +
                "her and as a  family they have had to make a lot of sacrifices in or" +
                "der to afford heathcare, if only there was some way it could be affordable.";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
        }
        else
        {
            message = "Ann's son Mikey's disease did not get better, within a week" +
                " he was with the Queen. Ann could not bear the grief of losing he" +
                "r only child and being left on her own again. She left one night " +
                "in the dark and never returned.";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);

        }

        //unit 4
        if (idle[3])
        {
            message = "Arthur continued his search for Art all the way back to France" +
                ", where upon a streak of good fortune, became the janitor for the lo" +
                "uvre, it doesn't pay well in money but pays fortunes in the views.";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
        }
        else
        {
            message = "Artur continued to try and find the beauty in this cruel world" +
                ", but he was consumed by modernization and urban enviornments. He so" +
                "on gave up on his search for art and convinced himself that true bea" +
                "uty, could never be real.";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
        }

        //unit 3
        if (idle[2])
        {
            message = "Clayton soon succeeded in his research and created a serum th" +
                "at would turn any person into an antropomorpic animal, his original" +
                " intention was to make humans more capable and allow certain profes" +
                "sions new abilitys. Yet his creation was adapted by the ever weathy" +
                " furry comunity so that they could become their fursonas, and the w" +
                "orld has never been the same.";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);

        }
        else
        {
            message = "After you called the police on Clayton, they arrived in full fo" +
                "rce and with no mercy. Clayton was not only removed from the complex b" +
                "ut from the planet. Such a shame, he was such a wonderful mind and his" +
                " research was only 2 days away from completion";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);

        }

        //unit 2
        if (idle[1])
        {
            message = "Vlad was severly offended by your remarks about his status as a" +
                " human, little did you know that he was the director of the local cha" +
                "pter of the Romanian Representation Union, the Union filed a lawsuit " +
                "against you for discrimination and now you are battling through the court system.";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);

        }
        else
        {
            message = "Vlad was in fact, not a Vampire or a Zombie, just a Romanian man, he " +
                "now strongly beilves that you are delusional, so he soon switched apartmen" +
                "ts to a into more Romanian-Friendly area.";
            player.GetComponent<PlayerController>().showUI(message, names[0]);
            yield return new WaitWhile(() => PlayerController.isPrinting == true);

        }

        //karl's quick monologue
        message = "As for me, I am just the reincarnated spirt of the late, great Karl Marx. Alas my business " +
            "here is not done and you will certainly hear from me again. But after all this you made " +
            "$ " + PlayerController.balance + ", I hope it was worth it, and i hope you try to be " +
            "a better person in the future.";
        player.GetComponent<PlayerController>().showUI(message, names[0]);
        yield return new WaitWhile(() => PlayerController.isPrinting == true);
        //end

    }

    IEnumerator checkIfDone()
    {
        if(PlayerController.isPrinting)
        {
            yield return new WaitWhile(() => PlayerController.isPrinting == true);
        }
        bool done = true;
        for (int i = 0; i < interacted.Length; i++)
        {
            if(!interacted[i]) //havent been to room
            {
                done = false; //cant be done
            }
            
        }

        if(done) //all rooms are done!
        {
            
            StopAllCoroutines();
            StartCoroutine(ending());
        }
    }
}
