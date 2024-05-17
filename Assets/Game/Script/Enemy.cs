using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
using System.Collections;

public class BotController : Character
{
    [SerializeField] public GameObject goalDes;
    [SerializeField] public NavMeshAgent agent;
    [SerializeField] LayerMask layerMask;
    List<GameObject> tartgetList;

    public List<GameObject> Tartlist => tartgetList;
    public Vector3 nextPos;
    IState currentState;
    public GameObject nextPosObj;

    public List<GameObject> PickBrick => pickedBricks;
    public bool OnStair => onStair;
    public bool CanMove => canMove;
    public Rigidbody Rb => rb;
    public void SetRB(Vector3 newRb) { rb.velocity = newRb; }

    void Start()
    {
        tartgetList = new List<GameObject>();
        pickedBricks = new List<GameObject>();
        characterIndexColor = 2;
        rb = GetComponent<Rigidbody>();
        ChangeState(new PatrolState());
    }
    private void Update()
    {
        onStair = CheckOnBridge();
        if (onStair == false)
        {
            canMove = true;
        }
        Moving();
        currentState?.OnExcute(this);

    }
    private void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.CompareTag("Gate"))
        {
            StartCoroutine(ToNewStage());
        }
    }
    public void ChangeState(IState newState)
    {
        currentState?.OnExit(this);
        currentState = newState;
        currentState?.OnEnter(this);
        Debug.Log(currentState);
    }
    public void FindTarget()
    {
        tartgetList.Clear();
        Collider[] colliders = Physics.OverlapSphere(transform.position, 20f, layerMask);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Brick"))
            {
                if (collider.gameObject.GetComponent<Brick>().indexColor == characterIndexColor)
                {
                    tartgetList.Add(collider.gameObject);
                }
            }
        }
        if (tartgetList.Count != 0)
        {
            GetNextTarget();
        }

    }
    public void GetNextTarget()
    {
        nextPosObj = tartgetList[Random.Range(0, tartgetList.Count - 1)];
        if (nextPosObj.activeSelf == true)
        {
            nextPos = nextPosObj.transform.position;
            SetAnim("Run");
        }
        agent.SetDestination(nextPos);
    }
    public void StopMoving()
    {
        canMove = false;
        rb.velocity = Vector3.zero;
        agent.SetDestination(this.transform.position);
        SetAnim("Idle");
        return;

    }
    IEnumerator ToNewStage()
    {
        yield return new WaitForSeconds(1f);
        ChangeState(new PatrolState());
    }
}
