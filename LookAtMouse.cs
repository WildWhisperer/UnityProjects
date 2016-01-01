using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {
    public float angle;

	void Update () {
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
       
	}
}
