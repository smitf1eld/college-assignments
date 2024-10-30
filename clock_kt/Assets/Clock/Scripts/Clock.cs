using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    // Поля
    public static int minutes = 0;
    public static int hour = 0;
    public static int seconds = 0;

    public GameObject pointerSeconds;
    public GameObject pointerMinutes;
    public GameObject pointerHours;
    public TextMeshProUGUI secondsTMP;
    public TextMeshProUGUI minutesTMP;
    public TextMeshProUGUI hourTMP;
    public TMP_InputField timeInputField;

    // Скорость времени
    public float clockSpeed = 1.0f;

    
    private float _msecs = 0;

    void Update()
    {
        // Счетчик времени
        _msecs += Time.deltaTime * clockSpeed;
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
                    hour++;
                    if (hour >= 24)
                        hour = 0;
                }
            }

            UpdateClock();
        }
    }
    private void Start()
    {
        timeInputField.ActivateInputField();
    }
    void UpdateClock()
    {
        // Обновление текстового вывода времени
        secondsTMP.text = seconds.ToString();
        minutesTMP.text = minutes.ToString();
        hourTMP.text = hour.ToString();

        // Математика стрелок
        float rotationSeconds = (360.0f / 60.0f) * seconds;
        float rotationMinutes = (360.0f / 60.0f) * minutes;
        float rotationHours = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

        // Изменение положения стрелок
        pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
        pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
        pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationHours);
    }

    public void SetTimeFromInputField(string timeString)
    {
        string[] timeParts = timeString.Split(':');
        if (timeParts.Length == 3 &&
            int.TryParse(timeParts[0], out int newHours) &&
            int.TryParse(timeParts[1], out int newMinutes) &&
            int.TryParse(timeParts[2], out int newSeconds))
        {
            hour = newHours % 24;
            minutes = newMinutes % 60;
            seconds = newSeconds % 60;

            UpdateClock();
        }
    }

    // Метод для вызова при окончании редактирования текста в TMP_InputField
    public void OnTimeInputEndEdit(string input)
    {
        SetTimeFromInputField(input);
    }
    
    
}