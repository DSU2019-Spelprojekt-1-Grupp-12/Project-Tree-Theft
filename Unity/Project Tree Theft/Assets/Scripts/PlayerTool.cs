using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTool : MonoBehaviour
{
    [Tooltip("Add Parent here")]
    [SerializeField] PlayerMain player;    
    [Header("Stats")]
    public int damage = 2;
    public int price = 20;
    

    private Vector3 standardPosition = new Vector3(0, 0, 0);
    private Vector3 upPosition = new Vector3(0, 0.7f, 0);
    private Vector3 rightPosition = new Vector3(0.7f, 0);
    private Vector3 downPosition = new Vector3(0, -0.7f, 0);
    private Vector3 leftPosition = new Vector3(-0.7f, 0, 0);

    private Vector3 upRotationVector = new Vector3(0, 0, 0);
    private Vector3 rightRotationVector = new Vector3(0, 0, 270f);
    private Vector3 downRotationVector = new Vector3(0, 0, 180f);
    private Vector3 leftRotationVector = new Vector3(0, 0, 90f);

    private Quaternion upRotation;
    private Quaternion rightRotation;
    private Quaternion downRotation;
    private Quaternion leftRotation;

    float cooldownTimer = 0;

    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        InitQuaternions();
    }

    private void InitQuaternions() {
        upRotation = Quaternion.Euler(upRotationVector);
        rightRotation = Quaternion.Euler(rightRotationVector);
        downRotation = Quaternion.Euler(downRotationVector);
        leftRotation = Quaternion.Euler(leftRotationVector);
    }

    // Update is called once per frame
    void Update()
    {
        var direction = GetDirection();
        CheckSprite(direction);
    }

    private void CheckSprite(int direction) {
        if (cooldownTimer < Time.time)
        {
            switch (direction)
            {
                case 0:
                    transform.localRotation = upRotation;
                    transform.localPosition = standardPosition;
                    break;
                case 1:
                    transform.localRotation = rightRotation;
                    transform.localPosition = standardPosition;
                    break;
                case 2:
                    transform.localRotation = downRotation;
                    transform.localPosition = standardPosition;
                    break;
                case 3:
                    transform.localRotation = leftRotation;
                    transform.localPosition = standardPosition;
                    break;
            }
        }
    }

    public int GetDirection(){ return player.GetDirectionSprite(); }

    [HideInInspector] public void ChopEvent(int playerNumber) {
        if(playerNumber == 1) {
            SetPosition(GetDirection());
        }
            
        if (playerNumber == 2){
            SetPosition(GetDirection());
        }            
    }

    [HideInInspector] public void ChopEvent(){
        SetPosition(-1);
    }

    public void SetPosition(int direction){
        PositionSwitch(direction);
    }


    private void PositionSwitch(int direction){
        switch (direction)
        {
            case 0:
                transform.localPosition = upPosition;
                break;
            case 1:
                transform.localPosition = rightPosition;
                break;
            case 2:
                transform.localPosition = downPosition;
                break;
            case 3:
                transform.localPosition = leftPosition;
                break;
            default:
                transform.localPosition = standardPosition;                
                break;
        }
        cooldownTimer = Time.time + 0.5f;
    }

    public int GetDamage(){ return damage; }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Tree")){            
            TreeMain tree = other.gameObject.GetComponent<TreeBody>().GetTreeMain();
            tree.SetDamage(GetDamage());
        }
    }
}
