using System.Collections;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
	[SerializeField] ComboManager m_comboManager;
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
			if (target.TargetData.Score > 0) m_comboManager.AddCombo();
			else m_comboManager.ResetCombo();
		}
		else
		{
			if (target.TargetData.Score <= 0) m_comboManager.AddCombo();
			else m_comboManager.ResetCombo();
		}

		m_targetManager.Spawn();
		m_timeLimitManager.ResetTimeLimit();
	}
	private void HandleTimeLimitEnd()
	{
		m_comboManager.ResetCombo();
		m_targetManager.Destory();
		m_targetManager.Spawn();
		m_timeLimitManager.ResetTimeLimit();
	}

	IEnumerator TargetSpawnWIthDelay(int seconds = 3)
	{
		yield return new WaitForSeconds(3);
		m_targetManager.Spawn();
		m_timeLimitManager.ResetTimeLimit();
	}
}
