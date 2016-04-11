using UnityEngine;
using System.Collections;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class GunControls : MonoBehaviour
{
	// Connecting to the armband itself
	public GameObject myo = null;

	// Calling the Fire script, the gameobject that it spawns to, and the time of shot that comes out.
	public Fire fire;
	public GameObject Box;
	//private int selector = 0;
	public bool selector = false;

	private Pose _lastPose = Pose.Unknown;

	void Awake(){
		/*Time.timeScale = 0.0f;
		if (Input.GetKeyDown (KeyCode.W)) {
			Time.timeScale = 1.0f;
		}*/
	}

	// Update is called once per frame.
	void Update ()
	{
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;

			// Vibrate the Myo armband when a fist is made.
			if (thalmicMyo.pose == Pose.Fist) {
				thalmicMyo.Vibrate (VibrationType.Medium);

				fire = new Fire ();
				fire.fire (Box, selector);

				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			}

			else if (thalmicMyo.pose == Pose.DoubleTap) {
				// This is here just incase I need to change the selector.
				thalmicMyo.Vibrate (VibrationType.Short);

				if (selector == false) {
					selector = true;
				} else {
					selector = false;
				}

				Debug.Log (" Selector: " + selector);
				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			}
		}
	}

	// Extend the unlock if ThalmcHub's locking policy is standard, and notifies the given myo that a user action was
	// recognized.
	void ExtendUnlockAndNotifyUserAction (ThalmicMyo myo)
	{
		ThalmicHub hub = ThalmicHub.instance;

		if (hub.lockingPolicy == LockingPolicy.Standard) {
			myo.Unlock (UnlockType.Timed);
		}

		myo.NotifyUserAction ();
	}
}
