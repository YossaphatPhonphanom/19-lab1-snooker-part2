using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int playerScore;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject[] ballPositions;


    [SerializeField] private GameObject cueBall;
    [SerializeField] private GameObject ballline;


    [SerializeField] private float xInput;
    [SerializeField] private float force;

    [SerializeField] private GameObject camera;
    
    // Start is called before the first frame update
    void Start()
    {
        
        camera = Camera.main.gameObject;
        CameraBehindBall();
        
        instance = this;
        
        //set balls on the table
        SetBalls(BallColors.White, 0);
        SetBalls(BallColors.Red, 1);
        SetBalls(BallColors.Yellow, 2);
        SetBalls(BallColors.Green, 3);
        SetBalls(BallColors.Brown, 4);
        SetBalls(BallColors.Blue, 5);
        SetBalls(BallColors.Pink, 6);
        SetBalls(BallColors.Black, 7);
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateBall();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootBall();
        }
    }

    
    

    void SetBalls(BallColors color, int pos)
    {
        GameObject ball = Instantiate(ballPrefab, 
            ballPositions[pos].transform.position, 
            Quaternion.identity);
        Ball b = ball.GetComponent<Ball>();
        b.SetColorAndPoint(color);
    }

    void RotateBall()
    {
        xInput = Input.GetAxis("Horizontal");
        cueBall.transform.Rotate(new Vector3(0f,xInput,0f));
    }

    void shootBall()
    {
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.AddRelativeForce(Vector3.forward * force,ForceMode.Impulse);
        ballline.SetActive(false);
    }

    void CameraBehindBall()
    {
        camera.transform.parent = cueBall.transform;
        camera.transform.position = cueBall.transform.position + new Vector3(0, 20f, -15);
        
    }
}