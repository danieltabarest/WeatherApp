using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService2
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class dwml
    {

        private string latLonListField;

        private string cityNameListField;

        private decimal versionField;

        /// <remarks/>
        public string latLonList
        {
            get
            {
                return this.latLonListField;
            }
            set
            {
                this.latLonListField = value;
            }
        }

        /// <remarks/>
        public string cityNameList
        {
            get
            {
                return this.cityNameListField;
            }
            set
            {
                this.cityNameListField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }


}
