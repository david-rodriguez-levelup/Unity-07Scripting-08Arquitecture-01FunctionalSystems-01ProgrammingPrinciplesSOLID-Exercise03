using UnityEngine;

public class FindNearestObjectByLayer : MonoBehaviour
{

    [SerializeField] LayerMask layers;
    [SerializeField] float radius = 10f;

    public GameObject Find()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layers);
        if (colliders.Length > 0)
        {
            float nearestDistance = float.MaxValue;
            GameObject nearestObject = null;
            for (int i = 0; i < colliders.Length; i++)
            {
                float distance = Vector3.Distance(transform.position, colliders[i].transform.position);
                if (distance < nearestDistance)
                {
                    nearestObject = colliders[i].gameObject;
                    nearestDistance = distance;
                }
            }
            return nearestObject;
        }
        else
        {
            return null;
        }       
    }

}
