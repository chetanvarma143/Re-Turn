using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterAnimation player_Anim;
    private Test_Pratice playeratck;
    private Rigidbody myBody;
    public float walk_Speed = 3f;
  
    public bool walkBackBool;
    private float rotation_y = -180f;
    //private float rotation_Speed = 15f;
    //public float z_Speed = 1.5f;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        player_Anim = GetComponentInChildren<CharacterAnimation>();
        playeratck = GetComponentInChildren<Test_Pratice>();
    }
   

  
    void Update()
    {
        AnimatePlayerWalk();
       
    //}
    //private void FixedUpdate()
    //{
        DetectMovement();
    }

    void DetectMovement()
    {
       
        
            float h = Input.GetAxisRaw("Horizontal");
            if (h > 0)
            {
                myBody.velocity = new Vector3(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (walk_Speed),
                  myBody.velocity.y, myBody.velocity.z);

            }
            else if (h < 0)
            {
                myBody.velocity = new Vector3(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * walk_Speed,
               myBody.velocity.y, myBody.velocity.z);

            }
        
           
      
    }//end of movement

   


    void AnimatePlayerWalk()
    {
       
            if (Input.GetAxis(Axis.HORIZONTAL_AXIS) > 0)
            {
                player_Anim.Walk(true);
                player_Anim.WalkBackFn(false);

            }
            else if (Input.GetAxis(Axis.HORIZONTAL_AXIS) < 0)
            {
                player_Anim.WalkBackFn(true);
                player_Anim.Walk(false);
            }
            else
            {
                player_Anim.Walk(false);
                player_Anim.WalkBackFn(false);
            }
        
            
        
        
    }//end of player walk
}
