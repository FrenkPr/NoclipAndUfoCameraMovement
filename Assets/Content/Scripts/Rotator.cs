using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 rotationVelocity;
    private Vector3 currentEulerAngles;

    // Start is called before the first frame update
    void Start()
    {
        currentEulerAngles = transform.localEulerAngles;
        transform.localEulerAngles = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 eulerRotation = transform.eulerAngles + velocity * Time.deltaTime;
        //Quaternion rotation = Quaternion.Euler(eulerRotation);

        //transform.rotation = rotation;

        currentEulerAngles += rotationVelocity * Time.deltaTime;
        //CheckAnglesOutOfBounds(ref currentEulerAngles);

        //transform.localEulerAngles = currentEulerAngles;
        transform.localRotation = Quaternion.Euler(currentEulerAngles);

        //UI_Mngr.Instance.TextSprites["textInfo"].text = transform.eulerAngles.ToString();
        //UI_Mngr.Instance.TextSprites["textInfo"].text = currentEulerAngles.ToString();
    }

    private void CheckAnglesOutOfBounds(ref Vector3 angles)
    {
        CheckAngleOutOfBounds(ref angles.x);
        CheckAngleOutOfBounds(ref angles.y);
        CheckAngleOutOfBounds(ref angles.z);
    }

    //it'll set the angle to 0 if the angle > 360
    //otherwise, if the angle < 0, will be set to 360
    private void CheckAngleOutOfBounds(ref float angle)
    {
        if (angle < 0)
        {
            angle = 0;
            angle += 360;
        }

        else if (angle > 360)
        {
            angle -= angle;
        }
    }
}
