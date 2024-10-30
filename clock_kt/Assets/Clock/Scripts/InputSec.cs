using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputSec : MonoBehaviour
{
    [SerializeField] private TMP_InputField timeInputField;
    [SerializeField] private int inputNumber;

    void Start()
    {
        timeInputField.ActivateInputField();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (int.TryParse(timeInputField.text, out inputNumber) && inputNumber >= 0 && inputNumber <= 60)
            {
                Clock.seconds = inputNumber;
            }

        }
    }
}
