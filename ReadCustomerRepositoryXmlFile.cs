using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data.Models;
using System.Xml;

namespace FacadeEjer.Data.Readers
{
    class ReadCustomerRepositoryXmlFile
    {
        internal List<IComparable> GetCustomers()
        {
            try
            {
                XmlTextReader reader = new XmlTextReader("CustomersRepository.xml");

                List<IComparable> lCustomers = new List<IComparable>();

                string elementName = string.Empty;
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an element.
                            //Console.Write("<" + reader.Name);
                            //Console.WriteLine(">");
                            elementName = reader.Name;
                            if (elementName.Equals("Customer"))
                                lCustomers.Add(new Customer());
                            break;
                        case XmlNodeType.Text: //Display the text in each element.
                            //Console.WriteLine(reader.Value);
                            string value = reader.Value;
                            IComparable cust = lCustomers[lCustomers.Count - 1];
                            if (elementName.Equals("Name"))
                                ((Customer)cust).Name = value;
                            else if (elementName.Equals("Patrimony"))
                                ((Customer)cust).Patrimony = float.Parse(value);
                            break;
                        case XmlNodeType.EndElement: //Display the end of the element.
                            //Console.Write("</" + reader.Name);
                            //Console.WriteLine(">");
                            break;
                    }
                }
                reader.Close();

                return lCustomers;
            }
            catch (Exception ex)
            { throw new Exception("Error during repository load information. "+ ex.Message); }
        }
    }
}
