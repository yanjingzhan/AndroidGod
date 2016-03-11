using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AndroidManager.Models
{
    public class GameConfigInfos
    {
        [XmlAttribute("PubcenterApplicationID")]
        public string PubcenterApplicationID { get; set; }

        [XmlAttribute("PubcenterAdUnitIDs")]
        public string PubcenterAdUnitIDs { get; set; }

        [XmlAttribute("GoogleAdUnitID")]
        public string GoogleAdUnitID { get; set; }

        [XmlAttribute("GoogleFullScreenAdID")]
        public string GoogleFullScreenAdID { get; set; }

        [XmlAttribute("SurfaceAdPosition")]
        public string SurfaceAdPosition { get; set; }

        [XmlAttribute("SurfaceAdToken")]
        public string SurfaceAdToken { get; set; }

        [XmlAttribute("SmaatoPublisherID")]
        public string SmaatoPublisherID { get; set; }

        [XmlAttribute("SmaatoAdID")]
        public string SmaatoAdID { get; set; }

        [XmlAttribute("IsEnableSmaatoAdDebug")]
        public string IsEnableSmaatoAdDebug { get; set; }

        [XmlAttribute("GameName")]
        public string GameName { get; set; }
    }
}
