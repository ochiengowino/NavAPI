using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services;
using API.ochiengowino;
using API.Context;
using API.Models;

namespace API.Controllers
{

    public class NavController : ApiController
    {

        // private readonly NavContext _navcontext;
        //private LoanApplicationsEntities1 db = new LoanApplicationsEntities1();
        private LoanApplicationEntities db = new LoanApplicationEntities();
        LoanApplicationList_Service _ws = new LoanApplicationList_Service();
        LoanApplicationList _client = new LoanApplicationList();
        
        //SqlConnection conn = new SqlConnection("Server=OCHIENGOWINO\\NAVDEMO; Database=LoanApplications; Trusted_Connection=True; MultipleActiveResultSets=True; TrustServerCertificate=True");
        /*   public NavController(NavContext navcontext)
           {
               _navcontext = navcontext;
           }*/
        public NavController()
        {
           // LoanApplicationList_Service _ws = new LoanApplicationList_Service();
            _ws.Url = "http://ochiengowino:3332/CapitalSaccoInstance/WS/CAPITAL%20SACCO/Page/LoanApplicationList";
            //ws.UseDefaultCredentials = true;
            _ws.Credentials = new NetworkCredential("ochiengowinoben", "D3271n3d4gr87n322");
        }


        [HttpGet]
        public IHttpActionResult Get()
        {
            

            //var dat = db.LoanApplications.ToList();
            
            //var name = client.Member_Name;

            //var data = ws.Read(client.Member_Name);
            // var filter = new LoanApplicationList_Filter();
            //filter.Field = LoanApplicationList_Fields.Member_Name;
            //var items = ws.ReadMultiple(null, "", 5);

            List<LoanApplicationList_Filter> filters = new List<LoanApplicationList_Filter>();
            LoanApplicationList_Filter filter = new LoanApplicationList_Filter
            {
                Field = LoanApplicationList_Fields.Member_Name,
                Criteria = "*"
            };

            //filters.Add(filter);

            var list = _ws.ReadMultiple(filters.ToArray(), "", 0);

            foreach (var item in list)
            {
                var newEntry = new LoanApplication
                {

                    Loan_No = item.Loan_No,
                    Application_Date = item.Application_Date,
                    Loan_Product_Type = item.Loan_Product_Type,
                    Loan_Product_Type_Name = item.Loan_Product_Type_Name,
                    Member_No = item.Member_No,
                    Member_Name = item.Member_Name,
                    Requested_Amount = item.Requested_Amount,
                    Approved_Amount = item.Approved_Amount,
                    Interest = item.Interest,
                    Status = (int)item.Status,
                    RecID = item.RecID,
                    Captured_By = item.Captured_By,
                    Global_Dimension_1_Code = item.Global_Dimension_1_Code,
                    Global_Dimension_2_Code = item.Global_Dimension_2_Code,
                    Staff_No = item.Staff_No
                };

                db.LoanApplications.Add(newEntry);

            }
            db.SaveChanges();
            var successState = new
            {
                MessageCode = "200",
                Message = "Successfully received data"
            };

            return Ok(successState);
        }


        [HttpPost]
        public IHttpActionResult Post()
        {
            var entries = db.LoanApplications.ToList();
            try
            {

                /*  var loan_no = _client.Loan_No;
                 var application_date = _client.Application_Date;
                 var loan_prod_type = _client.Loan_Product_Type;
                 var member_no = _client.Member_No;
                 var member_name = _client.Member_Name;
                 var req_amount = _client.Requested_Amount;
                 var appr_amount = _client.Application_Date;
                 var interest = _client.Interest;
                 var status = _client.Status;
                 var recID = _client.RecID;
                 var prduct_type_name = _client.Loan_Product_Type_Name;*/



                //loan_no = "LBN00096";
                // member_name = "John Doe";
                //application_date = (DateTime)entry.Application_Date;
                // prduct_type_name = "Development Loan";
                List<object> LoanApp = new List<object>();
                if (entries != null)
                {
                   // var clientList = new List<string>();
                    foreach (var entry in entries)
                    {
                        if (entry.Id == 8)
                        {
                            var loanList = new LoanApplicationList
                            {
                                Member_Name = entry.Member_Name,
                                Member_No = entry.Member_No,
                                Application_Date = (DateTime)entry.Application_Date,
                                Loan_No = "LBN00097",
                                Loan_Product_Type = entry.Loan_Product_Type,
                                Loan_Product_Type_Name = entry.Loan_Product_Type_Name,
                                Requested_Amount = (decimal)entry.Requested_Amount,
                                Approved_Amount = (decimal)entry.Approved_Amount,
                                Interest = (decimal)entry.Interest,
                                //RecID = entry.RecID,
                                // Status = (string)entry.Status
                            };
                           // LoanApp.Add(loanList);
                            //loan_no = "LBN00096";
                            // _client.Loan_No = entry.Loan_No;
                           /* _client.Member_Name = entry.Member_Name;
                            _client.Member_No = entry.Member_No;*/
                           // _client.Loan_Product_Type = entry.Loan_Product_Type;
                           // _client.Requested_Amount = (decimal)entry.Requested_Amount;
                            /*       _client.Application_Date = (DateTime)entry.Application_Date;
                                  _client.Loan_Product_Type = entry.Loan_Product_Type;
                                  _client.Loan_Product_Type_Name = entry.Loan_Product_Type_Name;
                                  _client.Requested_Amount = (decimal)entry.Requested_Amount;
                                  _client.Approved_Amount = (decimal)entry.Approved_Amount;
                                  _client.Member_No = "1181054";*/
                          //  _ws.Create(ref _client);

                             _ws.Create(ref loanList);
                            return Ok(loanList);
                        }


                    }
                    // _ws.Create(ref _client);
                    //_ws.CreateMultiple(entries);
                    return Ok("Data sent to nav");

                }
                else
                {
                    return BadRequest("No data found in the DB");
                }

                //return Ok(_client);
            }
            catch (Exception ex)
            {

                return BadRequest($"An error occurred: {ex.Message}");
               
            }
       
        }
    }
}
