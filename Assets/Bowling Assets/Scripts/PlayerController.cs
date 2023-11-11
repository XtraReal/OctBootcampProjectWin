using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 1.0f;
    public float arrowMaxPosition = 0.25f;
    public float arrowMinPosition = -0.25f;
    public Transform throwingArrow;
    public Transform ballSpawnPoint;
    public float throwForce = 5.0f;
    public Animator throwingArrowAnim;

    public Rigidbody[] balls;

    private float horizontalInput;
    private Vector3 ballOffset;
    private bool wasBallThrown;
    private Rigidbody selectedBall;
    [SerializeField]
    private float horizontalAxis;

    // Start is called before the first frame update
    void Start()
    {
        ballOffset = ballSpawnPoint.position - throwingArrow.position;
        //StartThrow(); // Moved to Game Manager
    }

    // Update is called once per frame
    void Update()
    {
        MoveArrowWithConstraints();
        TryThrowBall();
    }

    private void MoveArrowWithoutConstraints()
    {
        //Moving without constraints
        horizontalInput = Input.GetAxis("Horizontal");
        throwingArrow.position += throwingArrow.right * horizontalInput * speed * Time.deltaTime;
    }

    private void MoveArrowWithConstraints()
    {
        //Checks if ball hasn't been thrown
        if(!wasBallThrown)
        {
            //Moving with constraints

#if UNITY_STANDALONE || UNITY_STANDALONE_OSX || UNITY_EDITOR || UNITY_WIN
            float movePosition = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
#elif UNITY_IOS || UNITY_ANDROID
            // Setup mobile control
            float movePosition = horizontalAxis * speed * Time.deltaTime; // It may be greyed out because it is for Android/iOS platforms


#endif
            throwingArrow.position = new Vector3(
                Mathf.Clamp(throwingArrow.position.x + movePosition, arrowMinPosition, arrowMaxPosition),
                throwingArrow.position.y,
                throwingArrow.position.z
                );

            //Set ball position based on throwing direction position
            selectedBall.transform.position = throwingArrow.position + ballOffset;
        }
        
    }

    private void TryThrowBall()
    {
        //Throw the ball
        if (Input.GetKeyDown(KeyCode.Space) && !wasBallThrown)
        {
            wasBallThrown = true;
            selectedBall.AddForce(throwingArrow.forward * throwForce,
                ForceMode.Impulse);
            throwingArrowAnim.SetBool("Aiming", false);
        }
    }

    public void StartThrow()
    {
        throwingArrowAnim.SetBool("Aiming", true);
        wasBallThrown = false;

        // Spawn a new ball when start throw is called
        int randomNumber = GetRandomNumber(0, balls.Length);
        selectedBall = Instantiate(balls[randomNumber], ballSpawnPoint.position,
            Quaternion.identity);
    }

    private int GetRandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }

    public void setHorizontal(bool isLeft)
    {
        if (isLeft)
        {
            horizontalAxis = -1;
        }
        else
        {
            horizontalAxis = 1;
        }
    }

    public void ResetHorizontal()
    {
        horizontalAxis = 0;
    }

    public void TryThrowBallMobile()
    {
        if (!wasBallThrown)
        {
            wasBallThrown = true;
            selectedBall.AddForce(throwingArrow.forward * throwForce, ForceMode.Impulse);
            throwingArrowAnim.SetBool("Aiming", false);
        }
    }
}
