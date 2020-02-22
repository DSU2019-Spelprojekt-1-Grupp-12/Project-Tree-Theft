using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    private bool isCharging = false;
    private int chargeLevel = 1;
    private int chargeLevelWhenHit;
    private int minCharge = 1;
    private int maxCharge = 100;
    private int chargeMidConstant;
    private int chargeCounter;
    private bool chargeUp = false;

    [Header("Charge stats")]
    int chargeSweetspotMax = 80;
    int chargeSweetspotMin = 40;
    private int sweetSpot;

    private GameObject mySlider;

    Rigidbody2D myRigidBody;

    private void Awake(){
        SliderBehaviour[] sliders = FindObjectsOfType<SliderBehaviour>();
        for (int n = 0; n < sliders.Length; n++)
            if (sliders[n].GetPlayerNumber() == GetComponentInParent<PlayerMain>().GetPlayerNumber())
                mySlider = sliders[n].gameObject;

        chargeMidConstant = (maxCharge - minCharge) / 2;
        chargeCounter = minCharge-1;
        sweetSpot = chargeSweetspotMin;
    }

    // Start is called before the first frame update
    void Start(){
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
        if (isCharging)
        {
            //Charge bar - ASin(x)+k            
            ChargeUpTool();
        }
        if (!isCharging)
        {
            chargeLevel = minCharge;
            chargeCounter = minCharge - 1;
        }
    }

    private void ChargeUpTool()
    {
        if (!chargeUp && chargeCounter <= minCharge)
        {
            chargeCounter++;
            chargeUp = true;
        }
        else if (chargeUp && chargeCounter < maxCharge)
            chargeCounter++;
        else if (chargeUp && chargeCounter >= maxCharge)
        {
            chargeCounter--;
            chargeUp = false;
        }
        else if (!chargeUp && chargeCounter > minCharge)
            chargeCounter--;
        chargeLevel = chargeCounter;
        chargeLevelWhenHit = chargeLevel;
        //Debug.Log("Charge Level: " + chargeLevel + "\nCharge counter: " + chargeCounter);
    }

    public int GetChargeLevel() { return chargeLevel; }

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

    [HideInInspector] public void ChopCharge(int playerNumber){
        if (!isCharging){
            RandomizeSweetSpot();
        }
        isCharging = true;        
        Debug.Log("Player" + playerNumber + " is Charging");
    }

    [HideInInspector] public void ChopEvent(int playerNumber) {
        isCharging = false;
        if (playerNumber == 1)
        {
            SetPosition(GetDirection());
            Debug.Log("P1: CHOP!!");
        }
        if (playerNumber == 2)
        {
            SetPosition(GetDirection());
            Debug.Log("P2: CHOP!!");
        }
        Debug.Log("Player" + playerNumber + ": CHOP!!");
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
            var SweetSpotMax = GetSweetSpot() + 20;
            var getCharge = mySlider.GetComponent<SliderBehaviour>().GetCharge();
            TreeMain tree = other.gameObject.GetComponent<TreeBody>().GetTreeMain();
            if (chargeLevelWhenHit > GetSweetSpot() && chargeLevelWhenHit <= SweetSpotMax)
            {
                tree.SetDamage(GetDamage());
                Debug.Log("HIT");
                Debug.Log("Charge Level: " + chargeLevelWhenHit + " Sweetspot: " + GetSweetSpot() + " - " + SweetSpotMax);
            }
            else
            {
                Debug.Log("Charge Level: " + chargeLevelWhenHit + " Sweetspot: " + GetSweetSpot() + " - " + SweetSpotMax);
                Debug.Log(GetChargeLevel() > GetSweetSpot());
            }
            chargeLevel = minCharge;
            chargeCounter = minCharge - 1;
            //tree.SetDamage(GetDamage());
        }
    }

    public void RandomizeSweetSpot() {
        sweetSpot = Random.Range(chargeSweetspotMin, chargeSweetspotMax + 1);
        Debug.Log(sweetSpot);
    }
    public int GetSweetSpot() { return sweetSpot; }
}
