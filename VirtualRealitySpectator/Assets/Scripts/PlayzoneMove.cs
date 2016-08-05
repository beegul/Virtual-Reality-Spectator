using UnityEngine;
using System.Collections;
using Valve.VR;

public class PlayzoneMove : MonoBehaviour
{
    Vector3 StartPosition;//The current start position of the Camera.
    Quaternion StartRotation;//The current start rotation of the Camera.

    public Transform CornerCamera1Position;
    public Transform CornerCamera2Position;
    public Transform CornerCamera3Position;
    public Transform CornerCamera4Position;

    public Transform ThirdPersonCameraPosition;
    public Transform FirstPersonCameraPosition;

    int LeftIndex;
    int RightIndex;

    bool ThirdPerson = false;
    bool FirstPerson = false;

    int CurrentView = 0;

    public SteamVR_TrackedObject Script;

    public GameObject Headset;
    public Transform HeadsetPosition;
    Vector3 HeadsetStartPosition;
    Quaternion HeadsetStartRotation;

    void Start ()
    {
        StartPosition = transform.position;
        StartRotation = transform.rotation;

        HeadsetStartPosition = HeadsetPosition.position;
        HeadsetStartRotation = HeadsetPosition.rotation;

        LeftIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
        RightIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);
    }

	void Update ()
    {
        if (SteamVR_Controller.Input(LeftIndex).GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            CurrentView = CurrentView - 1;
            if (CurrentView == 6)
            {
                CurrentView = 0;
            }
            if (CurrentView == -1)
            {
                CurrentView = 6;
            }
        }
        if (SteamVR_Controller.Input(RightIndex).GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            CurrentView = CurrentView + 1;
            if (CurrentView == 7)
            {
                CurrentView = 0;
            }
            if (CurrentView == -1)
            {
                CurrentView = 6;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentView = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentView = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentView = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CurrentView = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            CurrentView = 4;
        }

        //Swtich between first and third person view.
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            CurrentView = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            CurrentView = 6;
        }

        //Lerp between corner cameras.
        if (Input.GetKey(KeyCode.Alpha2) && Input.GetKey(KeyCode.LeftControl))
        {
            CurrentView = 7;
        }
        if (Input.GetKey(KeyCode.Alpha3) && Input.GetKey(KeyCode.LeftControl))
        {
            CurrentView = 8;
        }
        if (Input.GetKey(KeyCode.Alpha4) && Input.GetKey(KeyCode.LeftControl))
        {
            CurrentView = 9;
        }
        if (Input.GetKey(KeyCode.Alpha5) && Input.GetKey(KeyCode.LeftControl))
        {
            CurrentView = 10;
        }




        //Return to the start position.
        if (CurrentView == 0)
        {
            Script.enabled = true;
            FirstPerson = false;
            ThirdPerson = false;
            transform.position = StartPosition;
            transform.rotation = StartRotation;
        }

        //Instant swtich between corner between cameras.
        if (CurrentView == 1)
        {
            Script.enabled = true;
            FirstPerson = false;
            ThirdPerson = false;
            transform.position = CornerCamera1Position.position;
            transform.rotation = CornerCamera1Position.rotation;
        }
        if (CurrentView == 2)
        {
            Script.enabled = true;
            FirstPerson = false;
            ThirdPerson = false;
            transform.position = CornerCamera2Position.position;
            transform.rotation = CornerCamera2Position.rotation;
        }
        if (CurrentView == 3)
        {
            Script.enabled = true;
            FirstPerson = false;
            ThirdPerson = false;
            transform.position = CornerCamera3Position.position;
            transform.rotation = CornerCamera3Position.rotation;
        }
        if (CurrentView == 4)
        {
            Script.enabled = true;
            FirstPerson = false;
            ThirdPerson = false;
            transform.position = CornerCamera4Position.position;
            transform.rotation = CornerCamera4Position.rotation;
        }

        //Switch between first and third person view.
        if (CurrentView == 5)
        {
            FirstPerson = false;
            ThirdPerson = true;
            Script.enabled = true;
        }
        if(CurrentView == 6)
        {
            FirstPerson = true;
            ThirdPerson = false;
            //Script.enabled = true;
        }

        //Lerp between corner cameras.
        if (CurrentView == 7)
        {
            Script.enabled = true;
            FirstPerson = false;
            ThirdPerson = false;
            transform.position = Vector3.Lerp(transform.position, CornerCamera1Position.position, Time.deltaTime * 5.0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, CornerCamera1Position.rotation, Time.deltaTime * 5.0f);
        }
        if (CurrentView == 8)
        {
            Script.enabled = true;
            FirstPerson = false;
            ThirdPerson = false;
            transform.position = Vector3.Lerp(transform.position, CornerCamera2Position.position, Time.deltaTime * 5.0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, CornerCamera2Position.rotation, Time.deltaTime * 5.0f);
        }
        if (CurrentView == 9)
        {
            Script.enabled = true;
            FirstPerson = false;
            ThirdPerson = false;
            transform.position = Vector3.Lerp(transform.position, CornerCamera3Position.position, Time.deltaTime * 5.0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, CornerCamera3Position.rotation, Time.deltaTime * 5.0f);
        }
        if (CurrentView == 10)
        {
            Script.enabled = true;
            FirstPerson = false;
            ThirdPerson = false;
            transform.position = Vector3.Lerp(transform.position, CornerCamera4Position.position, Time.deltaTime * 5.0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, CornerCamera4Position.rotation, Time.deltaTime * 5.0f);
        }

        if (ThirdPerson == true)
        {
            transform.position = Vector3.Lerp(transform.position, ThirdPersonCameraPosition.position, Time.deltaTime * 5.0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, ThirdPersonCameraPosition.rotation, Time.deltaTime * 5.0f);
        }
        if(FirstPerson == true)
        {
            Script.enabled = false;

            Headset.transform.position = FirstPersonCameraPosition.position;
            Headset.transform.rotation = FirstPersonCameraPosition.rotation;

            transform.position = Vector3.Lerp(transform.position, Headset.transform.position, Time.deltaTime * 5.0f);//20
            transform.rotation = Quaternion.Lerp(transform.rotation, Headset.transform.rotation, Time.deltaTime * 5.0f);//20
        }
    }
}
