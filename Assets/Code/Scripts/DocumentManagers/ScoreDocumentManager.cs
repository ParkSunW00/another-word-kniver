using UnityEngine;
using UnityEngine.UIElements;

public class ScoreDocumentManager : MonoBehaviour
{
	[SerializeField] UIDocument m_uiDocument;

	Label m_scoreLabel;

	private void Awake()
	{
		m_scoreLabel = m_uiDocument.rootVisualElement.Query<Label>("ScoreLabel");
	}
	private void Start()
	{
	}
}
