using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
	[SerializeField] private ScoreManager m_scoreManager;
	[SerializeField] private List<GameObject> m_targetPrefabs = new();

	[SerializeField] private Vector2 m_rightSpawnPosition = Vector2.right;
	[SerializeField] private Vector2 m_middleSpawnPosition = Vector2.zero;
	[SerializeField] private Vector2 m_leftSpawnPosition = Vector2.left;

	Target m_rightTarget = null;
	Target m_middleTarget = null;
	Target m_leftTarget = null;

	private void Start()
	{
		InputManager.RightKeyDownEvent.AddListener(() => { if (m_rightTarget) Hit(m_rightTarget); });
		InputManager.UpKeyDownEvent.AddListener(() => { if (m_middleTarget) Hit(m_middleTarget); });
		InputManager.LeftKeyDownEvent.AddListener(() => { if (m_leftTarget) Hit(m_leftTarget); });
	}
	private void Hit(Target target)
	{
		m_scoreManager.AddScore(target.TargetData.Score);
		Destroy(target.gameObject);
		Spawn();
	}
	public void Spawn()
	{
		int index = Random.Range(0, m_targetPrefabs.Count);
		GameObject createdTarget = Instantiate(m_targetPrefabs[index]);
		int directNumber = Random.Range(0, 3);
		switch (directNumber)
		{
			case 0:
				m_rightTarget = createdTarget.GetComponent<Target>();
				m_rightTarget.transform.position = m_rightSpawnPosition;
				break;
			case 1:
				m_middleTarget = createdTarget.GetComponent<Target>();
				m_middleTarget.transform.position = m_middleSpawnPosition;
				break;
			case 2:
				m_leftTarget = createdTarget.GetComponent<Target>();
				m_leftTarget.transform.position = m_leftSpawnPosition;
				break;
		}
	}
}
