using UnityEngine;

[CreateAssetMenu(fileName = "Target Data", menuName = "Scriptable Object/Target Data")]
public class TargetData : ScriptableObject
{
	[SerializeField] int m_score = 0;
	public int Score { get { return m_score; } }
}
