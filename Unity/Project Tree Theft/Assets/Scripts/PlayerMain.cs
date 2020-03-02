using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

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
    [SerializeField] private int playerNumber;
    [SerializeField] private float movementSpeed;

    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    public PlayerTool tool;

    List<TreeMain> trees = null;
    GameObject attachPoint = null;
    bool operationDone = false;
    Vector2 movementVector = new Vector2(0f, 0f);
    bool attached = false;

    private int directionIndex;
    #endregion



    #region Core Functions
    void Start()
    {
        InitializePlayerMain();
    }
    void Update()
    {
        //CooldownHandler();
        CheckKeys();
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

    public void SetPlayerNumber(int playerNumber) { this.playerNumber = playerNumber; }
    #endregion

    #region Functions
    
    public void SetMovementSpeed(float movementSpeed) { this.movementSpeed = movementSpeed; }
    public float GetMovementSpeed() { return movementSpeed; }
    [HideInInspector] public int GetPlayerNumber() { return playerNumber; }

    void InitializePlayerMain()
    {
        spriteRendererComponent = gameObject.GetComponent<SpriteRenderer>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }
    void CheckKeys()
    {
        //var deltaXplayer1 = Input.GetAxis("Player1 Horizontal");
        //var deltaYplayer1 = Input.GetAxis("Player1 Vertical");

        //var deltaXplayer2 = Input.GetAxis("Player2 Horizontal");
        //var deltaYplayer2 = Input.GetAxis("Player2 Vertical");

        var deltaXplayer1 = _movementVectorP1.x;
        var deltaXplayer2 = _movementVectorP2.x;
        var deltaYplayer1 = _movementVectorP1.y;
        var deltaYplayer2 = _movementVectorP2.y;

        if (playerNumber == 1)
        {
            CheckPlayerOneKeys(deltaXplayer1, deltaYplayer1, tool);            
        }
        if (playerNumber == 2)
        {
            CheckPlayerTwoKeys(deltaXplayer2, deltaYplayer2, tool);
        }
    }
    void CheckPlayerOneKeys(float deltaX, float deltaY, PlayerTool tool)
    {
        if (attached == false)
        {                    
            if(deltaX > 0 || deltaX < 0)
            {
                movementVector.x = deltaX;
                if (deltaX < 0)
                    SetDirectionSprite(leftSprite, (int)DirectionIndex.left);
                else
                    SetDirectionSprite(rightSprite, (int)DirectionIndex.right);
            }

            if(deltaY > 0 || deltaY < 0)
            {
                movementVector.y = deltaY;
                if (deltaY < 0)
                    SetDirectionSprite(downSprite, (int)DirectionIndex.down);
                else
                    SetDirectionSprite(upSprite, (int)DirectionIndex.up);
            }

            if (deltaY > 0 && deltaX < 0 || deltaY > 0 && deltaX > 0)
            {
                spriteRendererComponent.sprite = upSprite;
            }
            if (deltaY < 0 && deltaX < 0 || deltaY < 0 && deltaX > 0)
            {
                spriteRendererComponent.sprite = downSprite;
            }

            rigidBody.velocity = movementVector * movementSpeed;
            movementVector.x = 0;
            movementVector.y = 0;
            if (GetDirectionSprite() == 2 && rigidBody.velocity.magnitude > 0)
            {
                SendMessage("toggleWalkingDown", true);
            }
            else
            {
                SendMessage("toggleWalkingDown", false);
            }
        }
        else if(attached == true)
        {
            PlayerOneLogMovement(deltaX);
        }


        if(!attached && Input.GetButtonDown("Player1 Attach")){
            Attach();
            operationDone = true;
        }

        if(attached && Input.GetButtonDown("Player1 Attach")){
            if (operationDone != true)            
                Detach();            
        }

        if (!attached && Input.GetButton("Player1 Chop"))
            tool.ChopEvent(playerNumber);
        operationDone = false;
    }
    void PlayerOneLogMovement(float deltaX) 
    {
        if (deltaX > 0)
            attachPoint.GetComponent<AttachPoint>().moveLogHorizontal("right");
        else if (deltaX < 0)
            attachPoint.GetComponent<AttachPoint>().moveLogHorizontal("left");

    }
    void CheckPlayerTwoKeys(float deltaX, float deltaY, PlayerTool tool)
    {
        if (attached == false)
        {
            if (deltaX > 0 || deltaX < 0)
            {
                movementVector.x = deltaX;
                if (deltaX < 0)
                    SetDirectionSprite(leftSprite, (int)DirectionIndex.left);
                else
                    SetDirectionSprite(rightSprite,(int)DirectionIndex.right);
            }

            if (deltaY > 0 || deltaY < 0)
            {
                movementVector.y = deltaY;
                if (deltaY < 0)
                    SetDirectionSprite(downSprite, (int)DirectionIndex.down);
                else
                    SetDirectionSprite(upSprite, (int)DirectionIndex.up);
            }

            if (deltaY > 0 && deltaX < 0 || deltaY > 0 && deltaX > 0)
            {
                spriteRendererComponent.sprite = upSprite;
            }
            if (deltaY < 0 && deltaX < 0 || deltaY < 0 && deltaX > 0)
            {
                spriteRendererComponent.sprite = downSprite;
            }
            rigidBody.velocity = movementVector * movementSpeed;
            movementVector.x = 0;
            movementVector.y = 0;
            if (GetDirectionSprite() == 2 && rigidBody.velocity.magnitude > 0)
            {
                SendMessage("toggleWalkingDown", true);
            }
            else
            {
                SendMessage("toggleWalkingDown", false);
            }
        }
        else if (attached == true)
        {
            PlayerTwoLogMovement(deltaY);
        }
        if (!attached && Input.GetButtonDown("Player2 Attach"))
        {
            Attach();
            operationDone = true;
        }

        if (attached && Input.GetButtonDown("Player2 Attach"))
        {
            if (operationDone != true)
                Detach();
        }
        if (!attached && Input.GetButton("Player2 Chop"))
            tool.ChopEvent(playerNumber);
        else { }
        operationDone = false;
    }
    void PlayerTwoLogMovement(float deltaY) //
    {
        if (deltaY > 0)
            attachPoint.GetComponent<AttachPoint>().moveLogVertical("up");
        else if (deltaY < 0)
            attachPoint.GetComponent<AttachPoint>().moveLogVertical("down");
    }

    void Attack()
    {

    }

    void Attach() //
    {
        if (attachPoint != null)
        {
            attachPoint.GetComponent<AttachPoint>().attachToPlayer(gameObject);
            attached = true;
            Debug.Log(attached);
        }
    }
    void Detach()
    {
        attachPoint.GetComponent<AttachPoint>().detachFromPlayer();
        attached = false;
        Debug.Log(attached);
    }

    private void SetDirectionSprite(Sprite directionSprite, int directionIndex){
        spriteRendererComponent.sprite = directionSprite;
        this.directionIndex = directionIndex;
    }

    public void SetDirectionSprite(int directionIndex){
        switch (directionIndex)
        {
            case 0:
                spriteRendererComponent.sprite = upSprite;
                break;
            case 1:
                spriteRendererComponent.sprite = rightSprite;
                break;
            case 2:
                spriteRendererComponent.sprite = downSprite;
                break;
            case 3:
                spriteRendererComponent.sprite = leftSprite;
                break;
        }
        this.directionIndex = directionIndex;
    }

    [HideInInspector] public int GetDirectionSprite(){
        return directionIndex;
    }
    #endregion

    #region New Input System

    

    PlayerControls _player1Controls;
    PlayerControls _player2Controls;

    private Vector2 _movementVectorP1 = new Vector2(0f, 0f);
    private Vector2 _movementVectorP2 = new Vector2(0f, 0f);

    bool isCharging = false;

    

    void Awake(){
        _player1Controls = new PlayerControls();
        _player2Controls = new PlayerControls();
        _player1Controls.Player1.Move.performed += ctx => _movementVectorP1 = ctx.ReadValue<Vector2>();
        _player2Controls.Player2.Move.performed += ctx => _movementVectorP2 = ctx.ReadValue<Vector2>();        
    }

    private void Attach_P1(InputAction.CallbackContext obj){
        if (playerNumber != 1) return;
        if (!attached){
            Attach();
            operationDone = true;
        }if (attached){
            if (operationDone != true)
                Detach();            
        }        
    }

    private void Attach_P2(InputAction.CallbackContext obj){
        if (playerNumber != 2) return;
        if (!attached){
            Attach();
            operationDone = true;
        }
        if (attached){
            if (operationDone != true)
                Detach();            
        }
    }

    private void Chop_P1(InputAction.CallbackContext obj){
        if (!attached && playerNumber == 1)
        {
            tool.ChopEvent(playerNumber);
            SendMessage("playCutSound", 1);
        }
    }

    private void Chop_P2(InputAction.CallbackContext obj){
        if(!attached && playerNumber == 2)
        {
            tool.ChopEvent(playerNumber);
            SendMessage("playCutSound", 1);
        }

    }

    private void Charge_P1(InputAction.CallbackContext obj){
        if(!attached && playerNumber == 1)
        {
            tool.ChopCharge(playerNumber);
            SendMessage("playChargeSound");
        }
    }
    private void Charge_P2(InputAction.CallbackContext obj){
        if (!attached && playerNumber == 2)
        {
            tool.ChopCharge(playerNumber);
            SendMessage("playChargeSound");
        }
    }

    private void RotateLog_P1(InputAction.CallbackContext obj){
        if (attached && playerNumber == 1){
            attachPoint.GetComponentInParent<StockMain>().RotateLog(playerNumber);
            SendMessage("playRotationSound");
        }
    }
    private void RotateLog_P2(InputAction.CallbackContext obj){
        if (attached && playerNumber == 2){
            attachPoint.GetComponentInParent<StockMain>().RotateLog(playerNumber);
            SendMessage("playRotationSound");
        }
    }

    private void OnEnable(){
        _player1Controls.Enable();
        _player2Controls.Enable();

        _player1Controls.Player1.Charge.performed += Charge_P1;
        _player1Controls.Player1.Chop.performed += Chop_P1;
        _player2Controls.Player2.Charge.performed += Charge_P2;
        _player2Controls.Player2.Chop.performed += Chop_P2;

        _player1Controls.Player1.Attach.performed += Attach_P1;
        _player2Controls.Player2.Attach.performed += Attach_P2;

        _player1Controls.Player1.Rotate.performed += RotateLog_P1;
        _player2Controls.Player2.Rotate.performed += RotateLog_P2;
    }    
        
    private void OnDisable(){
        _player1Controls.Player1.Rotate.performed -= RotateLog_P1;
        _player2Controls.Player2.Rotate.performed -= RotateLog_P2;

        _player1Controls.Player1.Attach.performed -= Attach_P1;
        _player2Controls.Player2.Attach.performed -= Attach_P2;

        _player1Controls.Player1.Charge.performed -= Charge_P1;
        _player1Controls.Player1.Chop.performed -= Chop_P1;
        _player2Controls.Player2.Charge.performed -= Charge_P2;
        _player2Controls.Player2.Chop.performed -= Chop_P2;

        _player1Controls.Disable();
        _player2Controls.Disable();        
    }


    //private PlayerControls _playerControlsScript;

    //private void Awake(){

    //}

    //private void OnEnable(){
    //    _playerControlsScript.Player1.Chop.performed += NewControlChop;
    //}
    //private void OnDisable(){
    //    _playerControlsScript.Player1.Chop.performed -= NewControlChop;
    //}

    //private void NewControlChop(InputAction.CallbackContext context){
    //    Debug.Log("Chop Chop!");
    //}


    //private void InitNewControlTest(){
    //    PlayerControls player1Controls = new PlayerControls();
    //    player1Controls.Player1.Chop.performed +=  => 
    //}


    #endregion
}

