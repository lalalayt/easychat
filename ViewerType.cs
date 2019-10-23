using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat2._0.ServiceLogicPackage
{ 
    public enum ViewerType
    {
        /// <summary>
        /// 空
        /// </summary>
        None,
        /// <summary>
        /// 视频请求
        /// </summary>
        VideoRequest,
        /// <summary>
        /// 视频连接  
        /// </summary>
        VideoView
    }

    interface IViewer
    {
        void Close();
        ViewerType Type { get; }
    }
}
