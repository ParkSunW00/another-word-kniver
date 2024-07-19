using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
	public enum Direction { RIGHT, MIDDLE, LEFT };

	[SerializeField] private List<GameObject> m_targetPrefabs = new();

	[SerializeField] private Vector2 m_rightSpawnPosition = Vector2.right;
	[SerializeField] private Vector2 m_middleSpawnPosition = Vector2.zero;
	[SerializeField] private Vector2 m_leftSpawnPosition = Vector2.left;

	Direction m_targetDirection;
	GameObject m_targetGameObject;

	public GameObject Destory()
	{
		Destroy(m_targetGameObject);
		return m_targetGameObject;
	}
	public GameObject Spawn()
	{
		int index = Random.Range(0, m_targetPrefabs.Count);
		m_targetGameObject = Instantiate(m_targetPrefabs[index]);

		int directNumber = Random.Range(0, 3);
		switch (directNumber)
		{
			case 0:
				m_targetDirection = Direction.RIGHT;
				m_targetGameObject.transform.position = m_rightSpawnPosition;
				break;
			case 1:
				m_targetDirection = Direction.MIDDLE;
				m_targetGameObject.transform.position = m_middleSpawnPosition;
				break;
			case 2:
				m_targetDirection = Direction.LEFT;
				m_targetGameObject.transform.position = m_leftSpawnPosition;
				break;
		}
		return m_targetGameObject;
	}
	public bool CheckCurrectKeyDown()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow)) return true;
		if (Input.GetKeyDown(KeyCode.RightArrow)) return true;
		if (Input.GetKeyDown(KeyCode.LeftArrow)) return true;
		return false;
	}
	public bool CheckCorrectDirectionKeyDown()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow) && m_targetDirection == Direction.MIDDLE) return true;
		if (Input.GetKeyDown(KeyCode.RightArrow) && m_targetDirection == Direction.RIGHT) return true;
		if (Input.GetKeyDown(KeyCode.LeftArrow) && m_targetDirection == Direction.LEFT) return true;
		return false;
	}
}
