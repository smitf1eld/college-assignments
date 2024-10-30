using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class InputFields : MonoBehaviour
{
    [SerializeField] private TMP_InputField secondsInputField;
    [SerializeField] private TMP_InputField minutesInputField;
    [SerializeField] private TMP_InputField hoursInputField;
    
    private int _inputNumber;
    

    void Start()
    {
        secondsInputField.ActivateInputField();
    }


    public void OnTimeInputEndEdit()
    {
            if (int.TryParse(secondsInputField.text, out _inputNumber) && _inputNumber >= 0 && _inputNumber <= 60)
            {
                Clock.seconds = _inputNumber;
                
            }
            if (int.TryParse(minutesInputField.text, out _inputNumber) && _inputNumber >= 0 && _inputNumber <= 60)
            {
                Clock.minutes = _inputNumber;
            }
            if (int.TryParse(hoursInputField.text, out _inputNumber) && _inputNumber >= 0 && _inputNumber <= 24)
            {
                Clock.hours = _inputNumber;
            }
    }
    
}
