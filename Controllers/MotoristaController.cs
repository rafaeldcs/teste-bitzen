using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using teste.Entidade;
using teste.Models;
using teste.Services.Interface;

namespace teste.Controllers
{
    public class MotoristaController : Controller
    {
        private readonly IMotoristaService _service;
        private readonly IMapper _mapper;

        public MotoristaController(IMotoristaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: MotoristaController
        public async Task<IActionResult> Index(MotoristaModel model)
        {
            if (!Util.Logado)
                return RedirectToAction("Index", "Login");

            var lista = new MotoristaModels();

            lista.list = _mapper.Map<List<MotoristaModel>>(await _service.Search(_mapper.Map<Motorista>(model)));
            lista.item = model;

            return View(lista);
        }

        public IActionResult Details(MotoristaModel model)
        {
            if (!Util.Logado)
                return RedirectToAction("Index", "Login");

            return RedirectToAction("Index", model);
        }

        // GET: MotoristaController/Create
        public IActionResult Create()
        {
            if (!Util.Logado)
                return RedirectToAction("Index", "Login");

            return View();
        }

        // POST: MotoristaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MotoristaModel model)
        {
            try
            {
                if (!Util.Logado)
                    return RedirectToAction("Index", "Login");

                _service.Create(_mapper.Map<Motorista>(model));

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }

        // GET: MotoristaController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (!Util.Logado)
                return RedirectToAction("Index", "Login");

            return View(_mapper.Map<MotoristaModel>(await _service.Search(id)));
        }

        // POST: MotoristaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MotoristaModel model)
        {
            try
            {
                if (!Util.Logado)
                    return RedirectToAction("Index", "Login");

                _service.Update(_mapper.Map<Motorista>(model));

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Edit");
            }
        }

        // POST: MotoristaController/Delete/5
        public IActionResult Delete(int id)
        {
            try
            {
                if (!Util.Logado)
                    return RedirectToAction("Index", "Login");

                _service.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
