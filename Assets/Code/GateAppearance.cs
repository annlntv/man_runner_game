using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum DeformationType
{
    Width, 
    Height
}
public class GateAppearance : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Image topImage;
    [SerializeField] Image glassImage;
    [SerializeField] Color colorPositive;
    [SerializeField] Color colorNegative;
    

    [SerializeField] GameObject expandLable;
    [SerializeField] GameObject shrinkLable;
    [SerializeField] GameObject upLable;
    [SerializeField] GameObject downLable;


    public void UpdateVisual(DeformationType deformationType, int value)
    {
        string prefix = "";
        
        if (value > 0)
        {
            setColor(colorPositive);
            prefix = "+";
        }
        else if (value == 0)
        {
            setColor(Color.gray);
        }
        else
        {
            setColor(colorNegative);
        }
        text.text = prefix + value.ToString();

        expandLable.SetActive(false);
        shrinkLable.SetActive(false);   
        upLable.SetActive(false);   
        downLable.SetActive(false);

        if (deformationType == DeformationType.Width)
        {
            if (value > 0)
            {
                expandLable.SetActive(true);
            }
            else
            {
                shrinkLable.SetActive(true);
            }
        }
        else if (deformationType == DeformationType.Height)
        {
            if (value > 0)
            {
                upLable.SetActive(true);
            }
            else
            {
                downLable.SetActive(true);
            }
        }
    }

    void setColor(Color color)
    {
        topImage.color = color;
        glassImage.color = new Color(color.r, color.g, color.b, 0.5f);
    }
}