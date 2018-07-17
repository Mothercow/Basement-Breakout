using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : MonoBehaviour {

    Vector3 FirstPoint;
    Vector3 SecondPoint;
    float xAngle;
    float yAngle;
    float xAngleTemp;
    float yAngleTemp;


    private bool gyroEnabled;
	private Gyroscope gyro;

	public GameObject cameraContainer;
	private Quaternion rot;
    /*
        public int rotSpeed;

        [SerializeField]
        private float startY;
        private Transform worldObj;
        private void Start()
        {

            cameraContainer = new GameObject ("Camera Container");
            cameraContainer.transform.position = transform.position;
            transform.SetParent (cameraContainer.transform);

            gyroEnabled = EnableGyro ();
            transform.localRotation = Quaternion.LerpUnclamped (Quaternion.identity, Input.gyro.attitude, rotSpeed);
        }

        private bool EnableGyro()
        {
            if (SystemInfo.supportsGyroscope) 
            {
                gyro = Input.gyro;
                gyro.enabled = true;

                cameraContainer.transform.rotation = Quaternion.Euler (90f, 90f, 0f); //sets initial camera container pos
                rot = new Quaternion (0, 0, 1, 0); 
                return true;
            }

            return false;
        }

        private void Update()
        {
            if (gyroEnabled) 
            {

                transform.localRotation = gyro.attitude * rot;
                //this.transform.Rotate (-Input.gyro.rotationRateUnbiased.x * rotSpeed, -Input.gyro.rotationRateUnbiased.y * rotSpeed, 0);
            }
        }

        public void Reset()
        {

            // transform.localRotation = Quaternion.Euler(-50f, 80f, -80f);
            Debug.Log("reset");
        }

        void OnGUI()
        {
            GUILayout.Label ("Gyroscope attitude : " + gyro.attitude);
            GUILayout.Label("Gyroscope gravity : " + gyro.gravity);
            GUILayout.Label("Gyroscope rotationRate : " + gyro.rotationRate);
            GUILayout.Label("Gyroscope rotationRateUnbiased : " + gyro.rotationRateUnbiased);
            GUILayout.Label("Gyroscope updateInterval : " + gyro.updateInterval);
            GUILayout.Label ("Gyroscope userAcceleration : " + gyro.userAcceleration);
        }*/

    void Start()
    {
        cameraContainer = new GameObject("CameraContainer");
        cameraContainer.transform.position = this.transform.position;
        this.transform.parent = cameraContainer.transform;
        Input.gyro.enabled = true;
        xAngle = 0;
        yAngle = 0;

    }
    void Update()
    {
        cameraContainer.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);
        this.transform.Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);
        
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                FirstPoint = Input.GetTouch(0).position;
                xAngleTemp = xAngle;
                yAngleTemp = yAngle;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {

                SecondPoint = Input.GetTouch(0).position;
                xAngle = xAngleTemp + (SecondPoint.x - FirstPoint.x);
                // yAngle = yAngleTemp + (SecondPoint.y - FirstPoint.y) * 90 / Screen.height;
                cameraContainer.transform.Rotate(0.0f, Input.GetTouch(0).deltaPosition.x, 0.0f);
            }
        }
    }
    public void Reset()
    {
        this.transform.localRotation = Quaternion.Euler(0, 0, 0);
        //        this.transform.Rotate(0, 0, 0);
        //      cameraContainer.transform.Rotate(0, 0, 0);
        Debug.Log("reset");
    }
}
