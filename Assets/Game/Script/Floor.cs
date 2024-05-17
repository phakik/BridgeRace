using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] List<Brick> floorBrick;
    public List<Brick> FloorBrick => floorBrick;
    public float floorID;
    void Start()
    {
        for (int i = 0; i < floorBrick.Count; i++)
        {
            if (floorBrick[i].gameObject.activeInHierarchy)
            {
                floorBrick[i].Init();
            }
        }
    }
    public void CheckColor(BrickColor characterColorIndex)
    {
        int randomBrick;
        for (int i = 0; i < 8; i++)
        {
            randomBrick = Random.Range(0, floorBrick.Count - 1);
            if (floorBrick[randomBrick].isActiveAndEnabled == false)
            {

                floorBrick[randomBrick].SetColor(characterColorIndex);
                floorBrick[randomBrick].gameObject.SetActive(true);
                floorBrick[randomBrick].indexColor = (int)characterColorIndex;

            }
        }

    }
    public void RemoveColor(BrickColor characterColorIndex)
    {
        for (int i = 0; i < floorBrick.Count; i++)
        {
            if (floorBrick[i].indexColor == (int)characterColorIndex)
            {
                floorBrick[i].tag = "Untagged";
            }
        }

    }
}
