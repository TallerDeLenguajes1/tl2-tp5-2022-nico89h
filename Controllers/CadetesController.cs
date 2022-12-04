using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using tl2_tp4_2022_nico89h.Models;
using tl2_tp5_2022_nico89h.ViewModels;

namespace tl2_tp4_2022_nico89h.Controllers
{
    public class CadetesController : Controller
    {
        public static ICollection<CadetesView> _cadetes = new List<CadetesView>();
        // GET: CadetesController
        public IActionResult Index()
        {
            //en el index se mostrara la info de los 
            return View(_cadetes.ToList());
        }

        // GET: CadetesController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: CadetesController/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: CadetesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CadetesView cadete)
        {

            if (ModelState.IsValid)
            {
                //Cadetes cadete = new Cadetes(Nombre);
                //Cadetes cadetes = new Cadetes(Nombre);
                _cadetes.Add(cadete);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: CadetesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        // POST: CadetesController/Edit/5
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

        // GET: CadetesController/Delete/5
        public IActionResult Delete(int id)
        {

            foreach (var item in _cadetes)
            {
                if (item.Id1 == id)
                {
                    return View(item);
                }
            }
            return RedirectToAction(nameof(Index));

        }

        // POST: CadetesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {

            try
            {
                foreach (var item in _cadetes)
                {
                    if (item.Id1 == id)
                    {
                        _cadetes.Remove(item);
                        return RedirectToAction(nameof(Index));
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult PedidosAgregar(int id)
        {
            PedidosView pedido = new PedidosView();
            pedido.Idcadete1 = id;
            return View(pedido);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PedidosAgregar(PedidosView pedidoAgregar)
        {
            //agrego el pedido a el cadete
            foreach (var item in _cadetes)
            {
                if (item.Id1 == pedidoAgregar.Idcadete1)
                {
                    if (item.Pedidos == null)
                    {
                        item.Pedidos = new List<PedidosView>();
                    }
                    item.agregarPedido(pedidoAgregar);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult listadoPedidos(int id)
        {
            foreach (var item in _cadetes)
            {
                if (item.Id1 == id)
                {
                    return View(item.Pedidos.ToList());
                }
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult borrarPedido(int id)
        {
            foreach (var item in _cadetes)
            {
                foreach (var pedido in item.Pedidos)
                {
                    if (pedido.Id1 == id)
                    {
                        return View(pedido);
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult borrarPedido(int id,IFormCollection collection)
        {
            foreach (var item in _cadetes)
            {
                foreach (var pedidoRecorre in item.Pedidos)
                {
                    if (pedidoRecorre.Id1 == id)
                    {
                        item.Pedidos.Remove(pedidoRecorre);
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        }
    
    
    }
    
}
