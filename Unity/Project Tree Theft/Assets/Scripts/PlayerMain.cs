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
    Vector2 movementVector = new Vector2(0f,0f);
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
    void
    #endregion

    #region Functions
    int initializePlayerMain()
    {
        spriteRendererComponent = gameObject.GetComponent<SpriteRenderer>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        return 0;
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
    void checkPlayerTwoKeys()
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

    void attack()
    {

    }
}

    #endregion