using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
	[SerializeField] SpriteRenderer m_spriteRenderer;
	[SerializeField] List<Sprite> m_sprites;

	public IEnumerator StartAnimation()
	{
		for (int i = 0; i < m_sprites.Count; i++)
		{
			m_spriteRenderer.sprite = m_sprites[i];
			yield return new WaitForSeconds(1);
		}
		gameObject.SetActive(false);
	}
}
