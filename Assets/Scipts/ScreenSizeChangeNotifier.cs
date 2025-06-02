using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ScreenSizeChangeNotifier : UIBehaviour
{
    [SerializeField] private UnityEvent notifyScreenSizeChange;

    protected override void OnRectTransformDimensionsChange()
    {
        notifyScreenSizeChange.Invoke();
    }
}
