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
using System.ServiceModel;

namespace API.Controllers
{

    public class NavController : ApiController
    {
        private LoanApplicationEntities db = new LoanApplicationEntities();
        LoanApplicationList_Service _ws = new LoanApplicationList_Service();
        LoanApplicationList _client = new LoanApplicationList();
        
        public NavController()
        {
        
            _ws.Url = "http://ochiengowino:3332/CapitalSaccoInstance/WS/CAPITAL%20SACCO/Page/LoanApplicationList";
           
            _ws.Credentials = new NetworkCredential("ochiengowinoben", "D3271n3d4gr87n322");
        }


        [HttpGet]
        [Route("api/getnav")]
        public IHttpActionResult Get()
        {
            List<LoanApplicationList_Filter> filters = new List<LoanApplicationList_Filter>();
         

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

             return Ok(list);
            //return Ok(successState);
        }


        [HttpPost]
        [Route("api/postnav")]
        public IHttpActionResult Post()
        {
            var entries = db.LoanApplications.ToList();
            try
            {
               /* List<object> LoanApp = new List<object>();*/
                if (entries != null)
                {
                   // var clientList = new List<string>();
                    foreach (var entry in entries)
                    {
                        if (entry.Id == 3)
                        {
                            var loanList = new LoanApplicationList
                            {
                                Member_Name = entry.Member_Name,
                                Member_No = entry.Member_No,
                                Application_Date = (DateTime)entry.Application_Date,
                                Loan_No = "LBN000100",
                                Loan_Product_Type = entry.Loan_Product_Type,
                                Loan_Product_Type_Name = entry.Loan_Product_Type_Name,
                                Requested_Amount = (decimal)entry.Requested_Amount,
                                Approved_Amount = (decimal)entry.Approved_Amount,
                                Interest = (decimal)entry.Interest,
                                RecID = entry.RecID,
                                Status =(Status) 1
                            };
                      

                             _ws.Create(ref loanList);
                            return Ok(loanList);
                        }
                    }
                   
                    return Ok("Data sent to nav");

                }
                else
                {
                    return BadRequest("No data found in the DB");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"An error occurred: {ex.Message}");
               
            }
       
        }

        [HttpPost]
        [Route("api/updatenav")]
        public IHttpActionResult updateNav() 
        {
            try
            {
               
                LoanApplicationList cl = _ws.Read("LBN00014");
           
                cl.Member_Name = "Leon Austine";
                cl.Loan_Product_Type = "L01";
                //cl.Loan_Product_Type_Name = "Development Loan";
               // cl.Member_No = "12345677";
                cl.Requested_Amount = 5000000;
                cl.Approved_Amount = 4000000;
               // cl.Interest = (decimal)12.00;
                _ws.Update(ref cl);
        
                return Ok(cl);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
            
        }
    }
}
