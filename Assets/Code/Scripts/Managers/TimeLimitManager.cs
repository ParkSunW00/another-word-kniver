using UnityEngine;
using UnityEngine.Events;

public class TimeLimitManager : MonoBehaviour
{
	static UnityEvent<float> m_timeLimitChangedEvent;
	static UnityEvent<float> m_timeLimitResetedEvent;
	static UnityEvent m_timeLimitEndedEvent;
	static public UnityEvent<float> TimeLimitChangedEvent { get { return m_timeLimitChangedEvent; } }
	static public UnityEvent<float> TimeLimitResetedEvent { get { return m_timeLimitResetedEvent; } }
	static public UnityEvent TimeLimitEndedEvent { get { return m_timeLimitEndedEvent; } }

	float m_timeLimit = 0;

	private void Awake()
	{
		m_timeLimitChangedEvent = new UnityEvent<float>();
		m_timeLimitResetedEvent = new UnityEvent<float>();
		m_timeLimitEndedEvent = new UnityEvent();
	}
	private void FixedUpdate()
	{
		if (m_timeLimit <= 0) return;
		m_timeLimit -= Time.deltaTime;
		m_timeLimitChangedEvent.Invoke(m_timeLimit);
		if (m_timeLimit <= 0) m_timeLimitEndedEvent.Invoke();
	}
	public void ResetTimeLimit(float value)
	{
		m_timeLimit = value;
		m_timeLimitResetedEvent.Invoke(m_timeLimit);
		m_timeLimitChangedEvent.Invoke(m_timeLimit);
	}
}
