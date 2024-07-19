using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
	static UnityEvent scoreChangedEvent = new();

	private int score = 0;
	public int Score
	{
		get { return score; }
	}

	public void AddScore(int value)
	{
		score += value;
		scoreChangedEvent.Invoke();
	}
}
