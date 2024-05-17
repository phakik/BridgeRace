using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OS", menuName = "BrickColorData")]
public class BrickColorOS : ScriptableObject
{
   public List<Material> colorList = new();
}
