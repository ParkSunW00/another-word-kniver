using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InGameManager : MonoBehaviour
{
	const int BASE_TIME_LIMIT = 2;
	const int DAMAGE_ON_WRONG = 15;
	const int DAMAGE_PER_SECONDS = 2;
	const int REDUCE_LIMIT_TIME_COUNT = 10;
	const int START_DELAY_SECONDS = 4;
	const float REDUCE_LIMIT_TIME_SECONDS = 0.2f;

	[SerializeField] ComboManager m_comboManager;
	[SerializeField] HealthManager m_healthManager;
	[SerializeField] TargetManager m_targetManager;
	[SerializeField] TimeLimitManager m_timeLimitManager;
	[SerializeField] TrafficManager m_trafficManager;
	[SerializeField] ScoreManager m_scoreManager;

	private void Start()
	{
		HealthManager.HealthDeathEvent.AddListener(HandleDeath);
		TimeLimitManager.TimeLimitEndedEvent.AddListener(ResetComboAndDamageHealth);
		TimeLimitManager.TimeLimitEndedEvent.AddListener(HandleTimeLimitEnd);
		StartCoroutine(m_trafficManager.StartAnimation());
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
		m_healthManager.AddHealth(-DAMAGE_ON_WRONG);
	}
	private void ResetLimitTime()
	{
		float reduceLimit = Mathf.Floor(m_comboManager.Combo / REDUCE_LIMIT_TIME_COUNT) * REDUCE_LIMIT_TIME_SECONDS;
		m_timeLimitManager.ResetTimeLimit(BASE_TIME_LIMIT - reduceLimit);
	}
	private void HandleDeath()
	{
		if (!PlayerPrefs.HasKey("bestScore") || PlayerPrefs.GetInt("bestScore") < m_scoreManager.Score)
		{
			PlayerPrefs.SetInt("bestScore", m_scoreManager.Score);
		}
		SceneManager.LoadScene("Rank");
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
