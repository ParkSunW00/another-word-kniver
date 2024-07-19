using UnityEngine;

public class ComboDocumentManager : MonoBehaviour
{
	[SerializeField] DocumentNumber m_documentNumber;

	private void Start()
	{
		ComboManager.ComboChangedEvent.AddListener(m_documentNumber.ResetNumberElements);
	}
}
