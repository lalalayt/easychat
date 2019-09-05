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
        /// 接受视频 2
        /// </summary>
        public const int VideoReceive = 2;
        /// <summary>
        /// 拒绝视频 3
        /// </summary>
        public const int VideoReject = 3;
        /// <summary>
        /// 通知对方 挂断 视频连接 4
        /// </summary>
        public const int CloseVideo = 4;
        /// <summary>
        /// 通知好友 网络原因，导致 视频中断 
        /// </summary>
        public const int NetReasonCloseVideo = 5;
        /// <summary>
        /// 通知自己 挂断 视频连接 6
        /// </summary>
        public const int SelfCloseVideo = 6;
    }
}
