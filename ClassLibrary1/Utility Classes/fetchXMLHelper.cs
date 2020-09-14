using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace NHG.Plugins.DeveloperTest
{
    public class FetchXMLHelper
    {
        // For cleaning out of escape characters from string parameters of fetch xml 
        public string CleanXMLOfEscapeCharacters(string xmlString)
        {
            string procssedXMLString = xmlString;

            procssedXMLString = procssedXMLString.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");

            return procssedXMLString;

        }

        // For Returning Paged List of Entities
        public List<Entity> ReturnPagedListOfEntities(OrganizationServiceProxy service, string fetchXmlExpression)
        {
            bool continueProcessing = true;
            int fetchCount = 5000;
            int pageNumber = 1;
            string pagingCookie = null;

            List<Entity> pagedEntityList = new List<Entity>();

            while (continueProcessing == true)
            {
                string xmlRequest = CreateXml(fetchXmlExpression, pagingCookie, pageNumber, fetchCount);

                FetchExpression getFetch = new FetchExpression(xmlRequest);
                EntityCollection entityCollectionRecords = service.RetrieveMultiple(getFetch);

                pagedEntityList.AddRange(entityCollectionRecords.Entities);

                if (entityCollectionRecords.MoreRecords == true)
                {
                    pageNumber++;
                }
                else
                {
                    continueProcessing = false;
                }
            }

            return pagedEntityList;
        }

        #region Non Public Methods

        string CreateXml(string xml, string cookie, int page, int count)
        {
            StringReader stringReader = new StringReader(xml);
            XmlTextReader reader = new XmlTextReader(stringReader);

            XmlDocument doc = new XmlDocument();
            doc.Load(reader);

            return CreateXml(doc, cookie, page, count);
        }
        string CreateXml(XmlDocument doc, string cookie, int page, int count)
        {
            XmlAttributeCollection attrs = doc.DocumentElement.Attributes;

            if (cookie != null)
            {
                XmlAttribute pagingAttr = doc.CreateAttribute("paging-cookie");
                pagingAttr.Value = cookie;
                attrs.Append(pagingAttr);
            }

            XmlAttribute pageAttr = doc.CreateAttribute("page");
            pageAttr.Value = System.Convert.ToString(page);
            attrs.Append(pageAttr);

            XmlAttribute countAttr = doc.CreateAttribute("count");
            countAttr.Value = System.Convert.ToString(count);
            attrs.Append(countAttr);

            StringBuilder sb = new StringBuilder(1024);
            StringWriter stringWriter = new StringWriter(sb);

            XmlTextWriter writer = new XmlTextWriter(stringWriter);
            doc.WriteTo(writer);
            writer.Close();

            return sb.ToString();
        }

        #endregion

    }

}

