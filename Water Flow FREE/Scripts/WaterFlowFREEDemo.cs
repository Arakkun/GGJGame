﻿// Water Flow FREE
// Version: 1.1.2
// Compatilble: Unity 5.4.0 or higher, see more info in Readme.txt file.
//
// Developer:			Gold Experience Team (https://www.assetstore.unity3d.com/en/#!/search/page=1/sortby=popularity/query=publisher:4162)
//
// Unity Asset Store:	https://www.assetstore.unity3d.com/en/#!/content/26434
// GE Store:			https://www.ge-team.com/en/products/water-flow/
//
// Please direct any bugs/comments/suggestions to geteamdev@gmail.com

#region Namespaces
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

#endregion

// ######################################################################
// WaterFlowFREEDemo class
//
// This class handles switching demo water, displays and updates GUI of water shader.
// ######################################################################

public class WaterFlowFREEDemo : MonoBehaviour
{

	// ########################################
	// Variables
	// ########################################

	#region Variables

	// Water Simple
	public Color m_WaterSimple_Color;
	public float m_WaterSimple_UMoveSpeed;
	public float m_WaterSimple_VMoveSpeed;

	// Water game objects
	public GameObject m_SimpleWater;

	#endregion

	// ########################################
	// MonoBehaviour Functions
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.html
	// ########################################

	#region MonoBehaviour

	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html

	// Update is called every frame, if the MonoBehaviour is enabled.
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
	void Update()
	{
	}

	#endregion // MonoBehaviour

	// ########################################
	// Slider Responder functions
	// ########################################

	#region Slider Responder

	// Red color
	void OnSlider_SimpleR(float value)
	{
		m_WaterSimple_Color = new Color(value,
									m_WaterSimple_Color.g,
									m_WaterSimple_Color.b,
									m_WaterSimple_Color.a);
		m_SimpleWater.GetComponent<Renderer>().material.SetColor("_Color", m_WaterSimple_Color);
	}

	// Green color
	void OnSlider_SimpleG(float value)
	{
		m_WaterSimple_Color = new Color(m_WaterSimple_Color.r,
									value,
									m_WaterSimple_Color.b,
									m_WaterSimple_Color.a);
		m_SimpleWater.GetComponent<Renderer>().material.SetColor("_Color", m_WaterSimple_Color);
	}

	// Blue color
	void OnSlider_SimpleB(float value)
	{
		m_WaterSimple_Color = new Color(m_WaterSimple_Color.r,
									m_WaterSimple_Color.g,
									value,
									m_WaterSimple_Color.a);
		m_SimpleWater.GetComponent<Renderer>().material.SetColor("_Color", m_WaterSimple_Color);
	}

	// U speed
	void OnSlider_SimpleUSpeed(float value)
	{
		m_WaterSimple_UMoveSpeed = value;
		m_SimpleWater.GetComponent<Renderer>().material.SetFloat("_MoveSpeedU", m_WaterSimple_UMoveSpeed);
	}

	// V speed
	void OnSlider_SimpleVSpeed(float value)
	{
		m_WaterSimple_VMoveSpeed = value;
		m_SimpleWater.GetComponent<Renderer>().material.SetFloat("_MoveSpeedV", m_WaterSimple_VMoveSpeed);
	}

	#endregion // Slider Responder

	// ########################################
	// Button Responder
	// ########################################

	#region Button Responder

	// Open full verion page on Unity Asset Store
	public void OnFindMoreInFullVersion()
	{
		// http://docs.unity3d.com/ScriptReference/Application.OpenURL.html
		Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/26430");
	}

	#endregion // Button Responder
}
