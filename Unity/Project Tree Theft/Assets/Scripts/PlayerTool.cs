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
    [SerializeField] int mamaLumber = 0;
    [SerializeField] int grandpaJoe = 0;
    [SerializeField] int logan = 0;
    [SerializeField] int leaf = 0;
    

    private Vector3 standardPosition = new Vector3(0, 0.4f, 0);
    private Vector3 upPosition = new Vector3(0, 0.35f+0.4f, 0);
    private Vector3 rightPosition = new Vector3(0.35f, 0.4f, 0);
    private Vector3 downPosition = new Vector3(0, -0.35f+0.4f, 0);
    private Vector3 leftPosition = new Vector3(-0.35f, 0+0.4f, 0);

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

    private int[] goodChop = { 40, 69 };
    private int[] betterChop = { 70, 89 };
    private int[] bestChop = { 90, 99 };
    private int[] sweetSpots = new int[3];

    private int multiplier2x = 2;
    private int multiplier4x = 4;
    
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

        //"if" character name = "mamaLumber"
        damage = grandpaJoe;
        SetRandomSweetSpots();
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
            ChargeUpTool();
        }
        if (!isCharging)
        {
            chargeLevel = minCharge;
            chargeCounter = minCharge - 1;
            StartCoroutine(ResetChargeLevelWhenHit());
        }
        Debug.Log("Is charging: " + isCharging);
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
    public int GetMaxCharge() { return maxCharge; }

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
            //RandomizeSweetSpot();
            SetRandomSweetSpots();
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
            TreeMain tree = other.gameObject.GetComponent<TreeBody>().GetTreeMain();
            if (chargeLevelWhenHit >= GetSweetSpots()[0] && chargeLevelWhenHit < GetSweetSpots()[1])
            {
                tree.SetDamage(GetDamage());
                Debug.Log(tree.name + ": HIT");
            }
            else if(chargeLevelWhenHit >= GetSweetSpots()[1] && chargeLevelWhenHit < GetSweetSpots()[2])
            {
                tree.SetDamage(GetDamage() * multiplier2x);
                Debug.Log(tree.name + ": HIT 2X");
            }
            else if(chargeLevelWhenHit >= GetSweetSpots()[2] && chargeLevelWhenHit < GetMaxCharge())
            {
                tree.SetDamage(GetDamage() * multiplier4x);
                Debug.Log(tree.name + ": HIT 4X");
            }
            else
            {
                Debug.Log("Charge Level: " + chargeLevelWhenHit + " Sweetspot: " + GetSweetSpot() + " - " + SweetSpotMax);
                Debug.Log(GetChargeLevel() > GetSweetSpot());
            }
            Debug.Log("Charge Level: " + GetChargeLevel().ToString());
            chargeLevel = minCharge;
            chargeCounter = minCharge - 1;
            chargeLevelWhenHit = minCharge;
            isCharging = false;
            //tree.SetDamage(GetDamage());
        }
    }

    public void RandomizeSweetSpot() {
        sweetSpot = Random.Range(chargeSweetspotMin, chargeSweetspotMax + 1);
        Debug.Log(sweetSpot);
    }
    public int GetSweetSpot() { return sweetSpot; }

    public int[] GetSweetSpots() { return sweetSpots; }
    public void SetRandomSweetSpots() {
        sweetSpots[0] = Random.Range(goodChop[0], goodChop[1] + 1);
        sweetSpots[1] = Random.Range(betterChop[0], goodChop[1] + 1);
        sweetSpots[2] = Random.Range(bestChop[0], goodChop[1] + 1);
    }

    private IEnumerator ResetChargeLevelWhenHit(){
        yield return new WaitForSecondsRealtime(0.1f);
        chargeLevelWhenHit = minCharge;
    }
}
