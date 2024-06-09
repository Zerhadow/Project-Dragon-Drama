using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeController : MonoBehaviour
{
    public enum TimeOfDay {
        Morning,
        Lunch,
        Afternoon,
        AfterSchool
    }

    public enum DayOfWeek {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }

    public TimeOfDay currentTimeOfDay { get; private set; }
    public int currentWeek { get; private set; }
    public DayOfWeek currentDayOfWeek { get; private set; }

    private void Awake() {
        // intialize starting time and date
        currentTimeOfDay = TimeOfDay.Morning;
        currentWeek = 1;
        currentDayOfWeek = DayOfWeek.Wednesday;
    }

    public void AdvanceTime() {
        // Advance the time of day
        currentTimeOfDay++;
        if ((int)currentTimeOfDay > 3)
        {
            // If past the last time of day, reset to morning and advance the day of the week
            currentTimeOfDay = TimeOfDay.Morning;
            AdvanceDay();
        }
    }

    public void AdvanceDay() {
        // Advance the day of the week
        currentDayOfWeek++;
        if ((int)currentDayOfWeek > 4)
        {
            // If past Friday, reset to Monday and advance the week number
            currentDayOfWeek = DayOfWeek.Monday;
            currentWeek++;
        }
    }

    public (int week, DayOfWeek dayOfWeek, TimeOfDay timeOfDay) GetCurrentTimeInfo() {
        return (currentWeek, currentDayOfWeek, currentTimeOfDay);
    }

    public bool GetCheckTimeInfo((int week, DayOfWeek dayOfWeek, TimeOfDay timeOfDay) timeInfo)
    {
        // Check if the timeInfo corresponds to week 1, Wednesday, and lunch time
        if (timeInfo.week == 1 && timeInfo.dayOfWeek == DayOfWeek.Wednesday && timeInfo.timeOfDay == TimeOfDay.Lunch)
        {
            Debug.Log("It is week 1, Wednesday, and lunch time!");
            return true;
        } else {return false; }
    }

    public TimeOfDay GetCurrentTimeOfDay()
    {
        return currentTimeOfDay;
    }
}
