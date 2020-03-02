using System;
using System.Collections.Generic;
using System.Text;
using ageebSoft.RoomService.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ageebSoft.RoomService.Data
{
    public class MyDB : DbContext
    {

        public DbSet<Cust> Custs { set; get; }
        public DbSet<Rooms> Rooms { set; get; }
        public DbSet<RoomsMovement> Movements { set; get; }


        public MyDB(DbContextOptions<MyDB> options)
            : base(options)
        {
            ////Required for SQLite
            //this.Database.OpenConnection();
            //this.Database.EnsureCreated();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public MyDB(DbContextOptionsBuilder builder) : base(builder.Options)
        {

            // MigrationX();
            //ToDo:إرجاع migration
            //if (Reg.IsDBLoad) { Onload(); }

        }




         

    }

}
