using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PLAYER_SCRIPT : MonoBehaviour
{
    public Slider Hp;

    public CHASEN_SCRIPT level;
    public int fireunlock;
    Rigidbody2D myBody;
    KNCKBCK_SCRIPT struck;
   public Text coinvalue;
    Transform myTrans;
    public BoxCollider2D myBox;
    SpriteRenderer mySprite;
    [SerializeField] public LayerMask groundLayer;
    public int coin;
    
    public float invulnertimer;
    public float invulnertarget;
    public bool invicibility;
    public bool death;
    public float deathtimer;
    public float deathtimertarget;
    public bool isGrounded = false;
    public bool isMoving = false;
    public bool isLeft = true;
    public float jumpforce;
    public float speedforce;
    public float bonusspeed;
    // Start is called before the first frame update
   
    void Start()
    {
        coin = PlayerPrefs.GetInt("newcoin");
        fireunlock = PlayerPrefs.GetInt("unlocked");
        deathtimertarget = 5.0f;
        invulnertarget = 0.0f;
        invulnertimer = 0.0f;
        //how the sprites transfer
        myBody = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        myTrans = GetComponent<Transform>();
        struck = GetComponent<KNCKBCK_SCRIPT>();

    }

    // Update is called once per frame
    void Update()
    {
        coinvalue.text = coin.ToString();

   
        checkForGround();
        handleMovement();

        Dead();
        invulerability(); 
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
    void invulerability()
    {
        if(invicibility == true)
        {

            invulnertimer -= Time.deltaTime;
            mySprite.color = new Color32(255, 0, 0, 255);

            Debug.Log(invulnertimer);
            if (invulnertimer <= invulnertarget)
            {
                mySprite.color = new Color32(255, 255, 255, 255);

                invicibility = false;
                Debug.Log("invicibilitygone");
                invulnertimer = 0.0f;

            }
        }

     

    }
    void Dead()
    {
        if (myBody.position.y < -20)
        {
            death = true;

        }

        if (Hp.value <= 0)
        {

            death = true;

          
        }

        if (death == true)
        {
            deathtimer += Time.deltaTime;
        }

        if (deathtimer >= deathtimertarget)
        {
            PlayerPrefs.SetInt("newcoin", coin);
            PlayerPrefs.SetInt("unlocked", fireunlock);

            level.changeScene(4);
        }
    }

   public void Cost()
    {
      
       fireunlock = 1;
            coin -= 5;

        PlayerPrefs.SetInt("newcoin", coin);
        PlayerPrefs.SetInt("unlocked", fireunlock);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Win")
        {
            PlayerPrefs.SetInt("newcoin", coin);
            PlayerPrefs.SetInt("unlocked", fireunlock);

            level.changeScene(4);
        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            coin++;

            coinvalue.text = coin+ "$";
        }
        else if (collision.gameObject.CompareTag("BSnack"))
        {
            Hp.value += 2;


        }
        else if (collision.gameObject.CompareTag("Mvial"))
        {
            MP_SCRIPT.mana.Mp.value += 2;


        }
        else if (collision.gameObject.CompareTag("Cbag"))
        {
            coin+= 5;

            coinvalue.text = coin + "$";

        }
        else if (collision.gameObject.CompareTag("Hazard"))
        {

            var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();
            Hp.value -= damage.Damage;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            if (invicibility == false)
            {
                struck.knockBack = true;


                var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();
                Hp.value -= damage.Damage;
                invicibility = true;
                invulnertimer = 3.0f;



            }


        }


    }
}
