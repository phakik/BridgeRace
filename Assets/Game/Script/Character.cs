using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] Animator animator;
    protected Rigidbody rb;
    public int characterIndexColor;
    string currentAnim;
    protected bool canMove;
    protected List<GameObject> pickedBricks;
    [SerializeField] Vector3 spawnPos;
    [SerializeField] protected bool onStair = false;
    [SerializeField] LayerMask layer;
    Collider brickColi;
    public bool passTheGate = false;




    protected virtual void Moving()
    {
        onStair = CheckOnBridge();
        if (onStair)
        {
            if (brickColi.GetComponent<Brick>().indexColor == characterIndexColor)
            {
                canMove = true;
            }
            else if (transform.forward.z > 0)
            {
                if (pickedBricks.Count == 0)
                {
                    canMove = false;
                }
                else
                {
                    canMove = true;
                }
            }
            else
            {
                canMove = true;
            }
        }

    }


    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Brick"))
        {
            if (collider.GetComponent<Brick>().indexColor == characterIndexColor)
            {
                GameObject brick = Instantiate(collider.gameObject);
                brick.tag = "Untagged";
                pickedBricks.Add(brick);
                brick.GetComponent<Brick>().playerBrick = true;
                brick.GetComponent<Brick>().SetBrickColor(characterIndexColor);
                brick.transform.SetParent(transform, false);
                brick.transform.SetLocalPositionAndRotation(spawnPos, Quaternion.identity);
                spawnPos += new Vector3(0, 0.2f, 0);
                collider.GetComponent<Brick>().DeActiveBrick();
            }
        }
        if (collider.gameObject.CompareTag("StairBrick"))
        {
            brickColi = collider;
            if (collider.GetComponent<Brick>().indexColor != characterIndexColor)
            {
                if (pickedBricks.Count > 0)
                {
                    Destroy(pickedBricks[^1]);
                    pickedBricks.Remove(pickedBricks[pickedBricks.Count - 1]);
                    spawnPos -= new Vector3(0, 0.2f, 0);
                    collider.GetComponent<Brick>().ActiveBrick(characterIndexColor);
                }
            }

        }
        if (collider.gameObject.CompareTag("Gate"))
        {
            passTheGate = true;
        }
    }
    protected void SetAnim(string animName)
    {
        if (currentAnim != animName)
        {
            animator.SetBool(currentAnim, false);
            currentAnim = animName;
            animator.SetBool(currentAnim, true);
        }

    }
    protected virtual void SetAnim()
    {

    }
    protected bool CheckOnBridge()
    {
        Physics.Raycast(this.transform.position, Vector3.down, out RaycastHit hit, 100f, layer);
        if (hit.collider != null && hit.collider.CompareTag("Stair"))
        {
            return true;
        }
        return false;

    }
}
