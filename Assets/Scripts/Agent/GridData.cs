using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridData : MonoBehaviour
{
	public Color color
	{
		get
		{
			return _renderer.material.color;
		}
		set
		{
			_renderer.material.color = value;
		}
	}

	private Renderer _renderer;

	private void Awake()
	{
		_renderer = GetComponent<Renderer>();
	}
}
