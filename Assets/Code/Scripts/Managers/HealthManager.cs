using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
	const int HEALTH_MAX = 120;

	[SerializeField] Slider m_slider;

	static UnityEvent<int> m_healthChangedEvent;
	public static UnityEvent<int> HealthChangedEvent { get { return m_healthChangedEvent; } }

	private int m_health = 120;

	public int m_healthDamagePerSeconds = 0;

	private void Awake()
	{
		m_healthChangedEvent = new UnityEvent<int>();
	}
	private void Start()
	{
		m_healthChangedEvent.AddListener((health) => { m_slider.value = health; });
	}
	float m_healthDamageDelay = 1;
	private void Update()
	{
		m_healthDamageDelay -= Time.deltaTime;
		if (m_healthDamageDelay <= 0)
		{
			m_healthDamageDelay = 1;
			AddHealth(-m_healthDamagePerSeconds);
		}
	}
	public void AddHealth(int value)
	{
		m_health += value;
		if (m_health > HEALTH_MAX) m_health = HEALTH_MAX;
		m_healthChangedEvent.Invoke(m_health);
	}
}
