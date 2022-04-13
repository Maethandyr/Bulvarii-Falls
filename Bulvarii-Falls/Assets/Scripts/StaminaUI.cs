using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private Stamina stamina;

    private void Start()
    {
        stamina = gameObject.GetComponentInParent<Stamina>();
    }

    public void SetMaxEnergy(float energy)
    {
        slider.maxValue = energy;
        slider.value = energy;
        //fill.color = gradient.Evaluate(1f);
    }

    public void SetEnergy(float energy)
    {
        stamina.stamina = energy;
        slider.value = energy;
    }

    public void LoseEnergy(float energy)
    {
        stamina.stamina -= energy;
        slider.value = stamina.stamina;
    }
}
