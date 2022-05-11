using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace NUnitTests
{
    class HobbyContextUnitTests
    {
        private DBContext dbContext;
        private HobbyContext hobbyContext;
        DbContextOptionsBuilder builder;

        [SetUp]
        public void Setup()
        {
            builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            dbContext = new DBContext(builder.Options);
            hobbyContext = new HobbyContext(dbContext);
        }

        [Test]
        public void TestCreateHobby()
        {
            int hobbiesBefore = hobbyContext.ReadAll().Count();

            hobbyContext.Create(new Hobby("photography"));

            int hobbiesAfter = hobbyContext.ReadAll().Count();

            Assert.IsTrue(hobbiesBefore != hobbiesAfter);
        }

        [Test]
        public void TestReadHobby()
        {
            hobbyContext.Create(new Hobby("photography"));

            Hobby genre = hobbyContext.Read(1);

            Assert.That(genre != null, "There is no record with id 1!");
        }

        [Test]
        public void TestUpdateHobby()
        {
            hobbyContext.Create(new Hobby("photography"));

            Hobby hobby = hobbyContext.Read(1);

            hobby.Name = "volleyball";

            hobbyContext.Update(hobby);

            Hobby hobby2 = hobbyContext.Read(1);

            Assert.IsTrue(hobby2.Name == "volleyball", "Genre Update() does not change name!");
        }

        [Test]
        public void TestDeleteGenre()
        {
            hobbyContext.Create(new Hobby("Delete hobby"));

            int hobbiesBeforeDelete = hobbyContext.ReadAll().Count();

            hobbyContext.Delete(1);

            int hobbiesAfterDelete = hobbyContext.ReadAll().Count();

            Assert.AreNotEqual(hobbiesBeforeDelete, hobbiesAfterDelete);
        }
    }
}
