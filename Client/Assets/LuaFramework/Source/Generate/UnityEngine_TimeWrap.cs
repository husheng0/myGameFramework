﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_TimeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("Time");
		L.RegVar("time", get_time, null);
		L.RegVar("timeSinceLevelLoad", get_timeSinceLevelLoad, null);
		L.RegVar("deltaTime", get_deltaTime, null);
		L.RegVar("fixedTime", get_fixedTime, null);
		L.RegVar("unscaledTime", get_unscaledTime, null);
		L.RegVar("fixedUnscaledTime", get_fixedUnscaledTime, null);
		L.RegVar("unscaledDeltaTime", get_unscaledDeltaTime, null);
		L.RegVar("fixedUnscaledDeltaTime", get_fixedUnscaledDeltaTime, null);
		L.RegVar("fixedDeltaTime", get_fixedDeltaTime, set_fixedDeltaTime);
		L.RegVar("maximumDeltaTime", get_maximumDeltaTime, set_maximumDeltaTime);
		L.RegVar("smoothDeltaTime", get_smoothDeltaTime, null);
		L.RegVar("maximumParticleDeltaTime", get_maximumParticleDeltaTime, set_maximumParticleDeltaTime);
		L.RegVar("timeScale", get_timeScale, set_timeScale);
		L.RegVar("frameCount", get_frameCount, null);
		L.RegVar("renderedFrameCount", get_renderedFrameCount, null);
		L.RegVar("realtimeSinceStartup", get_realtimeSinceStartup, null);
		L.RegVar("captureFramerate", get_captureFramerate, set_captureFramerate);
		L.RegVar("inFixedTimeStep", get_inFixedTimeStep, null);
		L.EndStaticLibs();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_time(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.time");
#endif
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.Time.time);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_timeSinceLevelLoad(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.timeSinceLevelLoad");
#endif
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.Time.timeSinceLevelLoad);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_deltaTime(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.deltaTime");
#endif
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.Time.deltaTime);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fixedTime(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.fixedTime");
#endif
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.Time.fixedTime);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_unscaledTime(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.unscaledTime");
#endif
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.Time.unscaledTime);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fixedUnscaledTime(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.fixedUnscaledTime");
#endif
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.Time.fixedUnscaledTime);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_unscaledDeltaTime(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.unscaledDeltaTime");
#endif
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.Time.unscaledDeltaTime);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fixedUnscaledDeltaTime(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.fixedUnscaledDeltaTime");
#endif
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.Time.fixedUnscaledDeltaTime);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fixedDeltaTime(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.fixedDeltaTime");
#endif
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.Time.fixedDeltaTime);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maximumDeltaTime(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.maximumDeltaTime");
#endif
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.Time.maximumDeltaTime);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_smoothDeltaTime(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.smoothDeltaTime");
#endif
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.Time.smoothDeltaTime);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maximumParticleDeltaTime(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.maximumParticleDeltaTime");
#endif
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.Time.maximumParticleDeltaTime);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_timeScale(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.timeScale");
#endif
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.Time.timeScale);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_frameCount(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.frameCount");
#endif
		try
		{
			LuaDLL.lua_pushinteger(L, UnityEngine.Time.frameCount);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_renderedFrameCount(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.renderedFrameCount");
#endif
		try
		{
			LuaDLL.lua_pushinteger(L, UnityEngine.Time.renderedFrameCount);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_realtimeSinceStartup(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.realtimeSinceStartup");
#endif
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.Time.realtimeSinceStartup);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_captureFramerate(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.captureFramerate");
#endif
		try
		{
			LuaDLL.lua_pushinteger(L, UnityEngine.Time.captureFramerate);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_inFixedTimeStep(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.inFixedTimeStep");
#endif
		try
		{
			LuaDLL.lua_pushboolean(L, UnityEngine.Time.inFixedTimeStep);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fixedDeltaTime(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.fixedDeltaTime");
#endif
		try
		{
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Time.fixedDeltaTime = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maximumDeltaTime(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.maximumDeltaTime");
#endif
		try
		{
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Time.maximumDeltaTime = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maximumParticleDeltaTime(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.maximumParticleDeltaTime");
#endif
		try
		{
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Time.maximumParticleDeltaTime = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_timeScale(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.timeScale");
#endif
		try
		{
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Time.timeScale = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_captureFramerate(IntPtr L)
	{
#if UNITY_EDITOR
        ToluaProfiler.AddCallRecord("UnityEngine.Time.captureFramerate");
#endif
		try
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Time.captureFramerate = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

