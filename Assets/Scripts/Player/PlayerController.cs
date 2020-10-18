using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    Camera cam;

    public LayerMask groundLayer;
    public GameObject unit;
    public NavMeshAgent playerAgent;

    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (GlobalSelection.selectedTable.selectedTable.ContainsValue(unit))
            {
                playerAgent.SetDestination(GetPointUnderCursor());
            }
        }
    }

    private Vector3 GetPointUnderCursor()
    {
        Vector3 mouseWorldPosition = Input.mousePosition;

        RaycastHit hitPosition;

        Ray ray = Camera.main.ScreenPointToRay(mouseWorldPosition);

        Physics.Raycast(ray, out hitPosition, 50000.0f, groundLayer);
        
        return hitPosition.point + new Vector3(Random.Range(0,6), 0, Random.Range(0, 6));
    }
}
