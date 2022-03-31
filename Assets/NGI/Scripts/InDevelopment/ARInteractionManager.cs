using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ARInteractionManager : MonoBehaviour
{

    [SerializeField] XRInteractionManager interactionManager;
    [SerializeField] Toggle toggle;


    private void OnEnable()
    {
        toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(toggle);
        });
    }

    private void OnDisable()
    {
        toggle.onValueChanged.RemoveAllListeners();
    }


    void ToggleValueChanged(Toggle change)
    {
        interactionManager.enabled = change.isOn;
    }


}
