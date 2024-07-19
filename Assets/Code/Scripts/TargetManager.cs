using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
	[SerializeField] private InputManager m_inputManager;
	[SerializeField] private ScoreManager m_scoreManager;

	Target rightTarget = null;
	Target middleTarget = null;
	Target leftTarget = null;

	private void Start()
	{
		m_inputManager.RightKeyDownEvent.AddListener(() => { if (rightTarget) Hit(rightTarget); });
		m_inputManager.UpKeyDownEvent.AddListener(() => { if (middleTarget) Hit(middleTarget); });
		m_inputManager.LeftKeyDownEvent.AddListener(() => { if (leftTarget) Hit(leftTarget); });
	}
	private void Hit(Target target)
	{
		m_scoreManager.AddScore(target.TargetData.Score);
	}
}
