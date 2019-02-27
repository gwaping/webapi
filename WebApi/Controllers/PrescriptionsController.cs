using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using DataAccess;

namespace WebApi.Controllers
{

    public class Prescriptions
    {
        //Id: String;
        //ExpirationDate: Date;
        //ProductName: String;
        //UsesLeft: Int32;
        //Description: String;
        //IsActive: Boolean;
        //PatientId: String;

        public string Id;
        public DateTime ExpirationDate;
        public string ProductName;
        public Int32 UsesLeft;
        public string Description;
        public bool IsActive;
        public string PatientId;
    }
    
    //[Authorize]
    public class PrescriptionsController : ApiController
    {

        //static List<Prescriptions> PrescriptionList = new List<Prescriptions>() {
        //     new Prescriptions {
        //         Id = "1",
        //         ExpirationDate = DateTime.Parse("2/23/2020"),
        //         ProductName = "Product Name",
        //         UsesLeft = 1,
        //         Description = "Description",
        //         IsActive = true,
        //         PatientId = "1"
        //     },
        //      new Prescriptions {
        //         Id = "2",
        //         ExpirationDate = DateTime.Parse("2/23/2020"),
        //         ProductName = "Product Name 2",
        //         UsesLeft = 1,
        //         Description = "Description",
        //         IsActive = true,
        //         PatientId = "2"
        //     },
        // };

        private List<Prescriptions> PrescriptionList;

        // GET api/Prescription
        public IEnumerable<Prescriptions> Get()
        {
            SqliteConnection sqliteConnection = new SqliteConnection();

            string query = "Select * from prescriptions";

            DataTable datatable = sqliteConnection.QueryToDataTable(query);

            PrescriptionList = DataTableToList(datatable);

            return PrescriptionList;
        }

        // GET api/Prescriptions/5
        public Prescriptions Get(int id)
        {

            SqliteConnection sqliteConnection = new SqliteConnection();

            string query = string.Format("Select * from prescriptions where id = {0}", id);

            DataTable datatable = sqliteConnection.QueryToDataTable(query);

            if (datatable.Rows.Count > 0)
            {
                PrescriptionList = DataTableToList(datatable);

                return PrescriptionList[0];
            }

            return null;
        }

        // POST api/Prescriptions
        [BasicAuthentication]
        public void Post([FromBody]Prescriptions item)
        {

            SqliteConnection sqliteConnection = new SqliteConnection();

            
            string query = string.Format("Insert Into {0} (ExpirationDate, ProductName, UsesLeft, Description, IsActive, PatientId) " +
                                         " values ('{1}','{2}',{3},'{4}',{5},'{6}')","Prescriptions", item.ExpirationDate, item.ProductName, item.UsesLeft, item.Description, item.IsActive == true ? 1 : 0, item.PatientId);

            sqliteConnection.ExecuteNonQuery(query);

            //PrescriptionList.Add(item);

        }

        // PUT api/Prescriptions/5
        [BasicAuthentication]
        // Header: Authorization : Basic b21ib3JpOm9tYm9yaQ==
        public void Put(int id, [FromBody] Prescriptions item)
        {
            //id = id - 1;

            //var Temp = PrescriptionList[id];
            //Temp.ExpirationDate = item.ExpirationDate;
            //Temp.IsActive = item.IsActive;
            //Temp.PatientId = item.PatientId;
            //Temp.ProductName = item.ProductName;
            //Temp.UsesLeft = item.UsesLeft;
            //Temp.Description = item.Description;

            //PrescriptionList[id] = Temp;
       
        }
       

        // DELETE api/Prescriptions/5
        [BasicAuthentication]
        public void Delete(int id)
        {
            SqliteConnection sqliteConnection = new SqliteConnection();

            string query = string.Format("Delete from Prescriptions Where Id = {0}", id);

            sqliteConnection.ExecuteNonQuery(query);

        }


        private List<Prescriptions> DataTableToList(DataTable dt)
        {

            var converted = (from dtRow in dt.AsEnumerable()
                                 select new Prescriptions()
                                 {
                                     Id = Convert.ToString(dtRow["ID"]),
                                     ExpirationDate = Convert.ToDateTime(dtRow["ExpirationDate"]),
                                     ProductName =  Convert.ToString(dtRow["ProductName"]),
                                     UsesLeft = Convert.ToInt32(dtRow["UsesLeft"]),
                                     Description = Convert.ToString(dtRow["Description"]),
                                     IsActive = Convert.ToBoolean(dtRow["IsActive"]),
                                     PatientId = Convert.ToString(dtRow["PatientId"])
                                 }).ToList();

            return converted;
        }
    }
}
