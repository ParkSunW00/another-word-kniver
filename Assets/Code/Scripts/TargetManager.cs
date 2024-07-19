using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
	[SerializeField] private ScoreManager m_scoreManager;
	[SerializeField] private List<GameObject> m_targetPrefabs = new();

	[SerializeField] private Vector2 m_rightSpawnPosition = Vector2.right;
	[SerializeField] private Vector2 m_middleSpawnPosition = Vector2.zero;
	[SerializeField] private Vector2 m_leftSpawnPosition = Vector2.left;

	enum Direction { RIGHT, MIDDLE, LEFT };
	Target m_target;
	Direction m_targetDirection;
	GameObject m_targetGameObject;

	private void Update()
	{
		if (!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.LeftArrow)) return;

		Direction typedDirection;
		if (Input.GetKeyDown(KeyCode.UpArrow)) typedDirection = Direction.MIDDLE;
		else if (Input.GetKeyDown(KeyCode.RightArrow)) typedDirection = Direction.RIGHT;
		else typedDirection = Direction.LEFT;

		if (typedDirection == m_targetDirection) Hit();
		Destroy(m_target.gameObject);
		Spawn();
	}

	private void Hit()
	{
		m_scoreManager.AddScore(m_target.TargetData.Score);
	}
	public void Spawn()
	{
		int index = Random.Range(0, m_targetPrefabs.Count);
		GameObject createdTarget = Instantiate(m_targetPrefabs[index]);
		int directNumber = Random.Range(0, 3);
		m_target = createdTarget.GetComponent<Target>();
		m_targetGameObject = createdTarget;
		switch (directNumber)
		{
			case 0:
				m_targetDirection = Direction.RIGHT;
				m_target.transform.position = m_rightSpawnPosition;
				break;
			case 1:
				m_targetDirection = Direction.MIDDLE;
				m_target.transform.position = m_middleSpawnPosition;
				break;
			case 2:
				m_targetDirection = Direction.LEFT;
				m_target.transform.position = m_leftSpawnPosition;
				break;
		}
	}
}
