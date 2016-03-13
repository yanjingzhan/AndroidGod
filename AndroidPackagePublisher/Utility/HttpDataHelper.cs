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

        public static PushGameInfoModel GetOneGameInfoAndChangeStateRandomForDev(string state, string newstate)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/GamePusher.aspx?action=GetOneGameInfoAndChangeStateRandomForDev&state={0}&newstate={1}", state, newstate)));

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
