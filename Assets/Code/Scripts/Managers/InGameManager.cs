using System.Collections;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
	[SerializeField] TargetManager m_targetManager;
	[SerializeField] TimeLimitManager m_timeLimitManager;
	[SerializeField] ScoreManager m_scoreManager;

	private void Start()
	{
		StartCoroutine(TargetSpawnWIthDelay());
	}
	private void Update()
	{
		if (!m_targetManager.CheckCurrectKeyDown()) return;

		GameObject hitedTargetGameObject = m_targetManager.Destory();
		m_targetManager.Spawn();

		if (m_targetManager.CheckCorrectDirectionKeyDown())
		{
			Target hitedTarget = hitedTargetGameObject.GetComponent<Target>();
			m_scoreManager.AddScore(hitedTarget.TargetData.Score);
			m_timeLimitManager.ResetTimeLimit();
		}
	}

	IEnumerator TargetSpawnWIthDelay(int seconds = 3)
	{
		yield return new WaitForSeconds(3);
		m_targetManager.Spawn();
	}
}
