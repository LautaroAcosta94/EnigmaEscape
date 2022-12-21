using UnityEngine;
using UnityEngine.UI;

public class Puzzle_Piano : MonoBehaviour
{
    public bool Nota_DO = false;
    public bool Nota_MI = false;
    public bool Nota_DO2 = false;
    public bool Nota_SOL = false;
    public AudioSource TEST;
    public Puzzle_Piano Piano;

    //AnimacionArmario
    public Animator puertaArmario1;
    public Animator puertaArmario2;

    void Start()
    {
        
    }

 
    void Update()
    {
       
    }

    public void Primera_Nota()
    {
        Nota_DO = true;
    }

    public void Segunda_Nota()
    {
        if (Nota_DO == true)
        {
            Nota_MI = true;
        }
        else Notas_off();
    }

    public void Tercer_Nota()
    {
        if (Nota_MI == true)
        {
            Nota_DO2 = true;
        }
        else Nota_DO2 = false;
    }

    public void Cuarta_Nota()
    {
        if (Nota_DO2 == true)
        {
            Nota_SOL = true;
            TEST.Play();
            puertaArmario1.SetBool("Open", true);
            puertaArmario2.SetBool("Open", true);
            Destroy(Piano, 1.5f);
        }
        else Notas_off();
    }

    public void Notas_off()
    {
        Nota_DO = false;
        Nota_MI = false;
        Nota_DO2 = false;
        Nota_SOL = false;
    }
    
}
