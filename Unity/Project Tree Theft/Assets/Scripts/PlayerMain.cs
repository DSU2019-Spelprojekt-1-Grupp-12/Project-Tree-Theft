using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    #region Components

    SpriteRenderer spriteRendererComponent;
    Rigidbody2D rigidBody;
    #endregion

    #region Variables
    public int playerNumber;
    public float movementSpeed;

    public Sprite UpSprite;
    public Sprite DownSprite;
    public Sprite LeftSprite;
    public Sprite RightSprite;

    List<TreeMain> Tree = null;
    GameObject attachPoint = null;
    bool operationDone = false;
    Vector2 movementVector = new Vector2(0f, 0f);
    bool attached = false;
    #endregion

    #region Core Functions
    void Start()
    {
        initializePlayerMain();
    }
    void Update()
    {
        checkKeys();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AttachPoint"))
        {
            attachPoint = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AttachPoint"))
        {
            attachPoint = null;
        }
    }
    #endregion

    #region Functions
    void initializePlayerMain()
    {
        spriteRendererComponent = gameObject.GetComponent<SpriteRenderer>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }
    void checkKeys()
    {
        if (playerNumber == 1)
        {
            checkPlayerOneKeys();
        }
        if (playerNumber == 2)
        {
            checkPlayerTwoKeys();
        }
    }
    void checkPlayerOneKeys()
    {
        if (attached == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                movementVector.y += 1;
                spriteRendererComponent.sprite = UpSprite;
            }
            if (Input.GetKey(KeyCode.A))
            {
                movementVector.x += -1;
                spriteRendererComponent.sprite = LeftSprite;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movementVector.y += -1;
                spriteRendererComponent.sprite = DownSprite;
            }
            if (Input.GetKey(KeyCode.D))
            {
                movementVector.x += 1;
                spriteRendererComponent.sprite = RightSprite;
            }

            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                movementVector.y = 0;
            }
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                movementVector.x = 0;
            }

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                spriteRendererComponent.sprite = UpSprite;
            }
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                spriteRendererComponent.sprite = DownSprite;
            }

            rigidBody.velocity = movementVector * movementSpeed;
            movementVector.x = 0;
            movementVector.y = 0;
        }
        else if(attached == true)
        {
            playerOneLogMovement();
        }
        if (Input.GetKeyDown(KeyCode.Space) && attached == false || Input.GetKeyDown(KeyCode.LeftControl) && attached == false) //
        {
            attach();
            operationDone = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && attached == true || Input.GetKeyDown(KeyCode.LeftControl) && attached == true) //
        {
            if (operationDone != true)
            {
                detach();
            }
            
        }
        operationDone = false;
    }
    void playerOneLogMovement() //
    {
        if (Input.GetKey(KeyCode.A))
        {
            attachPoint.GetComponent<AttachPoint>().moveLogHorizontal("right");
        }
        if (Input.GetKey(KeyCode.D))
        {
            attachPoint.GetComponent<AttachPoint>().moveLogHorizontal("left");
        }
    }
    void checkPlayerTwoKeys()
    {
        if (attached == false)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                movementVector.y += 1;
                spriteRendererComponent.sprite = UpSprite;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movementVector.x += -1;
                spriteRendererComponent.sprite = LeftSprite;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                movementVector.y += -1;
                spriteRendererComponent.sprite = DownSprite;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                movementVector.x += 1;
                spriteRendererComponent.sprite = RightSprite;
            }

            if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
            {
                movementVector.y = 0;
            }
            if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                movementVector.x = 0;
            }

            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                spriteRendererComponent.sprite = UpSprite;
            }
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                spriteRendererComponent.sprite = DownSprite;
            }
            rigidBody.velocity = movementVector * movementSpeed;
            movementVector.x = 0;
            movementVector.y = 0;
        }
        else if (attached == true)
        {
            playerTwoLogMovement();
        }
        if (Input.GetKeyDown(KeyCode.Keypad0) && attached == false || Input.GetKeyDown(KeyCode.RightControl) && attached == false) //
        {
            attach();
            operationDone = true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad0) && attached == true || Input.GetKeyDown(KeyCode.RightControl) && attached == true) //
        {
            if (operationDone != true)
            {
                detach();
            } 
        }
        operationDone = false;
    }
    void playerTwoLogMovement() //
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            attachPoint.GetComponent<AttachPoint>().moveLogVertical("up");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            attachPoint.GetComponent<AttachPoint>().moveLogVertical("down");
        }
    }

    void attack()
    {

    }

    void attach() //
    {
        attachPoint.GetComponent<AttachPoint>().attachToPlayer(gameObject);
        attached = true;
        Debug.Log(attached);
    }
    void detach()
    {
        attachPoint.GetComponent<AttachPoint>().detachFromPlayer();
        attached = false;
        Debug.Log(attached);
    }
}

#endregion