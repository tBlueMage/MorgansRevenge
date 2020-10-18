using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERANIMATION_SCRIPT : MonoBehaviour
{
    Animator myAnimator;
    PLAYER_SCRIPT myPlayerMovement;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myPlayerMovement = GetComponent<PLAYER_SCRIPT>();
    }

    // Update is called once per frame
    void Update()
    {
            //walk
        if (myPlayerMovement.isMoving && !myPlayerMovement.isGrounded && HighSword.HighSlash.highslash == false)
        {    
          
            myAnimator.SetBool("Walk", true);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("HighSlash", false);
            myAnimator.SetBool("LowSlash", false);
            myAnimator.SetBool("Death", false);

        }
       else if (myPlayerMovement.isMoving && !myPlayerMovement.isGrounded && HighSword.HighSlash.highslash == true)
        {

            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("HighSlash", true);
            myAnimator.SetBool("LowSlash", false);
            myAnimator.SetBool("Death", false);

        }
        else if (!myPlayerMovement.isMoving && !myPlayerMovement.isGrounded && HighSword.HighSlash.highslash == false)
        {

            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("HighSlash", false);
            myAnimator.SetBool("LowSlash", false);
            myAnimator.SetBool("Death", false);

        }
        else if (!myPlayerMovement.isMoving && !myPlayerMovement.isGrounded && HighSword.HighSlash.highslash == true)
        {

            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("HighSlash", true);
            myAnimator.SetBool("LowSlash", false);
            myAnimator.SetBool("Death", false);

        }
        else if (myPlayerMovement.isMoving && myPlayerMovement.isGrounded&& Sword.midslash.slash == false && LowSword.lowslash.slash == false)
        {
            myAnimator.SetBool("Walk", true);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("LowSlash", false);
            myAnimator.SetBool("HighSlash", false);
            myAnimator.SetBool("Death", false);

        }

        else if (myPlayerMovement.isMoving && myPlayerMovement.isGrounded && Sword.midslash.slash == true && LowSword.lowslash.slash ==false)
        {
            myAnimator.SetBool("Walk", true);
            myAnimator.SetBool("Slash", true);
            myAnimator.SetBool("LowSlash", false);
            myAnimator.SetBool("HighSlash", false);
            myAnimator.SetBool("Death", false);

        }


        else if (!myPlayerMovement.isMoving && myPlayerMovement.isGrounded && Sword.midslash.slash == true && LowSword.lowslash.slash == false)
        {
            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", true);
            myAnimator.SetBool("LowSlash", false);
            myAnimator.SetBool("HighSlash", false);
            myAnimator.SetBool("Death", false);

        }
        else if (!myPlayerMovement.isMoving && myPlayerMovement.isGrounded && Sword.midslash.slash == false && LowSword.lowslash.slash == true)
        {
            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("LowSlash", true);
            myAnimator.SetBool("HighSlash", false);
            myAnimator.SetBool("Death", false);

        }
        else if(PLAYER_SCRIPT.character.death ==true)
        {
            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("LowSlash", false);
            myAnimator.SetBool("HighSlash", false);
            myAnimator.SetBool("Death", true);

        }
        //walk end
        else
        {
            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("LowSlash", false);
            myAnimator.SetBool("HighSlash", false);
            myAnimator.SetBool("Death", false);

        }
    }
}
