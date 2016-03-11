using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndroidManager.Models
{
    public class DreamSparkerModel
    {
        public string ID;
        public string Account;
        public string Password;
        public string NewPassword;

        /// <summary>
        /// 新注册
        /// 空闲中
        /// 已绑定
        /// 已获取
        /// 已激活
        /// 已作废
        /// </summary>
        public string State;

        public string DevAccount;
        public string DevPassword;
        public string SourceType;
        public string AddTime;
        public string UpdateTime;

        public string Token;
        public string Domain;
        public string PushCount;
    }
}
