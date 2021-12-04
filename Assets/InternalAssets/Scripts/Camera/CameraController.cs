using System;
using UnityEngine;
using UnityEngine.U2D;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private UnityEngine.Experimental.Rendering.Universal.PixelPerfectCamera _pixelPerfectCamera;
	
	private void Awake()
	{
		_pixelPerfectCamera = GetComponent<UnityEngine.Experimental.Rendering.Universal.PixelPerfectCamera>();
		
	}

	private void Start()
	{
		var display = Display.main;
		_pixelPerfectCamera.refResolutionX = display.renderingWidth;
		_pixelPerfectCamera.refResolutionY = display.renderingHeight;
		_pixelPerfectCamera.assetsPPU = display.renderingWidth / 15;
	}
}
