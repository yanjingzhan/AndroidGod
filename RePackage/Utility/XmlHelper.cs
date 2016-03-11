using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RePackage.Utility
{
    public class XmlHelper
    {
        public static void SetAndroidManifest(string oldXml, string newXml)
        {
            XmlDocument doc_old = new XmlDocument();
            doc_old.Load(oldXml);

            XmlElement rootElem_old = doc_old.DocumentElement;

            XmlNodeList activityList_old = rootElem_old.SelectNodes("application/activity");
            string screenOrientation = string.Empty;
            foreach (XmlElement item in activityList_old)
            {
                if (!string.IsNullOrWhiteSpace(item.GetAttribute("android:screenOrientation")))
                {
                    screenOrientation = item.GetAttribute("android:screenOrientation");
                    break;
                }
            }

            XmlNodeList usesPermissionList_old = rootElem_old.SelectNodes("uses-permission");
            List<string> usesPermissionValueList_old = new List<string>();
            foreach (XmlElement item in usesPermissionList_old)
            {
                if (!string.IsNullOrWhiteSpace(item.GetAttribute("android:name")))
                {
                    usesPermissionValueList_old.Add(item.GetAttribute("android:name"));
                }
            }

            XmlNodeList usesFeature_old = rootElem_old.SelectNodes("uses-feature");
            List<string> usesFeatureValueList_old = new List<string>();
            foreach (XmlElement item in usesFeature_old)
            {
                if (!string.IsNullOrWhiteSpace(item.GetAttribute("android:name")))
                {
                    usesFeatureValueList_old.Add(item.GetAttribute("android:name"));
                }
            }

            XmlDocument doc_new = new XmlDocument();
            doc_new.Load(newXml);
            XmlElement rootElem_new = doc_new.DocumentElement;

            if (!string.IsNullOrWhiteSpace(screenOrientation))
            {
                XmlNodeList activityList_new = rootElem_new.SelectNodes("application/activity");
                foreach (XmlElement item in activityList_new)
                {
                    if (!string.IsNullOrWhiteSpace(item.GetAttribute("android:screenOrientation")))
                    {
                        item.SetAttribute("android:screenOrientation", screenOrientation);
                        break;
                    }
                }
            }

            XmlNodeList usesPermissionList_new = rootElem_new.SelectNodes("uses-permission");
            List<string> usesPermissionValueList_new = new List<string>();
            foreach (XmlElement item in usesPermissionList_new)
            {
                if (!string.IsNullOrWhiteSpace(item.GetAttribute("android:name")))
                {
                    usesPermissionValueList_new.Add(item.GetAttribute("android:name"));
                }
            }
            XmlNodeList usesFeature_new = rootElem_new.SelectNodes("uses-feature");
            List<string> usesFeatureValueList_new = new List<string>();
            foreach (XmlElement item in usesFeature_new)
            {
                if (!string.IsNullOrWhiteSpace(item.GetAttribute("android:name")))
                {
                    usesFeatureValueList_new.Add(item.GetAttribute("android:name"));
                }
            }

            foreach (string s in usesPermissionValueList_old)
            {
                if (!usesPermissionValueList_new.Contains(s))
                {
                    XmlElement t = doc_new.CreateElement("uses-permission");
                    t.SetAttribute("name", "http://schemas.android.com/apk/res/android", s);
                    rootElem_new.AppendChild(t);
                }
            }

            foreach (string s in usesFeatureValueList_old)
            {
                if (!usesFeatureValueList_new.Contains(s))
                {
                    XmlElement t = doc_new.CreateElement("uses-feature");
                    t.SetAttribute("name", "http://schemas.android.com/apk/res/android", s);
                    t.SetAttribute("required", "http://schemas.android.com/apk/res/android", "false");
                    rootElem_new.AppendChild(t);
                }
            }

            doc_new.Save(newXml);
        }
    }
}
