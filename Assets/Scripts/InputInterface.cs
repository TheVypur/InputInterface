using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputInterface : MonoBehaviour
{
    public HashSet<KeyCode> m_CurrentKeysPressed = new HashSet<KeyCode>();
    public HashSet<KeyCode> m_PrevKeysPressed = new HashSet<KeyCode>();
    public Dictionary<string, float> m_AxisValues = new Dictionary<string, float>();
    public Dictionary<string, float> m_PrevAxisVales = new Dictionary<string, float>();

    public bool bIsAiControlled = false;
    public bool bIsRetworkedControlled = false;

    public void Start()
    {
        m_AxisValues.Add("Horizontal", 0);
        m_AxisValues.Add("Vertical", 0);

        m_PrevAxisVales.Add("Horizontal", 0);
        m_PrevAxisVales.Add("Vertical", 0);

    }

    public void Clear()
    {
        m_CurrentKeysPressed.Clear();
    }

    public bool AddKeyPressed(KeyCode key)
    {
        return m_CurrentKeysPressed.Add(key);
    }

    public void Update()
    {
        
    }

    public void LateUpdate()
    {

        m_PrevKeysPressed = m_CurrentKeysPressed;
        m_PrevAxisVales = m_AxisValues;
    }

    IEnumerator SetPrevs()
    {
        yield return new WaitForEndOfFrame();
        m_PrevKeysPressed = m_CurrentKeysPressed;
        m_PrevAxisVales = m_AxisValues;
    }

    public bool GetKey(KeyCode key)
    {
        if (!bIsAiControlled && !bIsRetworkedControlled)
        {
            return Input.GetKey(key);
        }
        else if (bIsAiControlled)
        {
            return m_CurrentKeysPressed.Contains(key);
        }
        else
        {
            return false;
        }
    }

    public bool GetKeyDown(KeyCode key)
    {
        if (!bIsAiControlled && !bIsRetworkedControlled)
        {
            return Input.GetKeyDown(key);
        }
        else if (bIsAiControlled)
        {
            if (m_CurrentKeysPressed.Contains(key) && !m_CurrentKeysPressed.Contains(key))
                return true;
            else
                return false;
        }
        else
        {
            return false;
        }
    }

    public bool GetKeyUp(KeyCode key)
    {
        if (!bIsAiControlled && !bIsRetworkedControlled)
        {
            return Input.GetKeyUp(key);
        }
        else if (bIsAiControlled)
        {
            if (!m_CurrentKeysPressed.Contains(key) && m_CurrentKeysPressed.Contains(key))
                return true;
            else
                return false;
        }
        else
        {
            return false;
        }
    }

    public float GetAxis(string axis)
    {
        if (!bIsAiControlled && !bIsRetworkedControlled)
        {
            return Input.GetAxis(axis);
        }
        else if (bIsAiControlled)
        {
            return m_AxisValues[axis];
        }
        else
        {
            return m_AxisValues[axis];
        }
    }

}
