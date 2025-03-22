using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;



namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoListDbContext _db;

        public ToDoController(ToDoListDbContext db)
        {
            _db = db; // DbContext'i alıyoruz
        }

        // 1. Tüm görevleri listele
        public ActionResult Index()
        {
            return View(_db.ToDoItems.ToList());
        }

        // 2. Yeni görev ekleme sayfası
        public ActionResult Create()
        {
            return View();
        }

        // 3. Yeni görev ekleme işlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDoItem todo)
        {
            if (ModelState.IsValid)
            {
                _db.ToDoItems.Add(todo);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // 4. Görevi tamamlandı olarak işaretle
        public ActionResult Complete(int id)
        {
            var todo = _db.ToDoItems.Find(id);
            if (todo == null)
                return NotFound();

            todo.IsCompleted = true;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // 5. Görevi silme
        public ActionResult Delete(int id)
        {
            var todo = _db.ToDoItems.Find(id);
            if (todo == null)
                return NotFound();

            _db.ToDoItems.Remove(todo);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
