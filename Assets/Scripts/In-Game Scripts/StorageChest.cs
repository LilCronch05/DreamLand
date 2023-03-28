using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.EventSystems;

public class StorageChest : MonoBehaviour
{
    [SerializeField]
    private GameObject m_InventoryPanel;
    [SerializeField]
    private GameObject m_InteractText;

    private bool m_IsInteracting;

    void Update()
    {
        if (m_IsInteracting)
        {
            m_InteractText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                m_InventoryPanel.SetActive(true);
                m_InteractText.SetActive(false);
            }
        }
        else
        {
            m_InteractText.SetActive(false);
            m_InventoryPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_IsInteracting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_IsInteracting = false;
        }
    }
}
