using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{

    private float lastTouchTime, currentTouchTime;

    public float velocityVal;
    public float torqueVal;
    public float thresholdTime;


    void Start()
    {
        velocityVal = 8.0f;
        torqueVal = 200.0f;
        thresholdTime = 0.3f;
    }


    void Update()
    {

#if UNITY_ANDROID
        moveHippoAndroid();
#endif

#if UNITY_EDITOR
        moveHippo();
#endif
    }







    void moveHippo()
    { //For testing only in your COMPUTER
        Vector3 currentPos, touchedPos, distanceVec;
        if (Input.GetMouseButtonDown(0))
        {
            startRotatingHippoAndStopIt();
        }

        else if (Input.GetMouseButtonUp(0))
        {
            currentPos = Camera.main.WorldToScreenPoint(transform.position);
            touchedPos = Input.mousePosition;
            distanceVec = (touchedPos - currentPos).normalized;
            stopRotatingHippoAndMoveIt(distanceVec, velocityVal);
        }
    }







    void moveHippoAndroid()
    {
        Vector3 currentPos, touchedPos, distanceVec;
        for (int i = 0; i < Input.touches.Length; i++)
        {
            Touch touch = Input.GetTouch(i);
            currentPos = Camera.main.WorldToScreenPoint(transform.position);
            touchedPos = touch.position;
            distanceVec = (touchedPos - currentPos).normalized;
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startRotatingHippoAndStopIt();
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                currentTouchTime = Time.time;
                if (currentTouchTime - lastTouchTime > thresholdTime)
                { //No Double Touch detected ...
                    lastTouchTime = Time.time;
                    stopRotatingHippoAndMoveIt(distanceVec, velocityVal);
                }
                else if (currentTouchTime - lastTouchTime < thresholdTime)
                { //Double Touch detected!
                    lastTouchTime = Time.time;
                    stopRotatingHippoAndMoveIt(distanceVec, velocityVal * 2.0f);
                }
            }
        }
    }







    void startRotatingHippoAndStopIt()
    {
        // We rorate the hippo...
        //GetComponent<Rigidbody2D>().fixedAngle = false;
        GetComponent<Rigidbody2D>().AddTorque(torqueVal);

        // ... and stop it
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }








    void stopRotatingHippoAndMoveIt(Vector3 distanceVec, float velocity)
    {
        // We stop rotating the hippo...
        Quaternion hippoQuatern = new Quaternion();
        hippoQuatern.eulerAngles = new Vector3(0, 0, 0);
        GetComponent<Rigidbody2D>().transform.rotation = hippoQuatern;

        // ... and move it.
        GetComponent<Rigidbody2D>().velocity = distanceVec * velocity;
    }



}