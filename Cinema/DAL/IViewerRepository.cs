using Cinema.Controllers.Dto;
using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DAL
{
    public interface IViewerRepository
    {
        IReadOnlyCollection<Viewer> List();

        Viewer FindById(int viewerId);

        Viewer Insert(CreateViewer value);
        Viewer Delete(int viewerId);

        LoginStatus CheckUserPassword(string username,string password);
    }
}
