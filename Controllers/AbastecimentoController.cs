using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using teste.Entidade;
using teste.Models;
using teste.Services.Interface;

namespace teste.Controllers
{
    public class AbastecimentoController : Controller
    {
        private readonly IAbastecimentoService _service;
        private readonly IVeiculoService _veiculoService;
        private readonly IMotoristaService _motoristaService;
        private readonly IMapper _mapper;

        public AbastecimentoController(IAbastecimentoService service, IMapper mapper, IMotoristaService motoristaService,IVeiculoService veiculoService)
        {
            _service = service;
            _mapper = mapper;
            _motoristaService = motoristaService;
            _veiculoService = veiculoService;
        }

        // GET: MotoristaController
        public async Task<IActionResult> Index(AbastecimentoModel model)
        {
            if (!Util.Logado)
                return RedirectToAction("Index", "Login");

            var lista = new AbastecimentoModels();

            lista.list = _mapper.Map<List<AbastecimentoModel>>(await _service.Search(_mapper.Map<Abastecimento>(model)));
            lista.listMotorista = _mapper.Map<List<MotoristaModel>>(await _motoristaService.Search(null));
            lista.listVeiculo = _mapper.Map<List<VeiculoModel>>(await _veiculoService.Search(null));
            lista.item = model;

            return View(lista);
        }

        public IActionResult Details(AbastecimentoModel model)
        {
            if (!Util.Logado)
                return RedirectToAction("Index", "Login");

            return RedirectToAction("Index", model);
        }

        // GET: MotoristaController/Create
        public async Task<IActionResult> Create()
        {
            if (!Util.Logado)
                return RedirectToAction("Index", "Login");

            var lista = new AbastecimentoModels();

            lista.listMotorista = _mapper.Map<List<MotoristaModel>>(await _motoristaService.Search(null));
            lista.listVeiculo = _mapper.Map<List<VeiculoModel>>(await _veiculoService.Search(null));

            return View(lista);
        }

        // POST: MotoristaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AbastecimentoModel model)
        {
            try
            {
                if (!Util.Logado)
                    return RedirectToAction("Index", "Login");

                _service.Create(_mapper.Map<Abastecimento>(model));

                return RedirectToAction("Create");
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

            var lista = new AbastecimentoModels();

            lista.listMotorista = _mapper.Map<List<MotoristaModel>>(await _motoristaService.Search(null));
            lista.listVeiculo = _mapper.Map<List<VeiculoModel>>(await _veiculoService.Search(null));
            lista.item = _mapper.Map<AbastecimentoModel>(await _service.Search(id));

            return View(lista);
        }

        // POST: MotoristaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AbastecimentoModel model)
        {
            try
            {
                if (!Util.Logado)
                    return RedirectToAction("Index", "Login");

                _service.Update(_mapper.Map<Abastecimento>(model));

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
