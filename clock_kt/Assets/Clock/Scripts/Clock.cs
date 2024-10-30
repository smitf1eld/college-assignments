using System;
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    // поля
    public static int minutes { get; set; }
    public static int hours { get; set; }
    public static int seconds { get; set; }

    [SerializeField] private GameObject pointerSeconds;
    [SerializeField] private GameObject pointerMinutes;
    [SerializeField] private GameObject pointerHours;
    [SerializeField] private TextMeshProUGUI secondsTMP;
    [SerializeField] private TextMeshProUGUI minutesTMP;
    [SerializeField] private TextMeshProUGUI hourTMP;

    // скорость времени
    private readonly float _clockSpeed = 1.0f;

    
    private float _msecs;

    void Update()
    {
        // счетчик времени
        _msecs += Time.deltaTime * _clockSpeed;
        if (_msecs >= 1.0f)
        {
            _msecs -= 1.0f;
            seconds++;
            if (seconds >= 60)
            {
                seconds = 0;
                minutes++;
                if (minutes >= 60)
                {
                    minutes = 0;
                    hours++;
                    if (hours >= 23)
                        hours = 0;
                }
            }

            UpdateClock();
        }
    }

    private void UpdateClock()
    {
        //  вывод времени текстом
        secondsTMP.text = seconds.ToString();
        minutesTMP.text = minutes.ToString();
        hourTMP.text = hours.ToString();

        // математика стрелок
        var rotationSeconds = (360.0f / 60.0f) * seconds;
        var rotationMinutes = (360.0f / 60.0f) * minutes;
        var rotationHours = ((360.0f / 12.0f) * hours) + ((360.0f / (60.0f * 12.0f)) * minutes);

        // изменение положения стрелок
        pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
        pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
        pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationHours);
    }
    
    
}