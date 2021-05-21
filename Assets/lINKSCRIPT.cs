
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
 
// Code adapted from Unity Package Manager TextMeshPro "Examples and Extras";
// see Scene 12a and the TMP_TextEventHandler.cs script.
public class lINKSCRIPT : MonoBehaviour, IPointerClickHandler
{
    // Used to look up link info
    private TMP_Text m_TextComponent;

    // Used by the TMP_TextUtilities package to determine
    // if the position of a click intersects with a link
    private Camera m_Camera;
    private Canvas m_Canvas;

    void Awake()
    {
        // Get a reference to the text component.
        m_TextComponent = gameObject.GetComponent<TMP_Text>();

        // Get a reference to the camera rendering the text taking into consideration the text component type.
        if (m_TextComponent.GetType() == typeof(TextMeshProUGUI))
        {
            m_Canvas = gameObject.GetComponentInParent<Canvas>();
            if (m_Canvas != null)
            {
                if (m_Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
                    m_Camera = null;
                else
                    m_Camera = m_Canvas.worldCamera;
            }
        }
        else
        {
            m_Camera = Camera.main;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("TMP_LinkClickHandler.OnPointerClick(): Caught a click...");

        Vector3 clickPosition = new Vector3(eventData.position.x, eventData.position.y, 0);

        // Check if mouse intersects with any links.
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(m_TextComponent, clickPosition, m_Camera);

        // Handle new Link selection.
        if (linkIndex != -1)
        {
            // Get information about the link.
            TMP_LinkInfo linkInfo = m_TextComponent.textInfo.linkInfo[linkIndex];

            // Send the event to any listeners.
            HandleLinkClick(linkInfo.GetLinkID(), linkInfo.GetLinkText(), linkIndex);
        }
    }

    public void HandleLinkClick(string inLinkID, string inLinkText, int inLinkIndex)
    {
        Debug.Log("TMP_LinkClickHandler.HandleLinkClick(): Link ID #" + inLinkID + " clicked!");

        // Be aware of the injection attack ramifications of using this function:
        // https://docs.unity3d.com/ScriptReference/Application.OpenURL.html
        Application.OpenURL(inLinkText);
    }
}