using UnityEngine;

public class Target : MonoBehaviour
{
	[SerializeField] private TargetData m_targetData;
	public TargetData TargetData
	{
		get { return m_targetData; }
	}
}
