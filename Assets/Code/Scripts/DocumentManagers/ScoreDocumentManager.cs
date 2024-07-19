using UnityEngine;
using UnityEngine.UIElements;

public class ScoreDocumentManager : MonoBehaviour
{
	[SerializeField] DocumentNumber m_documentNumber;

	private void Start()
	{
		ScoreManager.ScoreChangedEvent.AddListener(m_documentNumber.ResetNumberElements);
	}
}
