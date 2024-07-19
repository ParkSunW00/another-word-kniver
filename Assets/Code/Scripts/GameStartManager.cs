using System.Collections;
using UnityEngine;

public class StartManager : MonoBehaviour
{
	[SerializeField] TargetManager m_targetManager;

	private void Start()
	{
		StartCoroutine(SpawnFIrstTarget());
	}

	IEnumerator SpawnFIrstTarget() {
		yield return new WaitForSeconds(3);
		m_targetManager.Spawn();
	}
}
