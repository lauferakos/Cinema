using Cinema.Controllers.Dto;
using Cinema.DAL.EfDbContext;
using Cinema.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DAL
{
    public class ViewerRepository : IViewerRepository
    {
        private readonly CinemaDbContext db;

        public ViewerRepository(CinemaDbContext db)
        {
            this.db = db;
        }
        public Viewer Delete(int viewerId)
        {
            var dbViewer = db.Viewers.FirstOrDefault(t => t.Id == viewerId);
            if (dbViewer == null)
            {
                return null;
            }
            else
            {
                db.Viewers.Remove(dbViewer);
                db.SaveChanges();

                return ToModel(dbViewer);
            }
        }

        public Viewer FindById(int viewerId)
        {
            var dbViewer = db.Viewers.FirstOrDefault(t => t.Id == viewerId);
            if (dbViewer == null)
                return null;
            else
                return ToModel(dbViewer);
        }

        public IReadOnlyCollection<Viewer> List()
        {
            return db.Viewers.Select(ToModel).ToList();
        }

        private static Model.Viewer ToModel(DbViewer value)
        {
            return new Model.Viewer(value.Id, value.Name);
        }

        public LoginStatus CheckUserPassword(string username, string password)
        {
            var dbViwer = db.Viewers.FirstOrDefault(v => v.Name == username && v.PassWord == password);
            if (dbViwer == null)
            {
                return null;
            }
            else
            {
                return new LoginStatus(true, dbViwer.Id);
            }
        }

        public Viewer Insert(CreateViewer value)
        {
            using (var tran = db.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
            {

                var toInsert = new DbViewer()
                {
                   Name = value.Name,
                   PassWord = value.PassWord
                };
                db.Viewers.Add(toInsert);

                db.SaveChanges();
                tran.Commit();

                return new Model.Viewer(toInsert.Id, toInsert.Name);
            }
        }
    }
}
