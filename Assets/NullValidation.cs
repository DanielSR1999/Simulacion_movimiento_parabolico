using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class NullValidation : MonoBehaviour
{
    public int value = 0;
    public int id = 0;
    public DataValidation dataValidation;
    InputField myInputField;

    private void Start()
    {
        myInputField = GetComponent<InputField>();
    }
    public void OnFinish()
    {
        if(myInputField.text=="")
        {
            value = 0;
        }
        else
        {
            value = 1;
        }

        dataValidation.validator[id] = value;
    }
}
