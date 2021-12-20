using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using CardManagement.Domain.Entities;
using CardManagement.Domain.Enumerations;
using ExcelDataReader;

namespace CardManagement.Domain.Services
{
    public class CsvService : ICsvService
    {
        public IEnumerable<Card> ProcessCsvFile(Stream stream)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            try
            {
                var cards = new List<Card>();

                var excelReader = ExcelReaderFactory.CreateReader(stream);
                var dataSet = excelReader.AsDataSet();
                var i = 0;

                foreach (DataTable table in dataSet.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        if (i > 0)
                        {
                            var data = dr.ItemArray.Select(o => o.ToString()).ToList();
                            string Id = data[0],
                                cardNum = data[1],
                                validStatus = data[2],
                                stateOfCard = data[3],
                                type = data[4];
                            
                            var newCard = new Card()
                            {
                                CardNumber = cardNum,
                                State = State.Inactive,
                                Valid = false,
                                Type = type
                            };

                            cards.Add(newCard);
                        }
                        i++;

                    }

                }


                // excelReader.Close();
                // stream.Close();

                return default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private Dictionary<string, object> GetDetails(IList<object> dr,
                                                      Dictionary<object, int> productMap,
                                                      IEnumerable<string> csvHeaders)
        {
            var headers = new List<string>(csvHeaders);
            var mappedDictionary = new Dictionary<string, object>();
            var productMapCount = productMap.Values.Count;
            var productMapValues = productMap.Values.ToList();
            var i = 0;

            while (i < productMapCount)
            {
                dr.RemoveAt(productMapValues[i]);
                dr.Insert(productMapValues[i], null);
                headers.RemoveAt(productMapValues[i]);
                headers.Insert(productMapValues[i], null);

                i++;
            }

            var keys = headers.Where(x => x != null).TakeLast(2).ToList();
            var values = dr.Where(x => x != null).TakeLast(2).ToList();

            for (int j = 0; j < keys.Count(); j++)
            {
                mappedDictionary[keys[j]] = values[j];
            }

            return mappedDictionary;
        }

        public IList<string> GetPropertiesNameOfClass(object propertyObject)
        {
            var propertyList = new List<string>();

            if (propertyObject != null)
            {
                propertyList.AddRange(propertyObject.GetType().GetProperties().Select(property => property.Name));
            }

            return propertyList;
        }
    }

    public interface ICsvService
    {
        IList<string> GetPropertiesNameOfClass(object propertyObject);
        IEnumerable<Card> ProcessCsvFile(Stream stream);
    }
}