using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions {
	// -----------------
	// Vector Math
	// -----------------

	// Piecewise Multiplication

	public static Vector2 MultiplyComponents(Vector2 v1, Vector2 v2){
		return new Vector2 (v1.x * v2.x, v1.y * v2.y);
	}

	public static Vector3 MultiplyComponents(Vector3 v1, Vector3 v2){
		return new Vector3 (v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
	}

	public static Vector4 MultiplyComponents(Vector4 v1, Vector4 v2){
		return new Vector4 (v1.x * v2.x, v1.y * v2.y, v1.z * v2.z, v1.w * v2.w);
	}

	// Piecewise MultiplicationExtension Methods

	public static Vector2 ComponentsTimes(this Vector2 v1, Vector2 v2){
		return new Vector2 (v1.x * v2.x, v1.y * v2.y);
	}

	public static Vector3 ComponentsTimes(this Vector3 v1, Vector3 v2){
		return new Vector3 (v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
	}

	public static Vector4 ComponentsTimes(this Vector4 v1, Vector4 v2){
		return new Vector4 (v1.x * v2.x, v1.y * v2.y, v1.z * v2.z, v1.w * v2.w);
	}

	// Piecewise Division

	public static Vector2 DivideComponents(Vector2 v1, Vector2 v2){
		return new Vector2 (v1.x / v2.x, v1.y / v2.y);
	}

	public static Vector3 DivideComponents(Vector3 v1, Vector3 v2){
		return new Vector3 (v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
	}

	public static Vector4 DivideComponents(Vector4 v1, Vector4 v2){
		return new Vector4 (v1.x / v2.x, v1.y / v2.y, v1.z / v2.z, v1.w / v2.w);
	}

	// Piecewise Division Extension Methods

	public static Vector2 ComponentsDividedBy (this Vector2 v1, Vector2 v2){
		return new Vector2 (v1.x / v2.x, v1.y / v2.y);
	}

	public static Vector3 ComponentsDividedBy (this Vector3 v1, Vector3 v2){
		return new Vector3 (v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
	}

	public static Vector4 ComponentsDividedBy (this Vector4 v1, Vector4 v2){
		return new Vector4 (v1.x / v2.x, v1.y / v2.y, v1.z / v2.z, v1.w / v2.w);
	}

	// -----------------
	// Vector Conversion
	// -----------------

	public static Vector2 ToVec2(Vector3 v){ return new Vector2(v.x, v.y); }
	public static Vector2 ToVec2(Vector4 v){ return new Vector2(v.x, v.y); }

	public static Vector3 ToVec3(Vector2 v){ return new Vector3(v.x, v.y, 0.0f); }
	public static Vector3 ToVec3(Vector4 v){ return new Vector3(v.x, v.y, v.z); }

	public static Vector4 ToVec4Point(Vector2 v){ return new Vector4(v.x, v.y, 0.0f, 1.0f); }
	public static Vector4 ToVec4Point(Vector3 v){ return new Vector4(v.x, v.y, v.z, 1.0f); }

	public static Vector4 ToVec4Ray(Vector2 v){ return new Vector4(v.x, v.y, 0.0f, 0.0f); }
	public static Vector4 ToVec4Ray(Vector3 v){ return new Vector4(v.x, v.y, v.z, 0.0f); }

	// 		Extension Methods
	public static Vector2 Vec2(this Vector3 v){ return new Vector2(v.x, v.y); }
	public static Vector2 Vec2(this Vector4 v){ return new Vector2(v.x, v.y); }

	public static Vector3 Vec3(this Vector2 v){ return new Vector3(v.x, v.y, 0.0f); }
	public static Vector3 Vec3(this Vector4 v){ return new Vector3(v.x, v.y, v.z); }

	public static Vector4 Vec4Point(this Vector2 v){ return new Vector4(v.x, v.y, 0.0f, 1.0f); }
	public static Vector4 Vec4Point(Vector3 v){ return new Vector4(v.x, v.y, v.z, 1.0f); }

	public static Vector4 Vec4Ray(this Vector2 v){ return new Vector4(v.x, v.y, 0.0f, 0.0f); }
	public static Vector4 Vec4Ray(this Vector3 v){ return new Vector4(v.x, v.y, v.z, 0.0f); }

}
