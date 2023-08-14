using UnityEngine;

[CreateAssetMenu(fileName = "FloatValue", menuName = "SriptableObjects/FloatValue", order = 0)]
public class FloatValue : ScriptableObject 
{
  [field: SerializeField] 
  public float Value  = 100;
}
