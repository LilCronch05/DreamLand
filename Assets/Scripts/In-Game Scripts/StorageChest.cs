using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StorageChest : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_InventorySlots;
    [SerializeField]
    private GameObject m_Inventory;
    [SerializeField]
    private TextMeshProUGUI m_InteractText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            m_InteractText.gameObject.SetActive(false);
            m_Inventory.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_InteractText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_InteractText.gameObject.SetActive(false);
            m_Inventory.SetActive(false);
        }
    }
}
