using UnityEngine;
using UnityEngine.Events;

public class ComboManager : MonoBehaviour
{
	static UnityEvent<int> m_comboChangedEvent;
	static public UnityEvent<int> ComboChangedEvent { get { return m_comboChangedEvent; } }

	private int combo = 0;
	public int Combo { get { return combo; } }

	private void Awake()
	{
		m_comboChangedEvent = new UnityEvent<int>();
	}
	public void AddCombo()
	{
		++combo;
		m_comboChangedEvent.Invoke(combo);
	}
	public void ResetCombo()
	{
		combo = 0;
		m_comboChangedEvent.Invoke(combo);
	}
}
