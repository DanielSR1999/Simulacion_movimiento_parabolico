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
    public ParabolicMovement parabolicMovement;

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
            switch (id)
            {
                case 0:
                    {
                        parabolicMovement.initialVelocity = float.Parse(myInputField.text);
                        break;
                    }
                case 1:
                    {
                        parabolicMovement.angle = float.Parse(myInputField.text);
                        break;
                    }
            }
        }

        dataValidation.validator[id] = value;

    }
}
