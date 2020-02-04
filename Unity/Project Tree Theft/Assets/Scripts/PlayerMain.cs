using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionIndex{
    up,
    right,
    down,
    left
}

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

    public PlayerTool tool;

    List<TreeMain> Tree = null;
    GameObject attachPoint = null;
    bool operationDone = false;
    Vector2 movementVector = new Vector2(0f, 0f);
    bool attached = false;

    private int directionIndex;
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
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AttachPoint") && attached == false)
        {
            attachPoint = null;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AttachPoint") && attached == false)
        {
            attachPoint = other.gameObject;
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
        var deltaXplayer1 = Input.GetAxis("Player1 Horizontal");
        var deltaYplayer1 = Input.GetAxis("Player1 Vertical");

        var deltaXplayer2 = Input.GetAxis("Player2 Horizontal");
        var deltaYplayer2 = Input.GetAxis("Player2 Vertical");

        if (playerNumber == 1)
        {
            checkPlayerOneKeys(deltaXplayer1, deltaYplayer1, tool);            
        }
        if (playerNumber == 2)
        {
            checkPlayerTwoKeys(deltaXplayer2, deltaYplayer2, tool);
        }
    }
    void checkPlayerOneKeys(float deltaX, float deltaY, PlayerTool tool)
    {
        if (attached == false)
        {                    
            if(deltaX > 0 || deltaX < 0)
            {
                movementVector.x = deltaX;
                if (deltaX < 0)
                    SetDirectionSprite(LeftSprite, (int)DirectionIndex.left);
                else
                    SetDirectionSprite(RightSprite, (int)DirectionIndex.right);
            }

            if(deltaY > 0 || deltaY < 0)
            {
                movementVector.y = deltaY;
                if (deltaY < 0)
                    SetDirectionSprite(DownSprite, (int)DirectionIndex.down);
                else
                    SetDirectionSprite(UpSprite, (int)DirectionIndex.up);
            }

            if (deltaY > 0 && deltaX < 0 || deltaY > 0 && deltaX > 0)
            {
                spriteRendererComponent.sprite = UpSprite;
            }
            if (deltaY < 0 && deltaX < 0 || deltaY < 0 && deltaX > 0)
            {
                spriteRendererComponent.sprite = DownSprite;
            }

            rigidBody.velocity = movementVector * movementSpeed;
            movementVector.x = 0;
            movementVector.y = 0;
        }
        else if(attached == true)
        {
            playerOneLogMovement(deltaX);
        }


        if(!attached && Input.GetButtonDown("Player1 Attach")){
            attach();
            operationDone = true;
        }

        if(attached && Input.GetButtonDown("Player1 Attach")){
            if (operationDone != true)            
                detach();            
        }

        if (!attached && Input.GetButtonDown("Player1 Chop"))
            tool.ChopEvent(playerNumber);
        operationDone = false;
    }
    void playerOneLogMovement(float deltaX) 
    {
        if (deltaX > 0)
            attachPoint.GetComponent<AttachPoint>().moveLogHorizontal("right");
        else if (deltaX < 0)
            attachPoint.GetComponent<AttachPoint>().moveLogHorizontal("left");

    }
    void checkPlayerTwoKeys(float deltaX, float deltaY, PlayerTool tool)
    {
        if (attached == false)
        {
            if (deltaX > 0 || deltaX < 0)
            {
                movementVector.x = deltaX;
                if (deltaX < 0)
                    SetDirectionSprite(LeftSprite, (int)DirectionIndex.left);
                else
                    SetDirectionSprite(RightSprite,(int)DirectionIndex.right);
            }

            if (deltaY > 0 || deltaY < 0)
            {
                movementVector.y = deltaY;
                if (deltaY < 0)
                    SetDirectionSprite(DownSprite, (int)DirectionIndex.down);
                else
                    SetDirectionSprite(UpSprite, (int)DirectionIndex.up);
            }

            if (deltaY > 0 && deltaX < 0 || deltaY > 0 && deltaX > 0)
            {
                spriteRendererComponent.sprite = UpSprite;
            }
            if (deltaY < 0 && deltaX < 0 || deltaY < 0 && deltaX > 0)
            {
                spriteRendererComponent.sprite = DownSprite;
            }
            rigidBody.velocity = movementVector * movementSpeed;
            movementVector.x = 0;
            movementVector.y = 0;
        }
        else if (attached == true)
        {
            playerTwoLogMovement(deltaY);
        }
        if (!attached && Input.GetButtonDown("Player2 Attach"))
        {
            attach();
            operationDone = true;
        }

        if (attached && Input.GetButtonDown("Player2 Attach"))
        {
            if (operationDone != true)
                detach();
        }
        if (!attached && Input.GetButton("Player2 Chop"))
            tool.ChopEvent(playerNumber);
        else { }
        operationDone = false;
    }
    void playerTwoLogMovement(float deltaY) //
    {
        if (deltaY > 0)
            attachPoint.GetComponent<AttachPoint>().moveLogVertical("up");
        else if (deltaY < 0)
            attachPoint.GetComponent<AttachPoint>().moveLogVertical("down");
    }

    void attack()
    {

    }

    void attach() //
    {
        if (attachPoint != null)
        {
            attachPoint.GetComponent<AttachPoint>().attachToPlayer(gameObject);
            attached = true;
            Debug.Log(attached);
        }
    }
    void detach()
    {
        attachPoint.GetComponent<AttachPoint>().detachFromPlayer();
        attached = false;
        Debug.Log(attached);
    }

    private void SetDirectionSprite(Sprite directionSprite, int directionIndex){
        spriteRendererComponent.sprite = directionSprite;
        this.directionIndex = directionIndex;
    }

    [HideInInspector] public int GetDirectionSprite(){
        return directionIndex;
    }

}

#endregion