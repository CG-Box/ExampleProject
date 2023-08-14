using UnityEngine;
using TMPro;

public class HealthTextChanger : MonoBehaviour, IDataPersistence
{
    [field: SerializeField] 
    private FloatValue Health;
    private TMP_Text HealthText;

    private void Awake() {
        HealthText = gameObject.GetComponent<TMP_Text>();
    }

    public void UpdateText()
    {
        HealthText.text = Health.Value.ToString();
    }

    public void LoadData(GameData data) 
    {
        Health.Value = data.globals.healthAmount;
        UpdateText();
    }

    public void SaveData(GameData data) 
    {
        data.globals.healthAmount = Health.Value;
    }
}
