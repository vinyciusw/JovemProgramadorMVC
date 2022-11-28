using JovemProgramadorMVC.Data.Repositorio.Interface;
using JovemProgramadorMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JovemProgramadorMVC.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly IConfiguration _configuration;
        public AlunosController(IAlunoRepositorio alunoRepositorio, IConfiguration configuration)
        {
            _alunoRepositorio = alunoRepositorio;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            try
            {
                var alunos = _alunoRepositorio.BuscarAlunos();
                return View(alunos);
            }
            catch (Exception)
            {
                TempData["MensagemErro"] = "Erro na conexão com o banco de dados.";
                return View();
            }
            
        }

        public IActionResult Adicionar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            var aluno = _alunoRepositorio.BuscarId(id);
            return View(aluno);
        }

        public IActionResult Excluir(AlunoModel alunos)
        {
            _alunoRepositorio.Excluir(alunos);
            return RedirectToAction("Index");
        }

        public IActionResult Alterar(AlunoModel alunos)
        {
            _alunoRepositorio.Atualizar(alunos);
            return RedirectToAction("Index");
        }
        public IActionResult InserirAluno(AlunoModel alunos)
        {
            _alunoRepositorio.InserirAluno(alunos);
            TempData["MensagemSucesso"] = "Aluno adicionado com sucesso!";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            cep = cep.Replace("-", "");

            EnderecoModel enderecoModel = new();

            using var client = new HttpClient();

            var result = await client.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"] + cep + "/json");

            if (result.IsSuccessStatusCode)
            {
                enderecoModel = JsonSerializer.Deserialize<EnderecoModel>(
                    await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { });
            }

            return View("Endereco", enderecoModel);
        }

    }
}