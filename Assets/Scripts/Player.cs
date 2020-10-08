using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public HP hp;

    //movement
    Rigidbody2D myBody;

    Transform myTrans;
    CapsuleCollider2D myBox;
    SpriteRenderer mySprite;
    [SerializeField] public LayerMask groundLayer;
    public float timer = 5.0f;
    public bool isGrounded = false;
    public bool isMoving = false;
    public bool isLeft = true;
    public float jumpforce;
    public float speedforce;
    public float bonusspeed;
    // Start is called before the first frame update
    void Start()
    {
        
        //how the sprites transfer
        myBody = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        myTrans = GetComponent<Transform>();
        myBox = GetComponent <CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkForGround();
        handleMovement();

        Dead();
     
    }
    //checks if the players on the ground
    void checkForGround()
    {

        RaycastHit2D raycastHit2d = Physics2D.BoxCast(myBox.bounds.center, myBox.bounds.size, 0f, Vector2.down, .1f, groundLayer);

        if (raycastHit2d.collider != null)
        {
            isGrounded = true;
        }

        else
        {

            isGrounded = false;
        }
    }
    //handles the movement
    void handleMovement()

    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            myBody.velocity = new Vector2(+speedforce + bonusspeed, myBody.velocity.y);
            mySprite.flipX = true;
            isMoving = true;
            isLeft = true;

        }
        else
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                myBody.velocity = new Vector2(-speedforce - bonusspeed, myBody.velocity.y);
                mySprite.flipX = false;
                isMoving = true;
                isLeft = false;

            }

            else
            {
                isMoving = false;
                myBody.velocity = new Vector2(0, myBody.velocity.y);


            }
        }

        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpforce);
            isMoving = false;
        }


        if (Input.GetKeyDown(KeyCode.O))
        {
            speedforce = 0;
        }

        if (!Input.GetKey(KeyCode.O))
        {
            speedforce = 10;
        }




    }
    //helps the bonus speed move

    void Dead()
    {
        if (myBody.position.y <-5)
        {
            CHASEN_SCRIPT.level.changeScene(2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Player"|| collision.tag == "Win")
        {
            CHASEN_SCRIPT.level.changeScene(3);
        }
        if (collision.tag == "Player" || collision.tag == "Dog")
        {
            hp.barDisplay -= .2f;
            if (hp.barDisplay < 0f)
            {
                hp.barDisplay = 0f;
                CHASEN_SCRIPT.level.changeScene(2);
            }
        }

    }
}
