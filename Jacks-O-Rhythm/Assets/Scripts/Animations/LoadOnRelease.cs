using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class LoadOnRelease : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnDestroy()
    {
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }
    private void OnRelease(SelectExitEventArgs args)
    {
        SceneManager.LoadScene(1);
    }
}
