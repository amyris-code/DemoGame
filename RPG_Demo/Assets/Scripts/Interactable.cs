using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    bool isFocus = false;
    Transform player;

    public Transform interactableTransform;

    bool hasInteracted = false;
    
    public virtual void Interact()
    {
        //Debug.Log("Interactable with " + transform.name);
    }

    private void Update()
    {
        if(isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position,interactableTransform.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        if(interactableTransform == null)
            interactableTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactableTransform.position,radius);
    }
}
