using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SetNavigationTarget : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown navigationTargetDropDown;
    [SerializeField]
    private List<Target> navigationTargetObjects = new List<Target>();

    private NavMeshPath path; // current calculated path
    private LineRenderer line; // linerenderer to display path
    private Vector3 targetPosition = Vector3.zero; // current target position

    private bool lineToggle = true;


    private void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
        line.enabled = lineToggle;

        //PlayerPrefs.SetString("SelectedDestination", "Room402");
        //PlayerPrefs.Save();
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("isQrScanned") == 1)
        {
            SetCurrentNavigationTarget();
            PlayerPrefs.SetInt("isQrScanned", 0);
            PlayerPrefs.Save();
            Debug.Log("QR scan set to: " + PlayerPrefs.GetInt("isQrScanned"));
        }

        if (lineToggle && targetPosition != Vector3.zero)
        {
            NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            line.SetPositions(path.corners);
        }
    }

    public void SetCurrentNavigationTarget()
    {
        targetPosition = Vector3.zero;
        Target currentTarget = navigationTargetObjects.Find(x => x.Name.Equals(PlayerPrefs.GetString("SelectedDestination")));
        if (currentTarget != null)
        {
            targetPosition = currentTarget.PositionObject.transform.position;
        }
    } // FireDragonGameStudio (2022a) 01/05 - ARFoundation indoor-navigation - NO cloudanchor, NO ARPointCloud, (almost) NO coding! Youtube. Available at: https://www.youtube.com/watch?v=fuHFrMZ4q_s.


    // FOR DEBUGGIN ONLY
    //public void SetCurrentNavigationTarget(int selectedValue)
    //{
    //    targetPosition = Vector3.zero;
    //    string selectedText = navigationTargetDropDown.options[selectedValue].text;
    //    Target currentTarget = navigationTargetObjects.Find(x => x.Name.Equals(selectedText));
    //    if (currentTarget != null)
    //    {
    //        targetPosition = currentTarget.PositionObject.transform.position;
    //    }
    //}



    // FOR DEBUGGING ONLY
    public void ToggleVisibility()
    {
        lineToggle = !lineToggle;
        line.enabled = lineToggle;
    }
}

/*
Reference List
FireDragonGameStudio (2022a) 01/05 - ARFoundation indoor-navigation - NO cloudanchor, NO ARPointCloud, (almost) NO coding! Youtube. Available at: https://www.youtube.com/watch?v=fuHFrMZ4q_s.


FireDragonGameStudio (2022b) 02/05 - ARFoundation indoor-navigation - NO cloudanchor, NO ARPointCloud, (almost) NO coding! Youtube. Available at: https://www.youtube.com/watch?v=C7TNBybSOq0.


FireDragonGameStudio (2023) ARIndoorNavigation, github.com. Available at: https://github.com/FireDragonGameStudio/ARIndoorNavigation.
 */