using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
	static UnityEvent<int> m_healthChangedEvent;
	public static UnityEvent<int> HealthChangedEvent { get { return m_healthChangedEvent; } }

	private int m_health = 120;

	public int m_healthDamagePerSeconds = 0;

	private void Awake()
	{
		m_healthChangedEvent = new UnityEvent<int>();
	}
	float m_healthDamageDelay = 1;
	private void Update()
	{
		m_healthDamageDelay -= Time.deltaTime;
		if(m_healthDamageDelay <= 0)
		{
			m_healthDamageDelay = 1;
			AddHealth(-m_healthDamagePerSeconds);
		}
	}
	public void AddHealth(int value)
	{
		m_health += value;
		m_healthChangedEvent.Invoke(m_health);
	}
}
