using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketSpawnScript : MonoBehaviour
{
    [SerializeField] GameObject m_ticketPrefab;

    int m_ticketNumber = 0;
    int m_ticketAmount = 1;

    bool m_spawned;

    // Update is called once per frame
    void Update()
    {
        if ((m_spawned == false) && (m_ticketNumber < m_ticketAmount)) {
            m_ticketNumber++;
            Instantiate(m_ticketPrefab, this.transform.position, Quaternion.identity);
            m_spawned = true;
        }
    }
}
