using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsTakenChecker : MonoBehaviour
{
    private ButtonLogic buttonLogic;
    public bool BreakPressed;
    private IgnitionCheck ignitionCheck;
    public bool KeyInserted;
    private BLACKTagChecker tagCheck;
    public bool TagDown;
    private ExternalStopButtonLogic outsideButtonCheck;
    public bool OutsideButtonDown;
    private LeverPressed leverCheck;
    public bool LeverPulled;
    private Air_Service AirCheck;
    public bool AirCheckDone;
    private Power_Service PowerCheck;
    public bool PowerCheckDone;
    private DogClip DogClip;
    public bool DogClipCheck;
    private Accelerator accelerator;
    public bool acceleratorCheck;
    private Cab_Power_Service CabPower;
    public bool CabPowerCheck;
    private Cab_Air_Service CabAir;
    public bool CabAirCheck;
    private HeightMarker heightMarker;
    public bool heightMarkerCheck;
    private BLACKTagReplaced BLACKTagReplaced;
    public bool BlackBackCheck;

    private timer TimerInfo;
    private string currentTime;

    public bool simulationWon = false;
    public float score;
    public bool scoreCheckedFlag = false;

    private debug DebugButton;

    // Start is called before the first frame update
    void Start()
    {
        if (buttonLogic == null)
        {
            buttonLogic = FindObjectOfType<ButtonLogic>();
        }
        if (ignitionCheck == null)
        {
            ignitionCheck = FindObjectOfType<IgnitionCheck>();
        }
        if (tagCheck == null)
        {
            tagCheck = FindObjectOfType<BLACKTagChecker>();
        }
        if (outsideButtonCheck == null)
        {
            outsideButtonCheck = FindObjectOfType<ExternalStopButtonLogic>();
        }
        if (leverCheck == null)
        {
            leverCheck = FindObjectOfType<LeverPressed>();
        }
        if (AirCheck == null)
        {
            AirCheck = FindObjectOfType<Air_Service>();
        }
        if (PowerCheck == null)
        {
            PowerCheck = FindObjectOfType<Power_Service>();
        }
        if (DogClip == null)
        {
            DogClip = FindObjectOfType<DogClip>();
        }
        if (accelerator == null)
        {
            accelerator = FindObjectOfType<Accelerator>();
        }
        if (CabAir == null)
        {
            CabAir = FindObjectOfType<Cab_Air_Service>();
        }
        if (CabPower == null)
        {
            CabPower = FindObjectOfType<Cab_Power_Service>();
        }
        if (heightMarker == null)
        {
            heightMarker = FindObjectOfType<HeightMarker>();
        }
        if (BLACKTagReplaced == null)
        {
            BLACKTagReplaced = FindObjectOfType<BLACKTagReplaced>();
        }
        if (TimerInfo == null)
        {
            TimerInfo = FindObjectOfType<timer>();
        }
        if (DebugButton == null)
        {
            DebugButton = FindObjectOfType<debug>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = TimerInfo.extTime;
        //Debug.Log(currentTime);
        CheckStartingBrake();
        CheckKeyInsertion();
        CheckForBLACKTag();
        CheckOutsideBrake();
        CheckLever();
        CheckForAir();
        CheckForPower();
        CheckDogClip();
        Accelerate();
        CheckForCabAir();
        CheckForCabPower();
        CheckHeightMarker();
        CheckForBLACKBack();
        WinCondition();
        calculateWin();

        if (DebugButton.isPressed == true)
        {
            simulationWon = true;
        }
    }

    private void CheckStartingBrake()
    {
        if (buttonLogic == null)
        {
            return;
        }

        if (buttonLogic.isPressed == true)
        {
            if (BreakPressed == false)
            {
                Debug.Log("BreakPressed");
                BreakPressed = true;
                return;
            }
        }

    }
    private void CheckOutsideBrake()
    {
        if (outsideButtonCheck == null)
        {
            return;
        }

        if (buttonLogic.isPressed == true)
        {
            if (OutsideButtonDown == false)
            {
                //Debug.Log("OutsideButtonDown");
                OutsideButtonDown = true;
                return;
            }
        }

    }
    private void CheckKeyInsertion()
    {
        if (ignitionCheck == null)
        {
            return;
        }

        if (ignitionCheck.isInserted == false)
        {
            //Debug.Log("KeyOut");
            KeyInserted = false;
            return;
        }
        if (ignitionCheck.isInserted == true)
        {
            //Debug.Log("KeyIn");
            KeyInserted = true;
            return;
        }
    }
    private void CheckForBLACKTag()
    {
        if (tagCheck == null)
        {
            return;
        }
        if (tagCheck.isDown == true)
        {
            //Debug.Log("TagDown");
            TagDown = true;
            return;
        }
    }
    private void CheckLever()
    {
        if (leverCheck == null)
        {
            return;
        }

        if (leverCheck.isPressed == true)
        {
            if (leverCheck == false)
            {
                //Debug.Log("LeverPulled");
                LeverPulled = true;
                return;
            }
        }
    }
    private void CheckForAir()
    {
        if (AirCheck == null)
        {
            return;
        }
        if (AirCheck.isDown == true)
        {
            //Debug.Log("AirDown");
            AirCheckDone = true;
            return;
        }
    }
    private void CheckForPower()
    {
        if (PowerCheck == null)
        {
            return;
        }
        if (PowerCheck.isDown == true)
        {
            //Debug.Log("PowDown");
            PowerCheckDone = true;
            return;
        }
    }
    private void CheckDogClip()
    {
        if (DogClip == null)
        {
            return;
        }

        if (DogClip.isPressed == true)
        {
            if (DogClipCheck == false)
            {
                //Debug.Log("DogClipCheck");
                DogClipCheck = true;
                return;
            }
        }

    }
    private void Accelerate()
    {
        if (accelerator == null)
        {
            return;
        }

        if (accelerator.isPressed == true)
        {
            if (acceleratorCheck == false)
            {
                //Debug.Log("acceleratorCheck");
                acceleratorCheck = true;
                return;
            }
        }

    }
    private void CheckForCabAir()
    {
        if (CabAir == null)
        {
            return;
        }
        if (CabAir.isDown == true)
        {
            //Debug.Log("CabAirCheck");
            CabAirCheck = true;
            return;
        }
    }
    private void CheckForCabPower()
    {
        if (CabPower == null)
        {
            return;
        }
        if (CabPower.isDown == true)
        {
            //Debug.Log("CabPowerCheck");
            CabPowerCheck = true;
            return;
        }
    }
    private void CheckHeightMarker()
    {
        if (heightMarker == null)
        {
            return;
        }

        if (heightMarker.isPressed == true)
        {
            if (heightMarkerCheck == false)
            {
                //Debug.Log("BreakPressed");
                heightMarkerCheck = true;
                return;
            }
        }

    }
    private void CheckForBLACKBack()
    {
        if (BLACKTagReplaced == null)
        {
            return;
        }
        if (BLACKTagReplaced.isDown == true)
        {
            //Debug.Log("BlackBackCheck");
            BlackBackCheck = true;
            return;
        }
    }


    private void WinCondition()
    {
        // check all required flags in one expression for clarity
        bool allPassed = BreakPressed && KeyInserted && OutsideButtonDown &&
                         AirCheckDone && PowerCheckDone && DogClipCheck && acceleratorCheck &&
                         CabPowerCheck && CabAirCheck;

        if (allPassed)
        {
            simulationWon = true;
            return;
        }

        // optional: log first failing flag to help debugging
        if (!BreakPressed) Debug.Log("Win blocked: BreakPressed missing");
        else if (!KeyInserted) Debug.Log("Win blocked: KeyInserted missing");
        else if (!OutsideButtonDown) Debug.Log("Win blocked: OutsideButtonDown missing");
        //else if (!LeverPulled) Debug.Log("Win blocked: LeverPulled missing");
        else if (!AirCheckDone) Debug.Log("Win blocked: AirCheckDone missing");
        else if (!PowerCheckDone) Debug.Log("Win blocked: PowerCheckDone missing");
        else if (!DogClipCheck) Debug.Log("Win blocked: DogClipCheck missing");
        else if (!acceleratorCheck) Debug.Log("Win blocked: acceleratorCheck missing");
        else if (!CabPowerCheck) Debug.Log("Win blocked: CabPowerCheck missing");
        else if (!CabAirCheck) Debug.Log("Win blocked: CabAirCheck missing");
    }

    private void calculateWin()
    {
        if (scoreCheckedFlag == false)
        {
            if (simulationWon == true)
            {
                if (TagDown == true)
                {
                    score = score + 70;
                }
                if (heightMarkerCheck == true)
                {
                    score = score + 70;
                }
                if (BlackBackCheck == true)
                {
                    score = score + 70;
                }
                float floatTime = TimerInfo.minutes;
                floatTime = floatTime + (TimerInfo.seconds - 100);
                score = score + (1000 / floatTime);

                Debug.Log(score);
                scoreCheckedFlag = true;
                simulationWon = true;
                }
        }
        
    }



    /*
    if (TagDown == true)
    {

    }

    if (heightMarkerCheck == true)
    {

    }

    if (BlackBackCheck == true)
    {

    }
    */
    /*
    private void scoreManager(bool BreakApplied, bool KeysRemoved, bool BlackTagPlaced, bool ptsContact, bool ParkingBreakApplied, bool LegsLowered)
    {

    }
    */
}





