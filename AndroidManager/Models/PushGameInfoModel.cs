using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndroidManager.Models
{
    public class PushGameInfoModel
    {
        public string GameName;
        public string Version;

        /// <summary>
        /// 未就绪
        /// 制作中
        /// 待提交
        /// 开发中
        /// 待审核
        /// 被拒绝
        /// 已上架
        /// 不可用
        /// 待确认
        /// </summary>
        public string State;

        public string GameID;
        public string PusherName;
        public string SurfaceAccountID;
        public string SurfaceAdID;
        public string GoogleBanner;
        public string GoogleChaping;
        public string PubcenterAppID;
        public string PubcenterAdID;
        public string AddTime;
        public string UpdateTime;
        public string DevAccount;
        public string DevPassword;

        public string GameDetails;
        public string LogoPath;
        public string BackImagePath;
        public string SourceType;

        public string ID;

        public string FileName;
        public string FixedGameName;
        public string AdName;

        public string RealDevAccount;
        public string RealDevPassword;
    }
}
