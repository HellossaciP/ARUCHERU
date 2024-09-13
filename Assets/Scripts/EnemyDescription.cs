using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyDescription
{
    [XmlElement] public Vector2 SpawnPosition;
    [XmlElement] public float SpawnDate;
    [XmlElement] public string PrefabPath;
}
