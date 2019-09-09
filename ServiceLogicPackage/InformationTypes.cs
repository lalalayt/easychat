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
        /// 语音请求 6
        /// </summary>
        public const int SoundRequest = 6;
        /// <summary>
        /// 接受语音 7
        /// </summary>
        public const int SoundReceive = 7;
        /// <summary>
        /// 拒绝语音 8
        /// </summary>
        public const int SoundReject = 8;
        /// <summary>
        /// 通知对方挂断语音连接或通知好友网络原因，导致视频中断 9
        /// </summary>
        public const int CloseSound = 9;
    }
}
