﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_BoxColliderWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.BoxCollider), typeof(UnityEngine.Collider));
		L.RegFunction("New", _CreateUnityEngine_BoxCollider);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("center", get_center, set_center);
		L.RegVar("size", get_size, set_size);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_BoxCollider(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.BoxCollider.ctor");
#endif
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityEngine.BoxCollider obj = new UnityEngine.BoxCollider();
				ToLua.PushSealed(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.BoxCollider.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.BoxCollider.op_Equality");
#endif
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_center(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.BoxCollider.center");
#endif
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.BoxCollider obj = (UnityEngine.BoxCollider)o;
			UnityEngine.Vector3 ret = obj.center;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index center on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_size(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.BoxCollider.size");
#endif
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.BoxCollider obj = (UnityEngine.BoxCollider)o;
			UnityEngine.Vector3 ret = obj.size;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index size on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_center(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.BoxCollider.center");
#endif
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.BoxCollider obj = (UnityEngine.BoxCollider)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.center = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index center on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_size(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.BoxCollider.size");
#endif
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.BoxCollider obj = (UnityEngine.BoxCollider)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.size = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index size on a nil value");
		}
	}
}

