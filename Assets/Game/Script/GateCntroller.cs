using UnityEngine;

public class GateCntroller : MonoBehaviour
{
    [SerializeField] int gateNumber;
    [SerializeField] Vector3 position;
    [SerializeField] Floor floor;
    [SerializeField] Floor PreviousFloor;
    float currentFloor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<Character>().passTheGate == true)
            {
                return;
            }
            int chaColor = other.gameObject.GetComponent<Character>().characterIndexColor;
            //GameObject floor = Instantiate(state, position, Quaternion.identity);
            //floor.SetActive(true);
            //states.Add(floor);
            //floor.GetComponent<StateController>().CheckColor(chaColor);
            floor.CheckColor((BrickColor)chaColor);
            PreviousFloor.RemoveColor((BrickColor)chaColor);
        }
    }
    void DestroyState()
    {

    }
}
