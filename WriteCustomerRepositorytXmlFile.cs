using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data.Models;
using System.Xml;
using System.IO;

namespace FacadeEjer.Data.Writers
{
    class WriteCustomerRepositorytXmlFile
    {
        internal void SetCustomers(CustomersRepository customerRepo)
        {
            string fileName = "CustomersRepository.xml";

            using (XmlWriter writer = XmlWriter.Create(File.Create(fileName)) )
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Repository");

                foreach (Customer c in (List<Customer>)customerRepo.GetElements())
                {
                    writer.WriteStartElement("Customer");

                    writer.WriteElementString("Name", c.Name);
                    writer.WriteElementString("Patrimony", c.Patrimony.ToString());

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

        }
    }
}
