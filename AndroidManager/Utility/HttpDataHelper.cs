using AndroidManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AndroidManager.Utility
{
    public class HttpDataHelper
    {
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

        public static void UploadImage(string imagePath)
        {
            WebClient wc = new WebClient();
            try
            {
                wc.UploadFile("http://gamemanager.pettostudio.net/UploadManager.aspx", imagePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdatePushGameInfoByID(string gameName, string surfaceAccountID, string surfaceAdID,
                                          string pubcenterAppID, string pubcenterAdID,
                                          string googleBanner, string googleChaping, string logoPath,
                                          string backImagePath, string Id, string state, string devaccount, string devpassword, string sourceType)
        {
            WebClient wc = new WebClient();
            try
            {
                devpassword = HttpUtility.UrlEncode(devpassword);

                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/GamePusher.aspx?action=UpdatePushGameInfoByID&Id={0}&gameName={1}&surfaceAccountID={2}&surfaceAdID={3}&pubcenterAppID={4}&pubcenterAdID={5}&googleBanner={6}&googleChaping={7}&logoPath={8}&backImagePath={9}&state={10}&devaccount={11}&devpassword={12}&sourceType={13}",
                                                            Id.Trim(), gameName.Trim(), surfaceAccountID.Trim(), surfaceAdID.Trim(), pubcenterAppID.Trim(), pubcenterAdID.Trim(),
                                                            googleBanner.Trim(), googleChaping.Trim(), logoPath.Trim(), backImagePath.Trim(), state.Trim(), devaccount.Trim(), devpassword.Trim(), sourceType.Trim())));

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

    }
}
