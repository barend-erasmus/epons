using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMS.Domain.Repositories.EF;
using System.Linq;
using System.Data.Entity;

namespace EPMS.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string host = "epons.dedicated.co.za";
            string user = "sa";
            string name = "EPMS";
            string password = "password";

            string connectionString = $"data source={host};Initial Catalog={name};User ID={user};Password={password};";

            Database.SetInitializer<DbContext>(new DropCreateDatabaseAlways<DbContext>());
            Context context = new Context(connectionString);
            context.Patients.ToList();
        }
    }
}
