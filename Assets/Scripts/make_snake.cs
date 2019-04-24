using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class make_snake : MonoBehaviour {
	public float pointSpacing=0.4f;
	public float snake_length=50f;
	List<Vector3> points;
	public Transform Snake_head;
	EdgeCollider2D col;
	LineRenderer line;
	// Use this for initialization
	void Start () {
		line = GetComponent<LineRenderer> ();
		col = GetComponent<EdgeCollider2D> ();
		points=new List<Vector3>();
		SetPoint ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(points.Last(), Snake_head.position) > pointSpacing) {
			SetPoint ();
		}
		
	}

	public void SetPoint(){
		if (points.Count > 1) {
			col.points = points.ToArray().toVector2();
		}
			

		if (points.Count > snake_length) {
			points.RemoveAt (0);
			//pointsV2.RemoveAt (0);

			points.Add (Snake_head.position);
		//	pointsV2.Add (points.Last());
			line.positionCount = points.Count;
			line.SetPositions (points.ToArray ());
		} else {
			points.Add (Snake_head.position);
			//pointsV2.Add (points.Last());
			line.positionCount = points.Count;
			line.SetPosition (points.Count - 1, Snake_head.position);
		
		}

	}


	public void set_Width(float a){
		line.widthMultiplier = a;
	}





}
public static class MyVector3Extension
{
	public static Vector2[] toVector2 (this Vector3[] v3)
	{
		return System.Array.ConvertAll<Vector3, Vector2> (v3, getV3fromV2);
	}

	public static Vector2 getV3fromV2 (Vector3 v3)
	{
		return new Vector2 (v3.x, v3.y);
	}
}
