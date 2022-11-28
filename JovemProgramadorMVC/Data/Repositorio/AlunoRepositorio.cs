using JovemProgramadorMVC.Data.Repositorio.Interface;
using JovemProgramadorMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMVC.Data.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly JovemProgramadorContexto _jovemProgramadorContexto;

        public AlunoRepositorio(JovemProgramadorContexto jovemProgramadorContexto)
        {
            _jovemProgramadorContexto = jovemProgramadorContexto;
        }

        public void InserirAluno(AlunoModel alunos)
        {
            _jovemProgramadorContexto.Aluno.Add(alunos);
            _jovemProgramadorContexto.SaveChanges();
        }

        public AlunoModel Atualizar(AlunoModel alunos)
        {
            _jovemProgramadorContexto.Update(alunos);
            _jovemProgramadorContexto.SaveChanges();

            return alunos;
        }

        public AlunoModel Excluir(AlunoModel alunos)
        {
            _jovemProgramadorContexto.Remove(alunos);
            _jovemProgramadorContexto.SaveChanges();

            return alunos;
        }

        public List<AlunoModel> BuscarAlunos()
        {
            return _jovemProgramadorContexto.Aluno.ToList();
        }

        public AlunoModel BuscarId(int id)
        {
            return _jovemProgramadorContexto.Aluno.FirstOrDefault(x => x.Id == id);
        }
    }
}