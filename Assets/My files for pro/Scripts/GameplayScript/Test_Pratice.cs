using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboSTate
{
    None,
    Punch1,
    Punch2,
    Punch3,
    Kick1,
    Kick2
}
public class Test_Pratice : MonoBehaviour
{
    private CharacterAnimation playeranim;
    public bool activate_Timer_to_reset;
    public float default_timer = 0.4f;
    private float current_timer;

    private ComboSTate current_Combo_State;
    
    
    private void Awake()
    {
        playeranim = GetComponent<CharacterAnimation>();
        

    }

    private void Start()
    {
        current_timer = default_timer;
        current_Combo_State = ComboSTate.None;
    }
    private void Update()
    {
        comboattack();
        ResetCombo();
    }
    void comboattack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
           
               
                if (current_Combo_State == ComboSTate.Punch3 || current_Combo_State == ComboSTate.Kick1 || current_Combo_State == ComboSTate.Kick2)
                    return;
                current_Combo_State++;

                activate_Timer_to_reset = true;
                //  current_timer = default_timer;
                if (current_Combo_State == ComboSTate.Punch1)
                {
                    playeranim.Punch_1();
                
                }
                if (current_Combo_State == ComboSTate.Punch2)
                {
                    playeranim.Punch_2();
               
            }
                if (current_Combo_State == ComboSTate.Punch3)
                {
                    playeranim.Punch_3();
               
                
                }
            
            if (Input.GetKeyDown(KeyCode.X))
            {
                playeranim.Kick_1();
            }
        }

    }

    private void ResetCombo()
    {
        if (activate_Timer_to_reset)
        {
            
            current_timer -= Time.deltaTime;
            if(current_timer <= 0f)
            {
                

                current_Combo_State = ComboSTate.None;
                activate_Timer_to_reset = false;
                current_timer = default_timer;
            }
        }   
    }
}
