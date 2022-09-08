using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Module6HW5.Interfaces
{
    public interface IUser
    {
        public ViewResult Create();
        public ViewResult List();
        public ActionResult Update(int id);
        public ActionResult Delete(int id);
    }
}
