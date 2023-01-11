using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using test1.Models;


namespace test1.Controllers
{
    public class RoomController : Controller
    {

        private readonly ConnectionStringClass _cc;



        SqlCommand comm = new SqlCommand();
        SqlConnection con = new SqlConnection();
        List<Address> addresses = new List<Address>();
        SqlDataReader dr;
        private readonly ILogger<RoomController> _logger;

        public RoomController(ILogger<RoomController> logger, ConnectionStringClass cc)
        {
            _logger = logger;
            con.ConnectionString = test1.Properties.Resources.ConnectionString;
            _cc = cc;
        }
        // GET: RoomController
        public ActionResult Index()
        {
            fetchData();
            return View(addresses);
        }
        private void fetchData()
        {
            if (addresses.Count > 0)
            {
                addresses.Clear();
            }
            try
            {
                con.Open();
                comm.Connection = con;
                comm.CommandText = "SELECT TOP (1000) [roomName] ,[Capacity] ,[Public] ,[Type] ,[buildingName] FROM [db_a91534_reserveroom].[dbo].[Rooms]";
                dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    addresses.Add(new Address()
                    {
                        roomName = dr["roomName"].ToString(),
                        Capacity = dr["Capacity"].ToString(),
                        Public = dr["Public"].ToString(),
                        Type = dr["Type"].ToString(),
                        buildingName = dr["buildingName"].ToString()
                    });
                }
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: RoomController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Address ad)
        {
            _cc.Add(ad);
            _cc.SaveChanges();
            ViewBag.message = "The room " + ad.roomName+ " has been added successfully😊";
           
            return View();
        }

        // GET: RoomController/Edit/5
        public ActionResult Edit(int id)
        {
            //Address address = new Address();
            //DataTable dt = new DataTable();
            //using(SqlConnection con = new SqlConnection(test1.Properties.Resources.ConnectionString))
            //{
                //con.Open();
                //string Query = "SELECT * FROM Rooms where roomName = @roomName";
                //SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                
                //sda.SelectCommand.Parameters.AddWithValue("@roomName", "%" + name + "%");

                //sda.Fill(dt);
                //if(dt.Rows.Count == 1)
                //{
                    //address.roomName = Convert.ToString(dt.Rows[0][0]).ToString();
                    //address.Capacity = Convert.ToInt32(dt.Rows[0][1]).ToString();
                    //address.Public = Convert.ToInt32(dt.Rows[0][2]).ToString();
                    //address.Type = Convert.ToInt32(dt.Rows[0][3]).ToString();
                    //address.buildingName = Convert.ToInt32(dt.Rows[0][4]).ToString();
                    //return View(address);
                //}
                //else
                //{
                    //return RedirectToAction("index");
                //}
            //}
            return View();
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoomController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}