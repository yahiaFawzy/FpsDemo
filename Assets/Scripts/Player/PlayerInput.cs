using UnityEngine;



[DefaultExecutionOrder(-100)]
public class PlayerInput : MonoBehaviour
{

    public Vector2 move;
    public Vector2 look;
    public bool sprint;
    public bool jump;

    public bool EnableDebug;
    internal bool EnableKeyBordInput = true;
    internal bool EnaMouseInput;

    private void Update()
    {
        if (EnableKeyBordInput)
        {
            move.x = Input.GetAxisRaw("Horizontal");
            move.y = Input.GetAxisRaw("Vertical");
            jump =   jump   || Input.GetKey(KeyCode.Space);
        }

        if (EnaMouseInput)
        {
            look.x = Input.GetAxisRaw("Mouse X");
            look.y = Input.GetAxisRaw("Mouse Y");
        }
          

    }


    private void FixedUpdate()
    {
#if UNITY_EDITOR
        if (EnableDebug)
        {
            Debug.Log("move " + move);
            Debug.Log("look " + look);
        }
#endif

        move.x = 0;
        move.y = 0;
        look.x = 0;
        look.y = 0;
        sprint = false;
        jump   = false;
    }

}

