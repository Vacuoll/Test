using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject PanelLose;
    public Text Score;
    public Text ScoreOutput;

    Rigidbody2D rb;
    public GameObject btnLeft;
    public GameObject btnRight;
    public GameObject btnJump;
    float PosBtnLeft;
    float PosBtnRight;
    float PosBtnJump;

    float run;

    private bool FacingRight = true;

    private bool IsGrounded;
    public Transform GroundCheck;
    public float checkRadiusGround;
    public LayerMask whatIsGround;

    private bool IsBlock;
    public Transform BlockCheck;
    public float checkRadiusBlock;

    void Start()
    {
        PosBtnLeft = btnLeft.transform.position.y;
        PosBtnRight = btnRight.transform.position.y;
        PosBtnJump = btnJump.transform.position.y;

        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, checkRadiusGround, whatIsGround);
        IsBlock = Physics2D.OverlapCircle(BlockCheck.position, checkRadiusBlock, whatIsGround);

        if (IsBlock)
            Lose();

        if (PosBtnJump != btnJump.transform.position.y && IsGrounded)
        {
            rb.AddForce(transform.up * 50f, ForceMode2D.Impulse);
        }

        if(PosBtnLeft != btnLeft.transform.position.y)
        {
            run = -5f;
        }
        else if (PosBtnRight != btnRight.transform.position.y)
        {
            run = 5f;
        }
        else
        {
            run = 0f;
        }

        if (run > 0 && FacingRight == false)
        {
            Flip();
        }
        else if (run < 0 && FacingRight == true)
        {
            Flip();
        }

        rb.velocity = new Vector2(run, rb.velocity.y);
       
    }

    void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Lose()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        PanelLose.SetActive(true);
        ScoreOutput.text = Score.text;

        Destroy(gameObject);
    }
}
