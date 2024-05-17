using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickColorManager : MonoBehaviour
{
    [SerializeField] MeshRenderer brickMesh;
    public int indexColor;
    [SerializeField] private BrickColorOS brickColorOS;
    [SerializeField] private Brick brick;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        brick = GetComponent<Brick>();
    }
    private void Init()
    {
        
        if (brick.stairBrick == true)
        {
            return;
        }
        indexColor = Random.Range(0, 4);
        SetBrickColor(indexColor);

    }
    private void OnEnable()
    {
        if (brick.stairBrick == true)
        {
            return;
        }
        SetBrickColor(indexColor);
    }

    public enum BrickColor
    {
        Blue,
        Red,
        Green,
        Purple
    }
    public void SetBrickColor(int colorIndex)
    {
        List<Material> list = brickColorOS.colorList;
        for (int i = 0; i < list.Count; i++)
        {
            if (i == colorIndex)
            {
                brickMesh.material = list[i];
            }
        }
    }

}
