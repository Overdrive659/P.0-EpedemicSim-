using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad()]
public class WaypointEditor
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmo(Waypoint waypoint, GizmoType gizmoType)
    {
        if((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.yellow;
        }
        else
        {
            Gizmos.color = Color.yellow * 0.5f;
        }

        Gizmos.DrawSphere(waypoint.transform.position, .1f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(waypoint.transform.position + (waypoint.transform.right * waypoint.width / 2f), 
            waypoint.transform.position - (waypoint.transform.right * waypoint.width / 2f));   

        if(waypoint.previousWaypoint != null)
        {
            Gizmos.color = Color.red;
            Vector2 offset = waypoint.transform.right * waypoint.width / 2f;
           // Vector2 offsetTo = waypoint.previousWaypoint.transform.right * waypoint.previousWaypoint.width / 2f;

            //Gizmos.DrawLine(waypoint.transform.position * offset, waypoint.previousWaypoint.transform.position + offsetTo);
        }
        if(waypoint.nextWaypoint != null)
        {
            Gizmos.color = Color.green;
            Vector2 offset = waypoint.transform.right * waypoint.width / 2f;
           // Vector2 offsetTo = waypoint.previousWaypoint.transform.right * -waypoint.previousWaypoint.width / 2f;

           // Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.nextWaypoint.transform.position + offsetTo);
        }
    }
}
