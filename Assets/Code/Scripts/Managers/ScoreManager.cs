using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
	static UnityEvent<int> m_scoreChangedEvent;
	static public UnityEvent<int> ScoreChangedEvent { get { return m_scoreChangedEvent; } }

	private int score = 0;
	public int Score { get { return score; } }

	private void Awake()
	{
		m_scoreChangedEvent = new UnityEvent<int>();
	}
	public void AddScore(int value)
	{
		score += value;
		m_scoreChangedEvent.Invoke(score);
	}
}
