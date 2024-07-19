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
		StartCoroutine(TargetSpawnWIthDelay());
	}
	private void Update()
	{
		if (!m_targetManager.CheckSpawned()) return;
		if (!m_targetManager.CheckCurrectKeyDown()) return;

		GameObject hitedTargetGameObject = m_targetManager.Destory();
		Target hitedTarget = hitedTargetGameObject.GetComponent<Target>();
		if (m_targetManager.CheckCorrectDirectionKeyDown())
		{
			m_scoreManager.AddScore(hitedTarget.TargetData.Score);
			if (hitedTarget.TargetData.Score > 0) m_comboManager.AddCombo();
			else m_comboManager.ResetCombo();
		} else
		{
			if (hitedTarget.TargetData.Score <= 0) m_comboManager.AddCombo();
			else m_comboManager.ResetCombo();
		}

		m_targetManager.Spawn();
		m_timeLimitManager.ResetTimeLimit();
	}

	IEnumerator TargetSpawnWIthDelay(int seconds = 3)
	{
		yield return new WaitForSeconds(3);
		m_targetManager.Spawn();
	}
}
