using System.Collections.Generic;
using UnityEngine;

public enum BrickColor
{
    Blue,
    Red,
    Green,
    Purple
}

public class Brick : MonoBehaviour
{
    [SerializeField] GameObject brickAva;
    [SerializeField] private BrickColorOS brickColorOS;
    [SerializeField] Renderer m_renderer;
    public int indexColor;
    public bool stairBrick;
    public bool playerBrick;
    //private void Start()
    //{
    //    if (!playerBrick)
    //    {
    //        Init();
    //    }
    //}
    public GameObject BrickAva() { return brickAva; }
    public void Init()
    {
        if (stairBrick == true)
        {
            return;
        }
        indexColor = Random.Range(0, 4);
        SetBrickColor(indexColor);

    }

    public void ActiveBrick(int index)
    {
        SetBrickColor(index);
        indexColor = index;
        brickAva.SetActive(true);
    }
    public void DeActiveBrick()
    {
        gameObject.SetActive(false);
        brickAva.SetActive(false);
        Invoke(nameof(DelayRespawn), 2);
    }

    private void DelayRespawn()
    {
        gameObject.SetActive(true);
        brickAva.SetActive(true);
    }
    public void SetBrickColor(int colorIndex)
    {
        List<Material> list = brickColorOS.colorList;
        brickAva.GetComponent<MeshRenderer>().material = list[colorIndex];
    }

    public void SetColor(BrickColor color)
    {
        m_renderer.material = brickColorOS.colorList[(int)color];
    }
}
