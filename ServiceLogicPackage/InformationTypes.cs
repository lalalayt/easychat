using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat2._0.ServiceLogicPackage
{
    /// <summary>
    /// 自定义信息的类型
    /// </summary>
    public static class InformationTypes
    {
        /// <summary>
        /// 聊天信息 0
        /// </summary>
        public const int Chat = 0;
        /// <summary>
        /// 视频请求 1
        /// </summary>
        public const int VideoRequest = 1;
        /// <summary>
        /// 回复视频请求的结果 2
        /// </summary>
        public const int VideoResult = 2;
        /// <summary>
        /// 通知对方 挂断 视频连接 3
        /// </summary>
        public const int CloseVideo = 3;
        /// <summary>
        /// 通知好友 网络原因，导致 视频中断 
        /// </summary>
        public const int NetReasonCloseVideo = 4;
    }
}
