﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_CameraClearFlagsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(UnityEngine.CameraClearFlags));
		L.RegVar("Skybox", get_Skybox, null);
		L.RegVar("Color", get_Color, null);
		L.RegVar("SolidColor", get_SolidColor, null);
		L.RegVar("Depth", get_Depth, null);
		L.RegVar("Nothing", get_Nothing, null);
		L.RegFunction("IntToEnum", IntToEnum);
		L.EndEnum();
		TypeTraits<UnityEngine.CameraClearFlags>.Check = CheckType;
		StackTraits<UnityEngine.CameraClearFlags>.Push = Push;
	}

	static void Push(IntPtr L, UnityEngine.CameraClearFlags arg)
	{
		ToLua.Push(L, arg);
	}

	static bool CheckType(IntPtr L, int pos)
	{
		return TypeChecker.CheckEnumType(typeof(UnityEngine.CameraClearFlags), L, pos);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Skybox(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.CameraClearFlags.Skybox");
#endif
		ToLua.Push(L, UnityEngine.CameraClearFlags.Skybox);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Color(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.CameraClearFlags.Color");
#endif
		ToLua.Push(L, UnityEngine.CameraClearFlags.Color);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SolidColor(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.CameraClearFlags.SolidColor");
#endif
		ToLua.Push(L, UnityEngine.CameraClearFlags.SolidColor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Depth(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.CameraClearFlags.Depth");
#endif
		ToLua.Push(L, UnityEngine.CameraClearFlags.Depth);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Nothing(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.CameraClearFlags.Nothing");
#endif
		ToLua.Push(L, UnityEngine.CameraClearFlags.Nothing);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.CameraClearFlags.IntToEnum");
#endif
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		UnityEngine.CameraClearFlags o = (UnityEngine.CameraClearFlags)arg0;
		ToLua.Push(L, o);
		return 1;
	}
}

