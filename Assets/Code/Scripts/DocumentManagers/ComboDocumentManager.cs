using UnityEngine;
using UnityEngine.UIElements;

public class ComboDocumentManager : MonoBehaviour
{
	[SerializeField] UIDocument m_uiDocument;

	Label comboLabel;

	private void Awake()
	{
		comboLabel = m_uiDocument.rootVisualElement.Query<Label>("ComboLabel");
	}
	private void Start()
	{
		ComboManager.ComboChangedEvent.AddListener((combo) => { comboLabel.text = "Combo: " + combo; });
	}
}
