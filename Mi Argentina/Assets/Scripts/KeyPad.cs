using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{
    [SerializeField] public Text Ans;
    [SerializeField] public Animator Door;
    public string Answer = "1234";

    public void Number(int number)
    {
        Ans.text += number.ToString(); 
    }

    public void Enter()
    {
        if (Ans.text == Answer)
        {
            Ans.text = "Correcto";
            Door.SetBool("Open", true);
        }
        else
        {
            Ans.text = "Invalido";
        }
    }

    public void Borrar()
    {
        Ans.text = "";
    }
}
