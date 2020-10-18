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
        if (myPlayerMovement.isMoving && !myPlayerMovement.isGrounded)
        {    
          
            myAnimator.SetBool("Walk", true);
            myAnimator.SetBool("Slash", false);

            myAnimator.SetBool("LowSlash", false);

        }

        else if (myPlayerMovement.isMoving && myPlayerMovement.isGrounded&& Sword.midslash.slash == false && LowSword.lowslash.slash == false)
        {
            myAnimator.SetBool("Walk", true);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("LowSlash", false);

        }

        else if (myPlayerMovement.isMoving && myPlayerMovement.isGrounded && Sword.midslash.slash == true && LowSword.lowslash.slash ==false)
        {
            myAnimator.SetBool("Walk", true);
            myAnimator.SetBool("Slash", true);
            myAnimator.SetBool("LowSlash", false);

        }


        else if (!myPlayerMovement.isMoving && myPlayerMovement.isGrounded && Sword.midslash.slash == true && LowSword.lowslash.slash == false)
        {
            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", true);
            myAnimator.SetBool("LowSlash", false);

        }
        else if (!myPlayerMovement.isMoving && myPlayerMovement.isGrounded && Sword.midslash.slash == false && LowSword.lowslash.slash == true)
        {
            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("LowSlash", true);

        }
        //walk end
        else
        {
            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slash", false);
            myAnimator.SetBool("LowSlash", false);

        }
    }
}
