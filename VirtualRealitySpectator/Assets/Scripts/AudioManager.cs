using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    AudioSource Audio;
    public AudioClip Ambience;
    public AudioClip ZombieHorde;

    int LeftIndex;
    int RightIndex;

    void Start ()
    {
        Audio = GetComponent<AudioSource>();

        LeftIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
        RightIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);
    }
	

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space) || SteamVR_Controller.Input(LeftIndex).GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) || SteamVR_Controller.Input(RightIndex).GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Audio.PlayOneShot(ZombieHorde, 0.5f);
            Audio.PlayOneShot(Ambience, 0.25f);
            //Audio.Play();
        }
    }
}
