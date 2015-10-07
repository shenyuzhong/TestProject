using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UpdateValue : MonoBehaviour {

    private Slider input_slider;
    private InputField input_textField;
    public float MaxInputValue;
    public float MinInputValue;
    public float StartingValue;
    private float variableValue = 0;
    void Start()
    {
        //get my slider and my inputfield
        input_slider = gameObject.GetComponentInChildren<Slider>();
        input_textField = gameObject.GetComponentInChildren<InputField>();
        //adjust and modify our min/max for this given variable
        input_slider.GetComponent<Slider>().maxValue = MaxInputValue;
        input_slider.GetComponent<Slider>().minValue = MinInputValue;
        input_slider.GetComponent<Slider>().value = StartingValue;
        variableValue = StartingValue;
        UpdateTextBox(StartingValue);
            
    }
    /// <summary>
    /// Called when User manually types in value
    /// </summary>
    /// <param name="passedValue"></param>
    public void UpdateSliderFromInput(string passedValue)
    {
        //change in text
        float currentValue = -99;
        if (input_textField)
        {
            float.TryParse(passedValue, out currentValue);
            currentValue = Mathf.Round(currentValue * 10f) / 10f;
            if (checkMinMax(currentValue))
            {
                //the input value is between our designated user values
                input_slider.GetComponent<Slider>().value = currentValue;
                
            }
            else
            {
                //the user has typed in a value that is not between our min and max
                if (currentValue > MaxInputValue)
                {
                    //if user is trying to max out their value, then set slider to defined max
                    input_slider.GetComponent<Slider>().value = MaxInputValue;
                    UpdateTextBox(MaxInputValue);
                    
                }
                else
                {
                    if (currentValue < MinInputValue)
                    {
                        //if user is trying to min out their value, then set slider to defined min
                        input_slider.GetComponent<Slider>().value = MinInputValue;
                        UpdateTextBox(MinInputValue);
                        
                    }
                }
            }
                if (currentValue == 0f)
                {
                    input_textField.GetComponent<InputField>().textComponent.text = passedValue;
                    input_textField.GetComponent<InputField>().text = passedValue;
                    
                }
            
        }
    }
    /// <summary>
    /// called when user manually updates slider
    /// </summary>
    /// <param name="passedFloat"></param>
    public void UpdateInputFromSlider(float passedFloat)
    {
        //change in slider
        if (input_slider)
        {
            passedFloat = Mathf.Round(passedFloat * 10f) / 10f;
            UpdateTextBox(passedFloat);
            
        }
    }
    /// <summary>
    /// check to see if the passed value aligns with the user defined min and max values
    /// </summary>
    /// <param name="currentV"></param>
    /// <returns></returns>
    private bool checkMinMax(float currentV){

        if (currentV <= input_slider.GetComponent<Slider>().maxValue && currentV >= input_slider.GetComponent<Slider>().minValue)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    /// <summary>
    /// Handles updating the text boxes to match everything
    /// </summary>
    /// <param name="newValue"></param>
    private void UpdateTextBox(float newValue){
        newValue = Mathf.Round(newValue * 10f) / 10f;
        input_textField.GetComponent<InputField>().textComponent.text = newValue.ToString();
        input_textField.GetComponent<InputField>().text = newValue.ToString();
        variableValue = newValue;
        GenerateEquation();
    }
    private void GenerateEquation()
    {
        //see if we can send a message to update and reconstruct a new equation
        SendMessageUpwards("Modification");
    }
    /// <summary>
    /// used to obtain the current input variable
    /// </summary>
    /// <returns></returns>
    public float ReturnVariable()
    {
        return variableValue;
    }
}
