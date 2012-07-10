using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace System.ServiceModel.Syndication
{
    [XmlRoot("opml")]
    public class Opml
    {
        public OpmlHead head;
        public OpmlBody body;

        /// <summary>
        /// Initializes a new instance of the <see cref="Opml"/> class.
        /// </summary>
        public Opml()
        {
            body = new OpmlBody();
            head = new OpmlHead();
        }
    }

    [XmlRoot("body")]
    public class OpmlBody
    {
        [XmlElement("outline")]
        public OpmlOutline[] outline;
    }

    [XmlRoot("head")]
    public class OpmlHead
    {
        [XmlAttribute]
        public string title;
        [XmlAttribute]
        public string dateCreated;
        [XmlAttribute]
        public string dateModified;
        [XmlAttribute]
        public string ownerName;
        [XmlAttribute]
        public string ownerEmail;
        [XmlAttribute]
        public string ownerId;
        [XmlAttribute]
        public string docs;
        [XmlAttribute]
        public string expansionState;
        [XmlAttribute]
        public string vertScrollState;
        [XmlAttribute]
        public string windowTop;
        [XmlAttribute]
        public string windowLeft;
        [XmlAttribute]
        public string windowBottom;
        [XmlAttribute]
        public string windowRight;
    }

    [XmlRoot("outline")]
    public class OpmlOutline
    {
        private string _text;
        [XmlAttribute]
        public string title;
        private string _type;
        private string _url; // when type == link, this must not be null
        [XmlAttribute]
        public string description;
        [XmlAttribute]
        public string xmlUrl;
        [XmlAttribute]
        public string htmlUrl;
        [XmlAttribute]
        public string language;
        [XmlElement("outline")]
        public OpmlOutline[] outline;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpmlOutline"/> class.
        /// </summary>
        public OpmlOutline()
        {
            //Text = inText; //Use the property so that it can check the values.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpmlOutline"/> class.
        /// </summary>
        /// <param name="inText">The in text.</param>
        public OpmlOutline(string inText)
        {
            Text = inText; //Use the property so that it can check the values.
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [XmlAttribute("text")]
        public String Text
        {
            get { return _text; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Outline Text must not be null");
                }

                if (value.Length == 0)
                {
                    throw new ArgumentException("Outline Text must not be blank");
                }

                _text = value;
            }
        }

        [XmlAttribute("type")]
        public String Type
        {
            get { return _type; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Type must not be null");
                }

                if (value.Length == 0)
                {
                    throw new ArgumentException("Type must not be blank");
                }

                if (value.ToUpper() == "LINK")
                {
                    if (Url == null)
                    {
                        throw new ArgumentException("Url must not be Null when Type=Link");
                    }
                    else if (Url.Length == 0)
                    {
                        throw new ArgumentException("Url must not be blank when Type=Link");
                    }
                }
                _type = value;
            }
        }

        [XmlAttribute]
        public string Url
        {
            get { return _url; }
            set
            {
                if (_type != null)
                {
                    if (_type.ToUpper() == "LINK" && value == null)
                    {
                        throw new ArgumentException("Url must not be Null when Type=Link");
                    }
                    else if (value.Length == 0)
                    {
                        throw new ArgumentException("Url must not be blank when Type=Link");
                    }
                    else
                    {
                        _url = value;
                    }
                }
                else
                {
                    _url = value;
                }
            }
        }
    }
}
