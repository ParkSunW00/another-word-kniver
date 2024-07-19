using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	[SerializeField] TargetData m_targetData;
	[SerializeField] List<Sprite> m_spiretes = new();
	[SerializeField] SpriteRenderer m_spriteRenderer;
	[SerializeField] GameObject m_spotLightGameObject;

	public TargetData TargetData
	{
		get { return m_targetData; }
	}

	private void Start()
	{
		int randomIndex = Random.Range(0, m_spiretes.Count);
		m_spotLightGameObject.SetActive(TargetData.Score > 0);
		m_spriteRenderer.sprite = m_spiretes[randomIndex];
	}
}
