using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
	static UnityEvent rightKeyDownEvent;
	static UnityEvent upKeyDownEvent;
	static UnityEvent leftKeyDownEvent;

	public UnityEvent RightKeyDownEvent
	{
		get { return rightKeyDownEvent; }
	}
	public UnityEvent UpKeyDownEvent
	{
		get { return upKeyDownEvent; }
	}
	public UnityEvent LeftKeyDownEvent
	{
		get { return leftKeyDownEvent; }
	}

	private void Awake()
	{
		rightKeyDownEvent = new UnityEvent();
		upKeyDownEvent = new UnityEvent();
		leftKeyDownEvent = new UnityEvent();
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			rightKeyDownEvent.Invoke();
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			upKeyDownEvent.Invoke();
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			leftKeyDownEvent.Invoke();
		}
	}
}
