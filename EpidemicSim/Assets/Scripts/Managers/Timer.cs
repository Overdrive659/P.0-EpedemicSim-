using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] VarHolder VarHolder;
    [SerializeField] Text TimerText;

    public int totHours;
    public int totMinutes;

    public int tmpHours;
    public int tmpMinutes;

    public float timeRemainingS;
    public float totalTimeS;
    public float minuteStep;

    public int secondsPassed;
    public int minutesPassed;

    public bool timerIsRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        //Total time
        totHours = VarHolder.simHours;
        totMinutes = VarHolder.simMinutes;

        //These will decrease with timer
        tmpHours = VarHolder.simHours;
        tmpMinutes = VarHolder.simMinutes;

        //calculates entire time in seconds????
        timeRemainingS = (totHours * 3600) + (totMinutes * 60);
        totalTimeS = timeRemainingS;

        //Used to decrease minute timer
        minuteStep = timeRemainingS;

        //Sets the timer display to the starting value
        TimerText.text = string.Format("{0:00}:{1:00}", tmpHours, tmpMinutes);
    }

    // Update is called once per frame
    void Update()
    {
        //If the timer is running:
        if (timerIsRunning)
        {
            timeRemainingS -= Time.deltaTime;

            //CHECKS IF TIMER HAS REACHED 0, QUITS APPLICATION
            if(tmpHours <= 0 && tmpMinutes <= 0)
            {
                timerIsRunning = false;
                Debug.Log("Timer Has Run Out!");
                Debug.Log("Printing All Data to .TXT File");
                Application.Quit();
            }

            //Check if the total time has decreased with 60 seconds, if it has: Timestamp it and decrease minute timer, then check again.
            if (timeRemainingS <= minuteStep - 60)
            {
                minuteStep = timeRemainingS;
                tmpMinutes = tmpMinutes - 1;
                //Check if minutes have reached zero, if it has: Reset minutes back up and remove 1 hour from the clock.
                if (tmpMinutes <= -1)
                {
                    tmpHours = tmpHours - 1;
                    tmpMinutes = 59;
                }
                TimerText.text = string.Format("{0:00}:{1:00}", tmpHours, tmpMinutes);
            }

        }

        secondsPassed = Convert.ToInt32(totalTimeS - timeRemainingS);
        minutesPassed = Convert.ToInt32((totalTimeS - timeRemainingS) / 60);
    }
}
