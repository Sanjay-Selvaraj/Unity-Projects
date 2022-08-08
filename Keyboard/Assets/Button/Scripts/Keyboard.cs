using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Keyboard : MonoBehaviour
{
    public TMP_InputField inputfield;
    public GameObject normalbutton;
    public GameObject capsbutton;
    public bool caps;
    // Start is called before the first frame update
    void Start()
    {
        caps = false;
    }

    public void InsertChar(string c)
    {
        inputfield.text +=c;
    }
    
    public  void DeleteChar()
    {
        if(inputfield.text.Length > 0)
        {
            inputfield.text = inputfield.text.Substring(0, inputfield.text.Length -1);
        }
    }

    public void InsertSpace()
    {
        inputfield.text += " ";
    }

    public void CapsPressed()
    {
        if (!caps)
        {
        normalbutton.SetActive(false);
        capsbutton.SetActive(true);
        caps = true;
        }
        else 
        {
        normalbutton.SetActive(true);
        capsbutton.SetActive(false);
        caps = false;
        }
    }
    
        
}
