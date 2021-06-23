using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataValidation : MonoBehaviour
{
    public InputField[] _inputsField;
    public int[] validator;
    int numForTrue = 3;
    public Canvas Input;
    public Text warningText;
    public GameObject[] objectsToEnable;

    public void DeleteSign(InputField _inputField)
    {
        if(_inputField.text.Contains("-"))
        {
            Debug.LogError("No se permiten valores negativos");
            _inputField.text = "";
            
        }
        if (_inputField.text.Contains("."))
        {
            string newText = _inputField.text.Replace('.', ',');
            _inputField.text = newText;
        }
    }
    public void Angles(InputField _inputField)
    {
        float angle = float.Parse(_inputField.text);
        if(angle>90)
        {
            Debug.LogError("Por favor ingrese un número entre 0 y 90");
            _inputField.text = "";
        }
    }

    
    public void ValidateFields()
    {
        int acumulator = 0;
        for(int i=0;i<validator.Length;i++)
        {
            acumulator += validator[i];
        }

        if(acumulator>=numForTrue)
        {
            Input.enabled = false;
            EnableSimulation();
        }
        else
        {
            warningText.enabled = true;
        }
    }
    public void EnableSimulation()
    {
        foreach(GameObject objects in objectsToEnable)
        {
            objects.SetActive(true);
        }
    }

}
