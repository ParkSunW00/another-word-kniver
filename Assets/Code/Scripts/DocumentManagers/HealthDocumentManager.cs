using UnityEngine;
using UnityEngine.UIElements;

public class HealthDocumentManager : MonoBehaviour
{
	[SerializeField] UIDocument m_uiDocument;

	ProgressBar m_healthProgressBar;

	private void Awake()
	{
		m_healthProgressBar = m_uiDocument.rootVisualElement.Query<ProgressBar>("HealthProgressBar");
	}
	private void Start()
	{
		HealthManager.HealthChangedEvent.AddListener((health) => { m_healthProgressBar.value = health; });
	}
}
