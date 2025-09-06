using UnityEngine;

public class player : MonoBehaviour
{
    public float normal_speed_player = 100f, sprint_speed_delta = 90f, delta_player_jump = 7f; //move
    private Rigidbody RB_Player;
    private float x_move = 0f, z_move = 0f, ground_check_distance = 1.1f, speed_player_move;

    private bool do_jump = false, is_grounded = false;

    

    private void Awake()
    {
        RB_Player = GetComponent<Rigidbody>();
    }

    void Update()
    {   //move player
        { //  for jumping
            if (Input.GetKeyDown(KeyCode.Space) && is_grounded)
            {
                do_jump = true;
            }
        }
    }

    private void FixedUpdate()
    {   //move player
        {   //sprint
            if (Input.GetKey(KeyCode.LeftControl))
            {
                speed_player_move =normal_speed_player + sprint_speed_delta;
            }
            else
            {
                speed_player_move = normal_speed_player;
            }
            //coordinates to move
            x_move = Input.GetAxis("Horizontal") * speed_player_move * Time.deltaTime;
            z_move = Input.GetAxis("Vertical") * speed_player_move * Time.deltaTime;


            // is ground checker and get correct Y coordinates 
            is_grounded = Physics.Raycast(transform.position, Vector3.down, ground_check_distance);
            Vector3 velocity_now = RB_Player.linearVelocity;
            float y_velocity = velocity_now.y;

            if (do_jump)
            {
                y_velocity = delta_player_jump;
                is_grounded = false;
                do_jump = false;
            }
            //move
            Vector3 move = transform.TransformDirection(new Vector3(x_move, y_velocity, z_move));
            RB_Player.linearVelocity = move;
        }
        // Inventory
        {

        }
    }

}
