using UnityEngine;

public class TouchCamera : MonoBehaviour {
	Vector2?[] oldTouchPositions = {
		null,
		null
	};
	Vector2 oldTouchVector;
	float oldTouchDistance;

	private float dragSpeed = 2;
    private Vector3 dragOrigin;

	public float mapX = 61.4f; 
    public float mapY = 41.4f;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

	private bool FirstCalculus = false;

	void Update() {
		if (Application.platform == RuntimePlatform.Android) {
			MoveCamera ();
		}
		else {
			StandAloneCamera ();
		}
		CalculateMaxPosition ();
	}

	void LateUpdate() {

		if (FirstCalculus == true) {

			if (GetComponent<Camera>().orthographicSize > 20) {
				GetComponent<Camera>().orthographicSize = 20;
			}

			Vector3 target = transform.position;
			target.x = Mathf.Clamp(target.x, minX, maxX);
			target.y = Mathf.Clamp(target.y, minY, maxY);
			transform.position = target;

		}

    }    

	void MoveCamera () {

		if (Input.touchCount == 0) {
			oldTouchPositions[0] = null;
			oldTouchPositions[1] = null;
		}
		else if (Input.touchCount == 1) {
			Pan ();
		}
		else {
			Zoom ();
		}

	}

	void StandAloneCamera () {
		
		if (Input.GetMouseButtonDown(0)) {

            dragOrigin = Input.mousePosition;
            return;
        }
 
        if (!Input.GetMouseButton(0)) return;
 
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);
 
        transform.Translate(move, Space.World);
		
	}


	void Pan () {
		if (oldTouchPositions[0] == null || oldTouchPositions[1] != null) {
			oldTouchPositions[0] = Input.GetTouch(0).position;
			oldTouchPositions[1] = null;
		}
		else {
			Vector2 newTouchPosition = Input.GetTouch(0).position;
			
			transform.position += transform.TransformDirection((Vector3)((oldTouchPositions[0] - newTouchPosition) * GetComponent<Camera>().orthographicSize / GetComponent<Camera>().pixelHeight * 2f));
			
			oldTouchPositions[0] = newTouchPosition;
		}
	}

	void Zoom () {
		if (oldTouchPositions[1] == null) {
			oldTouchPositions[0] = Input.GetTouch(0).position;
			oldTouchPositions[1] = Input.GetTouch(1).position;
			oldTouchVector = (Vector2)(oldTouchPositions[0] - oldTouchPositions[1]);
			oldTouchDistance = oldTouchVector.magnitude;
		}
		else {
			Vector2 screen = new Vector2(GetComponent<Camera>().pixelWidth, GetComponent<Camera>().pixelHeight);
			
			Vector2[] newTouchPositions = {
				Input.GetTouch(0).position,
				Input.GetTouch(1).position
			};
			Vector2 newTouchVector = newTouchPositions[0] - newTouchPositions[1];
			float newTouchDistance = newTouchVector.magnitude;

			GetComponent<Camera>().orthographicSize *= oldTouchDistance / newTouchDistance;

			oldTouchPositions[0] = newTouchPositions[0];
			oldTouchPositions[1] = newTouchPositions[1];
			oldTouchVector = newTouchVector;
			oldTouchDistance = newTouchDistance;
		}
	}


	public void CalculateMaxPosition () {
		float vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;  
        float horzExtent = vertExtent * Screen.width / Screen.height;
		minX = horzExtent - mapX / 2.0f;
        maxX = mapX / 2.0f - horzExtent ;
        minY = vertExtent - mapY / 2.0f;
        maxY = mapY / 2.0f - vertExtent;
		FirstCalculus = true;
	}


}
