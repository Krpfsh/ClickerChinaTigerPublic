using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AchiveItem", menuName = "Achivement/AchiveItem")]
public class AchiveItem : ScriptableObject
{
    [field: SerializeField] public string id { get; private set; }
    [field: SerializeField] public string TextRu { get; private set; }
    [field: SerializeField] public string TextEng { get; private set; }
    [field: SerializeField] public string TextTr { get; private set; }
}
