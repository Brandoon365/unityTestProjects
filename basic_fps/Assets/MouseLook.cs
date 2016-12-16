using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	//Enum to associate names with settings
	public enum RotationAxes {
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxes axes = RotationAxes.MouseXAndY;
	// Horizontal and Vertical rotation speeds
	public float sensitivityHor = 9.0f;
	public float sensitivityVert = 9.0f;

	//Vertical rotation limits
	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	private float _rotationX = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Horizontal rotation
		if (axes == RotationAxes.MouseX) {
			transform.Rotate (0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
		}
		// Vertical rotation
		else if (axes == RotationAxes.MouseY) {
			_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);
			//Keep Y angle
			float rotationY = transform.localEulerAngles.y;
			transform.localEulerAngles = new Vector4 (_rotationX, rotationY, 0);
		}
		// Horizontal and vertical rotation
		else {
			_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);

			float delta = Input.GetAxis ("Mouse X") * sensitivityVert;
			float rotationY = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);
		}
	}
}
