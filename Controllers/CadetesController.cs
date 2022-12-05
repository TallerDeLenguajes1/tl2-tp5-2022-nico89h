using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using tl2_tp5_2022_nico89h.Models;
using tl2_tp5_2022_nico89h.ViewModels;

namespace tl2_tp5_2022_nico89h.Controllers
{
    public class CadetesController : Controller
    {
        private readonly ILogger<CadetesController> _logger;
        private readonly IMapper _mapper;

        public CadetesController(ILogger<CadetesController> _loggerDos, IMapper _mapperDos)
        {
            _logger = _loggerDos;
            _mapper = _mapperDos;

        }
        public static ICollection<Cadetes> _cadetes = new List<Cadetes>();
        public static ICollection<Pedidos> _pedidos = new List<Pedidos>();
        // GET: CadetesController
        public IActionResult Index()
        {
            var cadetesView = _mapper.Map<List<CadetesView>>(_cadetes);
            int i = 0;
            foreach (var item in _cadetes)
            {
                cadetesView[i].Pedidos= _mapper.Map<List<PedidosView>>(item.Pedidos);
                i++;
            }
            //en el index se mostrara la info de los 
            return View(cadetesView.ToList());
        }

        // GET: CadetesController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: CadetesController/Create

        public IActionResult Create()
        {
            if (!_cadetes.Any())
            {
                return View(new CadetesView { Id1 = 0 });
            }
            else
            {
                return View(new CadetesView { Id1 = _cadetes.Count+1 });
            }
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
                var pedidos = _mapper.Map<List<Pedidos>>(cadete.Pedidos);
                var cadeteAux = _mapper.Map<Cadetes>(cadete);
                cadeteAux.Pedidos = pedidos;
                _cadetes.Add(cadeteAux);
                return RedirectToAction("Index");
            }
            else
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
            int idaux=0;
            foreach (var item in _cadetes)
            {
                if (id==item.Id1)
                {
                    if (item.Pedidos.Any())
                    {
                        idaux = item.Pedidos.Count + 1;
                    }
                }
            }
            return View(new PedidosView { Id1=idaux,Idcadete1=id });
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
                        item.Pedidos = new List<Pedidos>();
                    }
                    var pedidoAgregarDos = _mapper.Map<Pedidos>(pedidoAgregar);
                    _pedidos.Add(pedidoAgregarDos);
                    item.Pedidos.Add(pedidoAgregarDos);
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
                    var aux = _mapper.Map<List<PedidosView>>(item.Pedidos);
                    return View(aux.ToList());
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
                        var pedidoCambio = _mapper.Map<PedidosView>(pedido);
                        return View(pedido);
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult borrarPedido(int id, IFormCollection collection)
        {
            foreach (var item in _cadetes)
            {
                foreach (var pedidoRecorre in item.Pedidos)
                {
                    if (pedidoRecorre.Id1 == id)
                    {
                        _pedidos.Remove(pedidoRecorre);
                        item.Pedidos.Remove(pedidoRecorre);
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        }
        //listadoTotal de pedidos
        public IActionResult listadoPedidosTotal()
        {
            var pedidosView = _mapper.Map<List<PedidosView>>(_pedidos);
            return View(pedidosView);
        }
        // GET: CadetesController/Edit/5
        public ActionResult Edit(int id)
        {
            foreach (var item in _pedidos)
            {
                if (item.Id1 == id)
                {
                    var aux = _mapper.Map<PedidosView>(item);
                    return View(aux);
                }
            }
            return RedirectToAction(nameof(Index));
        }
        // POST: CadetesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                bool existe = false;
                foreach (var item in _cadetes)
                {
                    if (Int32.Parse(collection["Idcadete1"]) == item.Id1)
                    {
                        existe = true;
                        break;
                    }
                }
                if (existe)
                {
                    bool cambio = false;
                    //elimino el pedido de su cadete anterior
                    foreach (var item in _cadetes)
                    {
                        foreach (var itemDos in item.Pedidos)
                        {
                            if (Int32.Parse(collection["Id1"]) == itemDos.Id1)
                            {
                                item.Pedidos.Remove(itemDos);
                                cambio = true;
                                break;
                            }
                        }
                        if (cambio)
                        {
                            break;
                        }
                    }
                    foreach (var item in _cadetes)
                    {

                        if (Int32.Parse(collection["IdCadete1"]) == item.Id1)
                        {
                            foreach (var pedido in _pedidos)
                            {
                                if (Int32.Parse(collection["Id1"]) == pedido.Id1)
                                {

                                    item.Pedidos.Add(pedido);
                                    break;
                                }
                            }
                            break;
                        }

                    }

                    return RedirectToAction("Index");

                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

    }

}
