/********************************************************************************
** auth:  https://github.com/HushengStudent
** date:  2018/02/01 00:04:40
** desc:  lua协议工具;
*********************************************************************************/

using LuaInterface;
using System;

namespace Framework
{
    public static class LuaNetHelper
    {
        public static void SendLuaReq(int id, LuaBuffer buffer)
        {
            NetMgr.Instance.Send(id, buffer);
        }

        public static void Send2Lua(int id, byte[] bytes)
        {
            try
            {
                LuaByteBuffer byteBuffer = new LuaByteBuffer(bytes);
                LuaUtility.CallLuaModuleMethod("Protol.ProtoProcess", "Process", id, byteBuffer);
            }
            catch (Exception e)
            {
                LogHelper.PrintError(string.Format("[LuaNetUtility]Send2Lua error,id:{0},info:{1}.", id, e.ToString()));
            }
        }
    }
}
