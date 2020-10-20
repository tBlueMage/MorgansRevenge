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
          
            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("HighSlash", false);
            myAnimator.SetBool("LowSlash", false);
            myAnimator.SetBool("Death", false);
            myAnimator.SetBool("Jump", true);
            myAnimator.SetBool("Fireball", false);

        }
       else if (myPlayerMovement.isMoving && !myPlayerMovement.isGrounded && HighSword.HighSlash.highslash == true)
        {

            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("HighSlash", true);
            myAnimator.SetBool("LowSlash", false);
            myAnimator.SetBool("Death", false);
            myAnimator.SetBool("Fireball", false);
            myAnimator.SetBool("Jump", true);

        }
        else if (!myPlayerMovement.isMoving && !myPlayerMovement.isGrounded && HighSword.HighSlash.highslash == false && Fireball.fire.shoot == false)
        {

            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("HighSlash", false);
            myAnimator.SetBool("LowSlash", false);
            myAnimator.SetBool("Death", false);
            myAnimator.SetBool("Fireball", false);
            myAnimator.SetBool("Jump", true);

        }
        else if (!myPlayerMovement.isMoving && !myPlayerMovement.isGrounded && HighSword.HighSlash.highslash == false && Fireball.fire.shoot == true)
        {

            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("HighSlash", false);
            myAnimator.SetBool("LowSlash", false);
            myAnimator.SetBool("Death", false);
            myAnimator.SetBool("Fireball", true);
            myAnimator.SetBool("Jump", false);

        }


        else if (!myPlayerMovement.isMoving && !myPlayerMovement.isGrounded && HighSword.HighSlash.highslash == true)
        {

            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("HighSlash", true);
            myAnimator.SetBool("LowSlash", false);
            myAnimator.SetBool("Death", false);
            myAnimator.SetBool("Fireball", false);
            myAnimator.SetBool("Jump", false);


        }
        else if (!myPlayerMovement.isMoving && myPlayerMovement.isGrounded && HighSword.HighSlash.highslash == false && Fireball.fire.shoot == true)
        {

            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("HighSlash", false);
            myAnimator.SetBool("LowSlash", false);
            myAnimator.SetBool("Death", false);
            myAnimator.SetBool("Fireball", true);
            myAnimator.SetBool("Jump", false);

        }
        else if (myPlayerMovement.isMoving && myPlayerMovement.isGrounded&& Sword.midslash.slash == false && LowSword.lowslash.slash == false)
        {
            myAnimator.SetBool("Walk", true);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("LowSlash", false);
            myAnimator.SetBool("HighSlash", false);
            myAnimator.SetBool("Death", false);
            myAnimator.SetBool("Fireball", false);
            myAnimator.SetBool("Jump", false);

        }

      


        else if (!myPlayerMovement.isMoving && myPlayerMovement.isGrounded && Sword.midslash.slash == true && LowSword.lowslash.slash == false)
        {
            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", true);
            myAnimator.SetBool("LowSlash", false);
            myAnimator.SetBool("HighSlash", false);
            myAnimator.SetBool("Death", false);
            myAnimator.SetBool("Fireball", false);
            myAnimator.SetBool("Jump", false);

        }
        else if (!myPlayerMovement.isMoving && myPlayerMovement.isGrounded && Sword.midslash.slash == false && LowSword.lowslash.slash == true)
        {
            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("LowSlash", true);
            myAnimator.SetBool("HighSlash", false);
            myAnimator.SetBool("Death", false);
            myAnimator.SetBool("Fireball", false);
            myAnimator.SetBool("Jump", false);

        }
        else if(myPlayerMovement.death==true)
        {
            myAnimator.SetBool("Jump", false);

            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("LowSlash", false);
            myAnimator.SetBool("HighSlash", false);
            myAnimator.SetBool("Death", true);
            myAnimator.SetBool("Fireball", false);

        }
        //walk end
        else
        {
            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("LowSlash", false);
            myAnimator.SetBool("HighSlash", false);
            myAnimator.SetBool("Death", false);
            myAnimator.SetBool("Fireball", false);
            myAnimator.SetBool("Jump", false);

        }
    }
}
