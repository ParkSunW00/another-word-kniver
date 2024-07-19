using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
	static InputManager instance;
	public static InputManager Instance
	{
		get { return instance; }
	}

	UnityEvent rightKeyDownEvent = new();
	UnityEvent upKeyDownEvent = new();
	UnityEvent leftKeyDownEvent = new();

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
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
