using UnityEngine;

[CreateAssetMenu(fileName = "Target Data", menuName = "Scriptable Object/Target Data")]
public class TargetData : ScriptableObject
{
	[SerializeField] private int score = 0;
	public int Score { get { return score; } }
}
