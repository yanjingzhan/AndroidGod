using AndroidPackagePublisher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AndroidPackagePublisher.Utility
{
    public class HttpDataHelper
    {
        public static List<string> GetKeyWords(int count)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/GamePusher.aspx?action=getkeywords&count={0}", count)));

                List<string> devAccountList = JsonHelper.DeserializeObjectFromJson<List<string>>(dataString);
                if (devAccountList == null || devAccountList.Count == 0)
                {
                    throw new Exception("没有获取到开发者信息");
                }
                else
                {
                    return devAccountList;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static PushGameInfoModel GetOneGameInfoAndChangeStateRandomForDevAmazon(string state, string newstate)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/GamePusher.aspx?action=GetOneGameInfoAndChangeStateRandomForDevAmazon&state={0}&newstate={1}", state, newstate)));

                PushGameInfoModel result = JsonHelper.DeserializeObjectFromJson<PushGameInfoModel>(dataString);
                if (result == null)
                {
                    throw new Exception("没有获取到开发者信息");
                }
                else
                {
                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static void DevSuccessedByDreamSparkAmazon(string id, string realDevAccount, string realDevPassword)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/GamePusher.aspx?action=DevSuccessedByDreamSparkAmazon&Id={0}&realDevAccount={1}&realDevPassword={2}",
                         id, realDevAccount, realDevPassword)));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateDreamSparkerByDevAccount(string devAccount, string state)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/DreamSparker.aspx?action=UpdateDreamSparkerByDevAccount&devaccount={0}&state={1}",
                                                            devAccount, state)));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdatePushGameStateInfoByID(string state, string Id)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/GamePusher.aspx?action=UpdatePushGameInfoByID&Id={0}&State={1}",
                         Id, state)));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static PushGameInfoModel GetOneGameInfoAndChangeStateRandom(string state, string newstate)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/GamePusher.aspx?action=GetOneGameInfoAndChangeStateRandom&state={0}&newstate={1}", state, newstate)));

                PushGameInfoModel result = JsonHelper.DeserializeObjectFromJson<PushGameInfoModel>(dataString);
                if (result == null)
                {
                    throw new Exception("没有获取到开发者信息");
                }
                else
                {
                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
