using UnityEngine;

public class Target : MonoBehaviour
{
	[SerializeField] private TargetData m_targetData;

	protected enum Direction { RIGHT, MIDDLE, LEFT };
	protected Direction m_direction;

	public TargetData TargetData
	{
		get { return m_targetData; }
	}

	private void Awake()
	{
		int directionNumber = Random.Range(0, 3);
		switch (directionNumber)
		{
			case 0:
				m_direction = Direction.RIGHT;
				break;
			case 1:
				m_direction = Direction.MIDDLE;
				break;
			case 2:
				m_direction = Direction.LEFT;
				break;
		}
	}
}
