using System.Collections;
using UnityEngine;


public class InGameManager : MonoBehaviour
{
	const int BASE_TIME_LIMIT = 2;
	const int DAMAGE_PER_SECONDS = 2;
	const int START_DELAY_SECONDS = 3;

	[SerializeField] ComboManager m_comboManager;
	[SerializeField] HealthManager m_healthManager;
	[SerializeField] TargetManager m_targetManager;
	[SerializeField] TimeLimitManager m_timeLimitManager;
	[SerializeField] ScoreManager m_scoreManager;

	private void Start()
	{
		TimeLimitManager.TimeLimitEndedEvent.AddListener(m_comboManager.ResetCombo);
		TimeLimitManager.TimeLimitEndedEvent.AddListener(HandleTimeLimitEnd);
		StartCoroutine(TargetSpawnWIthDelay());
	}
	private void Update()
	{
		if (!m_targetManager.CheckSpawned()) return;
		if (!m_targetManager.CheckCurrectKeyDown()) return;

		GameObject targetGameObject = m_targetManager.Destory();
		Target target = targetGameObject.GetComponent<Target>();
		if (m_targetManager.CheckCorrectDirectionKeyDown())
		{
			m_scoreManager.AddScore(target.TargetData.Score);
			if (target.TargetData.Score > 0) AddComboAndHealHealth();
			else ResetComboAndDamageHealth();
		}
		else
		{
			if (target.TargetData.Score <= 0) AddComboAndHealHealth();
			else ResetComboAndDamageHealth();
		}

		m_targetManager.Spawn();
		ResetLimitTime();
	}
	private void AddComboAndHealHealth()
	{
		m_comboManager.AddCombo();
		m_healthManager.AddHealth(2);
	}
	private void ResetComboAndDamageHealth()
	{
		m_comboManager.ResetCombo();
		m_healthManager.AddHealth(-10);
	}
	private void ResetLimitTime()
	{
		float reduceLimit = Mathf.Floor(m_comboManager.Combo / 10) * 0.1f;
		m_timeLimitManager.ResetTimeLimit(BASE_TIME_LIMIT - reduceLimit);
	}
	private void HandleTimeLimitEnd()
	{
		m_comboManager.ResetCombo();
		m_targetManager.Destory();
		m_targetManager.Spawn();
		ResetLimitTime();
	}

	IEnumerator TargetSpawnWIthDelay()
	{
		yield return new WaitForSeconds(START_DELAY_SECONDS);
		m_healthManager.m_healthDamagePerSeconds = DAMAGE_PER_SECONDS;
		m_targetManager.Spawn();
		m_timeLimitManager.ResetTimeLimit(BASE_TIME_LIMIT);
	}
}
