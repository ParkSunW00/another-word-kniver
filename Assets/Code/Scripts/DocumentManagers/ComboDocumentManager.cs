using UnityEngine;
using UnityEngine.UIElements;

public class ComboDocumentManager : MonoBehaviour
{
	[SerializeField] DocumentNumber m_documentNumber;
	[SerializeField] UIDocument m_uiDocument;

	VisualElement m_numberWrapperElement;

	private void Awake()
	{
		m_numberWrapperElement = m_uiDocument.rootVisualElement.Query<VisualElement>("NumberWrapperElement");
	}
	private void Start()
	{
		ComboManager.ComboChangedEvent.AddListener(m_documentNumber.ResetNumberElements);
	}
}
