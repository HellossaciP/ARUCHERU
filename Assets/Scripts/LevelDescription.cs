using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class LevelDescription
{
    [XmlAttribute] public string Name;
    [XmlAttribute] public float Duration;
    [XmlElement("EnemyDescription", typeof(EnemyDescription))] public EnemyDescription[] EnemyDescriptions;
}
