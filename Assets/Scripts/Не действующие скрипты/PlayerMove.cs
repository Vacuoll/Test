using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public GameObject PanelLose;
    public Text Score;
    public Text ScoreOutput;
    private Vector2 sumVect;
    private Vector2 startPos;
    public float speed;

    private Rigidbody2D rb;
    private bool IsGrounded;
    public Transform GroundCheck;
    public float checkRadiusGround;
    public LayerMask whatIsGround;
    public float jumpForse;

    private bool IsBlock;
    public Transform BlockCheck;
    public float checkRadiusBlock;
 

    private bool FacingRight = true;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PanelLose.SetActive(false);
        
    }
    void Update()
    {
      
    }
    void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, checkRadiusGround, whatIsGround);

        IsBlock = Physics2D.OverlapCircle(BlockCheck.position, checkRadiusBlock, whatIsGround);

        startPos = this.transform.position;

        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Stationary)
            {
                sumVect = new Vector2((Input.touches[0].position.x - 320f) - startPos.x, Input.touches[0].position.y - startPos.y);

                //if (IsGrounded)
                 rb.velocity = new Vector2(speed * sumVect.normalized.x, 0); 
                
               /* if(Mathf.Abs(sumVect.y) > Mathf.Abs(sumVect.x) && IsGrounded)
                {
                    rb.velocity = Vector2.up * jumpForse;
                }*/

                if (sumVect.x > 0 && FacingRight == false)
                {
                    Flip();
                }
                else if (sumVect.x < 0 && FacingRight == true)
                {
                    Flip();
                }

            }
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                sumVect = new Vector2((Input.touches[0].position.x - 320f) - startPos.x, Input.touches[0].position.y - startPos.y);

                if (Mathf.Abs(sumVect.y) > Mathf.Abs(sumVect.x) && IsGrounded )
                {
                    rb.velocity += new Vector2(0, jumpForse);
                    
                }
            }
        }

        if (IsBlock)
            Lose();
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
